using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interface;
using UnityEngine;

namespace Game.Controller
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float speed = 3;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Animator _animator;
        private List<ISkill> Skills = new List<ISkill>();
        private ICharacterState currentState;

        public CharacterController Controller => _controller;
        public float Speed => speed;

        public void Initialize(List<ISkill> skills) // call from somewhere that have character data
        {
            Skills = skills;
        }
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => InputManager.Singleton != null);
        }

        private void Update()
        {
            var Input = InputManager.Singleton.ReadInput();

            if (Input.Type == EInputType.None)
            {
                ChangeState(new IdleState());
            }
            else if (Input.Type == EInputType.Move && currentState is not WalkingState)
            {
                ChangeState(new WalkingState());
            }
            else if (Input.Type == EInputType.Skill)
            {
                int skillindex = (int)Input.Value;
                ActiveSkill(skillindex);
            }
            
            currentState?.Update(this,Input.Value);
        }

        private void ActiveSkill(int index)
        {
            if (Skills.Count > index)
            {
                ChangeState(new UsingSkillState(Skills[index]));
            }
        }
        
        public void ChangeState(ICharacterState newState)
        {
            currentState?.Exit(this);
            currentState = newState;
            currentState.Enter(this);
        }

        public void SetAnimatorBool(string key, bool value)
        {
            _animator.SetBool(key,value);
        }
    }
}



using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interface;
using UnityEngine;

namespace Game.Controller
{
    public class Character : MonoBehaviour , IDisposable
    {
        [SerializeField] private float speed = 3;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private Animator _animator;
        private List<ISkill> Skills = new List<ISkill>();
        private ICharacterState currentState;

        public CharacterController Controller => _controller;
        public Animator Animator => _animator;
        public float Speed => speed;

        public void Initialize(List<ISkill> skills) // call from somewhere that have character data
        {
            Skills = skills;
        }
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => InputManager.Singleton != null);
            InputManager.Singleton.MoveInput += Move;
            InputManager.Singleton.SkillInput += ActiveSkill;
        }

        private void Update()
        {
            currentState?.Update(this);
        }
        
        public void Move(Vector2 direction)
        {
            if (direction != Vector2.zero && currentState is not WalkingState)
            {
                ChangeState(new WalkingState());
            }
        }

        public void Dispose()
        {
            InputManager.Singleton.MoveInput -= Move;
            InputManager.Singleton.SkillInput -= ActiveSkill;
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
    }
}



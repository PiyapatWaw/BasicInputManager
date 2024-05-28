using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interface;
using UnityEngine;

namespace Game.Controller
{
    public class Character : MonoBehaviour, IMove , IDisposable
    {
        private List<ISkill> Skills = new List<ISkill>();

        public void Initialize(List<ISkill> skills) // call from somewhere that have character data
        {
            Skills = skills;
        }
        
        private IEnumerator Start()
        {
            yield return new WaitUntil(() => InputManager.Singleton != null);
            InputManager.Singleton.MoveInput += MoveCharacter;
            InputManager.Singleton.SkillInput += ActiveSkill;
        }

        public void MoveCharacter(Vector2 direction)
        {
            Vector3 move = new Vector3(direction.x, 0, direction.y);
            transform.Translate(move * Time.deltaTime * 5f);
        }

        public void Dispose()
        {
            InputManager.Singleton.MoveInput -= MoveCharacter;
            InputManager.Singleton.SkillInput -= ActiveSkill;
        }

        private void ActiveSkill(int index)
        {
            if(Skills.Count > index)
                Skills[index].ActiveSkill();
        }
    }
}



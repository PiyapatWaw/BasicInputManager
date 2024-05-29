using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.Interface;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class UsingSkillState : ICharacterState
    {
        private ISkill skill;

        public UsingSkillState(ISkill skill)
        {
            this.skill = skill;
        }

        public void Exit(Character character)
        {
            character.ChangeState(new IdleState());
        }

        public void Update(Character character, object value)
        {
            throw new System.NotImplementedException();
        }

        public void Enter(Character character)
        {
            throw new System.NotImplementedException();
        }
    }
}



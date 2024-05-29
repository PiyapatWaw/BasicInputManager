using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.Interface;
using UnityEngine;

namespace Game
{
    public class WalkingState : ICharacterState
    {
        public void Enter(Character character)
        {
            character.SetAnimatorBool("Walk", true);
        }

        public void Exit(Character character)
        {
            character.SetAnimatorBool("Walk", false);
        }

        public void Update(Character character, object value)
        {
            if (value is Vector2 direction)
                Move(character,direction);
        }
        

        private void Move(Character character,Vector2 direction)
        {
            if (direction == Vector2.zero)
            {
                character.ChangeState(new IdleState());
                return;
            }

            Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
            Quaternion newRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, newRotation, Time.deltaTime * character.Speed);
            moveDirection *= Time.deltaTime * character.Speed;
            character.Controller.Move(moveDirection);
        }
    }
}



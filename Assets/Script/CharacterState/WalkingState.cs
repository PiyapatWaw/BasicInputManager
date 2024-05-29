using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using Game.Interface;
using UnityEngine;

namespace Game
{
    public class WalkingState : ICharacterState ,IMove
    {
        private Character character;
        
        public void Enter(Character character)
        {
            this.character = character;
            InputManager.Singleton.MoveInput += Move;
            character.Animator.SetBool("Walk", true);
        }

        public void Exit(Character character)
        {
            InputManager.Singleton.MoveInput -= Move;
            character.Animator.SetBool("Walk", false);
        }

        public void Update(Character character)
        {
            
        }

        public void Move(Vector2 direction)
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



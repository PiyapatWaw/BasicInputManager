using System;
using UnityEngine;

namespace Game.Controller
{
    public class InputManager : MonoBehaviour
    {
        private readonly KeyCode[] skillKeys = { KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4 };
        
        public static InputManager Singleton;
        public event Action<Vector2> MoveInput;
        public event Action<int> SkillInput;

        private void Awake()
        {
            Singleton = this;
        }

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            ReadMove(input);
            
            for (int i = 0; i < skillKeys.Length; i++)
            {
                if (Input.GetKeyDown(skillKeys[i]))
                {
                    ReadSkill(i);
                }
            }
        }
        
        public void ReadMove(Vector2 direction)
        {
            MoveInput?.Invoke(direction);
        }
        public void ReadSkill(int index) // can call by ui button follow index
        {
            SkillInput?.Invoke(index);
        }
    }
}

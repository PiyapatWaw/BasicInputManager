using System;
using UnityEngine;

namespace Game.Controller
{
    public class InputManager : MonoBehaviour
    {
        private readonly KeyCode[] skillKeys = { KeyCode.Keypad1, KeyCode.Keypad2, KeyCode.Keypad3, KeyCode.Keypad4 };
        
        public static InputManager Singleton;

        private void Awake()
        {
            Singleton = this;
        }

        public InputValue ReadInput()
        {
            var vector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (vector != Vector2.zero)
                return new InputValue(EInputType.Move,vector);
            
            for (int i = 0; i < skillKeys.Length; i++)
            {
                if (Input.GetKeyDown(skillKeys[i]))
                {
                    return new InputValue(EInputType.Skill,i);
                }
            }
            
            return new InputValue(EInputType.None,null);
        }
    }

    public enum EInputType
    {
        None,
        Move,
        Skill,
    }
    
    public struct InputValue
    {
        public EInputType Type;
        public object  Value;

        public InputValue(EInputType type, object  value)
        {
            Type = type;
            Value = value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Game.Controller;
using UnityEngine;

namespace Game.Interface
{
    public interface ISkill
    {
        public Sprite Icon { get; set; }
        public void Active(Character user);
    }
}



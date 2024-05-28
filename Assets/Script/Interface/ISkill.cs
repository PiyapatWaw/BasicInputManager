using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interface
{
    public interface ISkill
    {
        public Sprite Icon { get; set; }
        public void ActiveSkill();
    }
}



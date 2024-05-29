using Game.Controller;

namespace Game.Interface
{
    public interface ICharacterState
    {
        void Enter(Character character);
        void Exit(Character character);
        void Update(Character character);
    }
}



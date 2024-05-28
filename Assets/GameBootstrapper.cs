using Game.Controller;
using UnityEngine;

namespace Game
{
    public class GameBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main()
        {
            var service = new GameObject("Service");
            Object.DontDestroyOnLoad(service);
            service.AddComponent<InputManager>();
        }
    }
}
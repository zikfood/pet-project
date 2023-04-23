using Components.Common.Input;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Systems.InputSystems
{
    public class KeyInputSystem : IEcsPreInitSystem
    {
        private Input _inputSystem;
        private EcsWorld _world = null;
        private SceneData _sceneData;

        public void PreInit()
        {

        }

    }
}
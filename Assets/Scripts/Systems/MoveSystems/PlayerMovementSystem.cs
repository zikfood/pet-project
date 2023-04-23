using Leopotam.Ecs;
using UnityEngine;
using Components.Objects.Moves;
using Components.Objects.Tags;
using UnityComponents.Common;

namespace Systems.MoveSystems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private EcsFilter<AllyUnitTag> _allyFilter = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            foreach (var index in _allyFilter)
            {
                _allyFilter.GetEntity(index).Get<Velocity>().Value = 
                    _sceneData.InputSystem.Gameplay.Movement.ReadValue<Vector2>() *
                    _sceneData.Velocity;
            }
        }
    }
}
using Components.Common.MonoLinks;
using Components.Objects;
using Leopotam.Ecs;
using Components.Objects.Moves;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class MoveForwardSystem : IEcsRunSystem
    {
        private EcsFilter<MoveForward, Velocity, Position> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var newVelocity = ref _filter.Get1(index).Velocity;
                ref var velocity = ref _filter.Get2(index).Value;
                ref var pos = ref _filter.Get3(index).Value;
                var transform = _filter.GetEntity(index).Get<GameObjectLink>().Value.transform;
                var angle = transform.rotation.eulerAngles.magnitude * Mathf.PI /180;
                velocity = new Vector3(Mathf.Sin(angle) * -1, Mathf.Cos(angle), 0) * newVelocity;
                pos += velocity;
            }
        }
    }
}
using Components.Common.MonoLinks;
using Components.Objects;
using Leopotam.Ecs;
using Components.Objects.Moves;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class CheckCollisionOnMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Velocity, RigidbodyLink, CheckCollisionOnMove> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(index);
                ref Position position = ref entity.Get<Position>();
                ref Velocity velocity = ref _filter.Get1(index);
                ref Rigidbody2D rb = ref _filter.Get2(index).Value;
                var raycast = Physics2D.RaycastAll(
                    position.Value,
                    velocity.Value, 
                    velocity.Value.magnitude);

                if (rb.Cast(velocity.Value, raycast, velocity.Value.magnitude) > 0) 
                {
                    return;
                }
                
                position.Value += velocity.Value;
            }
        }
    }
}
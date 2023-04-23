using Components.Common.MonoLinks;
using Components.Objects;
using Leopotam.Ecs;
using Components.Objects.Moves;
using UnityEngine;

namespace Systems.MoveSystems
{
    public class MoveForwardSystem : IEcsRunSystem
    {
        private EcsFilter<MoveForward, Velocity> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var newVelocity = ref _filter.Get1(index).Velocity;
                var x = _filter.GetEntity(index).Get<GameObjectLink>().Value.transform.forward;
                var angle = _filter.GetEntity(index).Get<GameObjectLink>().Value.transform.rotation.eulerAngles.magnitude * Mathf.PI /180;
                _filter.Get2(index).Value = new Vector3(Mathf.Sin(angle) * -1, Mathf.Cos(angle), 0) * newVelocity;
            }
        }
    }
}
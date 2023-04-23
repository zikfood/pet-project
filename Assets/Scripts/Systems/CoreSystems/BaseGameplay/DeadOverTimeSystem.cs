using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DeadOverTimeSystem : IEcsRunSystem
    {
        private EcsFilter<DeadOverTime> _filter;
        private EcsWorld _world = null;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var livingTime = ref _filter.Get1(index).LivingTime;
                ref var timeOfBitrh = ref _filter.Get1(index).TimeOfBirth;
                ref var entity = ref _filter.GetEntity(index);
                if (livingTime < Time.time - timeOfBitrh)
                {
                    _world.NewEntity().Get<DeadEvent>() = new DeadEvent()
                    {
                        TargetEntity = entity,
                        TargetGo = entity.Get<GameObjectLink>().Value
                    };
                    entity.Del<DeadOverTime>();
                }
            }
        }
    }
}
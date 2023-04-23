using Components.Core;
using Components.Objects;
using Components.PhysicsEvents;
using Components.UnityComponents.MonoLinks;
using Leopotam.Ecs;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DamageOnTriggerEnterSystem : IEcsRunSystem
    {
        private EcsFilter<OnTriggerEnterEvent> _filter = null;
        private EcsWorld _world = null;
        
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var sender = ref _filter.Get1(index).Sender;
                ref var target = ref _filter.Get1(index).Collider;
                if (!sender.TryGetComponent(out DamageMonoLink damage))
                    return;
                
                _world.NewEntity().Get<DamageEvent>() = new DamageEvent()
                {
                    DamageAmount = damage.Value.Value,
                    Target = target.transform
                };
            }
        }
    }
}
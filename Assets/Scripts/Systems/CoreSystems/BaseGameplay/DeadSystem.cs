using Components.Core;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DeadSystem : IEcsRunSystem
    {
        private EcsFilter<DeadEvent> _filter = null;
        private EcsWorld _world = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref GameObject gameObject = ref _filter.Get1(index).TargetGo;
                _filter.Get1(index).TargetEntity.Destroy();
                GameObject.Destroy(gameObject);
            }
        }
    }
}
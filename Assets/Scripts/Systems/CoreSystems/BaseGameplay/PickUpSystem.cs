using Components.Common;
using Components.Core;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class PickUpSystem : IEcsRunSystem
    {
        private EcsFilter<PickUpEvent> _pickUpFilter = null;
        private EcsWorld _world = null;

        public void Run()
        {
            foreach (int index in _pickUpFilter)
            {
                ref var targetGo = ref _pickUpFilter.Get1(index).Target;
                ref var pickUpPrefab = ref _pickUpFilter.Get1(index).PickUpPrefab;
                ref var sender = ref _pickUpFilter.Get1(index).Sender;
                
                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                {
                    Prefab = pickUpPrefab,
                    Position = targetGo.transform.position,
                    Rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f),
                    Parent = targetGo.transform
                };

                _world.NewEntity().Get<DeadEvent>() = new DeadEvent
                {
                    TargetGo = sender,
                    TargetEntity = sender.GetComponent<MonoEntity>().Entity
                };
            }
        }
    }
}
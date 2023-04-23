using Components.Core;
using Components.UnityComponents.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class DamageSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<DamageEvent> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref Transform target = ref _filter.Get1(index).Target;
                ref int damageAmount = ref _filter.Get1(index).DamageAmount;


                if (!target.TryGetComponent(out HealthMonoLink enemyHealth))
                    return;
                    
                enemyHealth.Value.CurHealth -= damageAmount;
                if (enemyHealth.Value.CurHealth <= 0)
                {
                    _world.NewEntity().Get<DeadEvent>() = new DeadEvent()
                    {
                        TargetEntity = target.GetComponent<MonoEntity>().Entity,
                        TargetGo = target.gameObject
                    };
                }
            }
        }
    }
}
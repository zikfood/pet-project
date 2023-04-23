using System.Collections.Generic;
using Components.Common;
using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class SpawnMeleeAttackSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<EnemyCloseEvent> _eventFilter = null;

        private Vector3 _attackDir;
        private float _attackAngle;

        public void Run()
        {
            foreach (var index in _eventFilter)
            {
                ref EcsEntity senderEntity = ref _eventFilter.Get1(index).Sender;
                ref var attackProperties = ref senderEntity.Get<MeleeAttack>();

                if (attackProperties.AttackCooldown > Time.time - attackProperties.AttackPerformedTime)
                {
                    return;
                }
                attackProperties.AttackPerformedTime = Time.time;

                ref List<EcsEntity> targetEntities = ref _eventFilter.Get1(index).TargetEntities;
                ref GameObject senderGo = ref senderEntity.Get<GameObjectLink>().Value;
                var senderPos = senderGo.transform.position;
                Vector3 targetPos = targetEntities[0].Get<GameObjectLink>().Value.transform.position;
                
                _attackDir = targetPos - senderPos;
                _attackDir = targetEntities[0].Get<GameObjectLink>().Value.transform.InverseTransformDirection(_attackDir);
                _attackAngle = Mathf.Atan2(_attackDir.y, _attackDir.x) * Mathf.Rad2Deg - 90;

                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                {
                    Prefab = attackProperties.ProjectilePrefab,
                    Position = senderPos,
                    Rotation = Quaternion.Euler(0f, 0f, _attackAngle),
                    Parent = null,
                    XScale = attackProperties.AttackSize.x,
                    YScale = attackProperties.AttackSize.y
                };
            }
        }
    }
}
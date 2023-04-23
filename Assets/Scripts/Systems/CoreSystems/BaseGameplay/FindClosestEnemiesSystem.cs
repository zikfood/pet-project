using System.Collections.Generic;
using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects;
using Components.UnityComponents.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Systems.CoreSystems.BaseGameplay
{
    public class FindClosestEnemiesSystem : IEcsRunSystem
    {
        private EcsWorld _world = null;
        private EcsFilter<InteractWithCloseEnemies> _senderFilter = null;
        private float _circleRadius;
        private Vector3 _senderPos;
        private RaycastHit2D[] _collidersInCircle;
        private List<EcsEntity> _enemyEntities = new List<EcsEntity>();

        public void Run()
        {
            foreach (int index in _senderFilter)
            {
                _senderPos = _senderFilter.GetEntity(index).Get<GameObjectLink>().Value.transform.position;
                _circleRadius = _senderFilter.Get1(index).RadiusOfIteract;
                _collidersInCircle = Physics2D.CircleCastAll(_senderPos,_circleRadius,Vector2.zero);
                
                foreach (var collider in _collidersInCircle)
                {
                    if (collider.collider.TryGetComponent(out EnemyTagMonoLink enemy))
                    {
                        _enemyEntities.Add(enemy.GetComponent<MonoEntity>().Entity);
                    }
                }

                if (_enemyEntities.Count == 0)
                {
                    return;
                }
                
                _world.NewEntity().Get<EnemyCloseEvent>() = new EnemyCloseEvent()
                {
                    TargetEntities = new List<EcsEntity>(_enemyEntities),
                    Sender = _senderFilter.GetEntity(index)
                };
                
                _enemyEntities.Clear();
            }
        }
    }
}
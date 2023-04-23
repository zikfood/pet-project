using Components.Common.MonoLinks;
using Components.Objects;
using Leopotam.Ecs;
using Components.Objects.Tags;
using UnityEngine.AI;

namespace Systems.MoveSystems
{
    public class EnemyFollowSystem : IEcsRunSystem
    {
        private EcsFilter<EnemyTag> _enemyFilter = null;
        private EcsFilter<AllyUnitTag> _filter = null;

        public void Run()
        {
            foreach (int index in _enemyFilter)
            {
                ref EcsEntity entity = ref _enemyFilter.GetEntity(index);
                ref NavMeshAgent agent = ref entity.Get<NavMeshAgentLink>().Value;
                ref EcsEntity allyentity = ref _filter.GetEntity(0);

                agent.SetDestination(allyentity.Get<NavMeshAgentLink>().Value.transform.position);
            }
        }
    }
}
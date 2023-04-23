using Components.Common.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;
using UnityEngine.AI;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    public class NavMeshAgentMonoLink : MonoLink<NavMeshAgentLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<NavMeshAgentLink>() = new NavMeshAgentLink
            {
                Value = gameObject.GetComponent<NavMeshAgent>()
            };
        }
    }
}
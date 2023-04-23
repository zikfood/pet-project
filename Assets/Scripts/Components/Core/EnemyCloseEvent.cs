using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace Components.Core
{
    public struct EnemyCloseEvent
    {
        public List<EcsEntity> TargetEntities;
        public EcsEntity Sender;
    }
}
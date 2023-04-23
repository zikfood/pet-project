using Leopotam.Ecs;
using UnityEngine;

namespace Components.Core
{
    public struct DeadEvent 
    {
        public GameObject TargetGo;
        public EcsEntity TargetEntity;
    }
}
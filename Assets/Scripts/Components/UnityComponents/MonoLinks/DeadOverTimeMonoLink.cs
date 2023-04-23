using Components.Objects;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Components.UnityComponents.MonoLinks
{
    public class DeadOverTimeMonoLink : MonoLink<DeadOverTime>
    {
        public override void Make(ref EcsEntity entity)
        {
            Value.TimeOfBirth = Time.time;
            
            if (entity.Has<DeadOverTime>())
            {
                return;
            }
            entity.Get<DeadOverTime>() = Value;
        }
    }
}
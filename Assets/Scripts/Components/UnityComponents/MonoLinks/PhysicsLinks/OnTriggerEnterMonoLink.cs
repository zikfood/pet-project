using Components.PhysicsEvents;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Components.UnityComponents.MonoLinks.PhysicsLinks
{
    public class OnTriggerEnterMonoLink : PhysicsLinkBase
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            _entity.Get<OnTriggerEnterEvent>() = new OnTriggerEnterEvent
            {
                Collider = other,
                Sender = gameObject
            };
        }
    }
}
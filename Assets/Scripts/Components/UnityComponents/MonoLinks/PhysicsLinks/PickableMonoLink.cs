using Components.Core;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace Components.UnityComponents.MonoLinks
{
    public class PickableMonoLink : PhysicsLinkBase
    {
        public GameObject PickUpPrefab;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out AllyUnitTagMonoLink allyUnit))
            {
                _entity.Get<PickUpEvent>() = new PickUpEvent
                {
                    PickUpPrefab = PickUpPrefab,
                    Target = col.gameObject,
                    Sender = gameObject
                };
            }
        }
    }
}
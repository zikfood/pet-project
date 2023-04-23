using Leopotam.Ecs;
using UnityEngine;

namespace Components.Core
{
    public struct PickUpEvent
    {
        public GameObject PickUpPrefab;
        public GameObject Sender;
        public GameObject Target;
    }
}
using UnityEngine;

namespace Components.PhysicsEvents
{
    public struct OnCollisionEnterEvent
    {
        public GameObject Sender;
        public Collision2D Collision;
    }
}
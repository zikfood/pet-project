using System;
using UnityEngine;

namespace Components.Objects
{
    [Serializable]
    public struct MeleeAttack
    {
        [HideInInspector]
        public float AttackPerformedTime;
        public float AttackCooldown;
        public Vector2 AttackSize;
        public GameObject ProjectilePrefab;
    }
}
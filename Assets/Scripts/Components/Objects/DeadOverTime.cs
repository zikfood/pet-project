using System;
using UnityEngine;

namespace Components.Objects
{
    [Serializable]
    public struct DeadOverTime
    {
        [HideInInspector]
        public float TimeOfBirth;
        public float LivingTime;
    }
}
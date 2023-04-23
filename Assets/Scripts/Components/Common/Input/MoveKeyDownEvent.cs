using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct MoveKeyDownEvent
    {
        public InputAction.CallbackContext Value;
        public Vector3 MoveVector;
    }
}
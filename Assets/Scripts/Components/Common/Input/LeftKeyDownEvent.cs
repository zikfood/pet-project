using Leopotam.Ecs;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct LeftKeyDownEvent : IEcsIgnoreInFilter
    {
        public InputAction.CallbackContext Value;
    }
}
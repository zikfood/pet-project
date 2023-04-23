using Leopotam.Ecs;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct RightKeyDownEvent : IEcsIgnoreInFilter
    {
        public InputAction.CallbackContext Value;
    }
}
using Leopotam.Ecs;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct UpKeyDownEvent : IEcsIgnoreInFilter
    {
        public InputAction.CallbackContext Value;
    }
}
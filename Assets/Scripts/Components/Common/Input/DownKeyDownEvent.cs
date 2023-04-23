using Leopotam.Ecs;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct DownKeyDownEvent : IEcsIgnoreInFilter
    {
        public InputAction.CallbackContext Value;
    }
}
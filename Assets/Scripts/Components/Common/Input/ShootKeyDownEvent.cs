using Leopotam.Ecs;
using UnityEngine.InputSystem;

namespace Components.Common.Input
{
    public struct ShootKeyDownTag : IEcsIgnoreInFilter
    {
        public InputAction.CallbackContext Value;
    }
}
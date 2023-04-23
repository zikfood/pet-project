using Components.Common.MonoLinks;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    [RequireComponent(typeof(Collider2D))]
    public class ColliderMonoLink : MonoLink<ColliderLink>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Value.Value == null)
            {
                Value = new ColliderLink
                {
                    Value = GetComponent<Collider2D>()
                };
            }
        }
#endif
    }
}
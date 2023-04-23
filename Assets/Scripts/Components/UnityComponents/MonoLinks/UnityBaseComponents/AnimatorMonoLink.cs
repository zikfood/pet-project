using Components.Common.MonoLinks;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorMonoLink : MonoLink<AnimatorLink>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Value.Value == null)
            {
                Value = new AnimatorLink
                {
                    Value = GetComponent<Animator>()
                };
            }
        }
#endif
    }
}
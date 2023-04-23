using Components.Common.MonoLinks;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.MonoLinks.UnityBaseComponents
{
    public class MeshRendererMonoLink : MonoLink<MeshRendererLink>
    {
        public override void Make(ref EcsEntity entity)
        {
            entity.Get<MeshRendererLink>() = new MeshRendererLink
            {
                Value = gameObject.GetComponent<MeshRenderer>()
            };
        }
    }
}
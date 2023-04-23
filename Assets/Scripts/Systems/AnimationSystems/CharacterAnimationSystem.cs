using Components.Common.MonoLinks;
using Components.Core;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Battle_System.Systems.AnimationSystems
{
    public class CharacterAnimationSystem 
    {
        /*private EcsFilter<MovingTag> _moveFilter = null;
        private EcsFilter<AttackTag> _attackFilter = null;

        public void Run()
        {
            foreach (var index in _moveFilter)
            {
                ref EcsEntity entity = ref _moveFilter.GetEntity(index);
                Animator animator = entity.Get<AnimatorLink>().Value;
                animator.SetTrigger("Move"); 
                entity.Del<MovingTag>();
            }

            foreach (var index in _attackFilter)
            {
                ref EcsEntity entity = ref _attackFilter.GetEntity(index);
                Animator animator = entity.Get<AnimatorLink>().Value;
                animator.SetTrigger("Attack");
                //entity.Del<AttackTag>();
            }
        }*/
    }
}
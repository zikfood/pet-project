using Components.Core;
using Components.Objects.Tags;
using Leopotam.Ecs;
using UnityComponents.Common;

namespace Systems.UiSystems
{
    public class UpdateScoreSystem : IEcsRunSystem
    {
        private EcsFilter<DeadEvent> _deadEventFilter;
        private SceneData _sceneData = null;
        private int _score = 0;
        
        public void Run()
        {
            foreach (var index in _deadEventFilter)
            {
                if (_deadEventFilter.Get1(index).TargetEntity.Has<EnemyTag>())
                {
                    _score++;
                    _sceneData.Hud.ScoreCounter.text = string.Format("Score: {0}", _score);
                }
            }
        }
    }
}
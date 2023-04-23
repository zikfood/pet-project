using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class CardsSpawnerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;
        private Vector3 _spawnPosition;
        
        private int _operativesCount;

        public void Init()
        {

        }

        public void Run()
        {

        }
    }
}
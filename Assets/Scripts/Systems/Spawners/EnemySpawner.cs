using Components.Common;
using Leopotam.Ecs;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public class EnemySpawner : IEcsRunSystem, IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world = null;

        private float _spawnDelay = 5;
        private float _lastSpawnTime = 0;

        public void Init()
        {
            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.UnitPrefab,
                Position = Vector3.zero,
                Rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f),
                Parent = null
            };

            _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
            {
                Prefab = _staticData.AttackPrefab,
                Position = Vector3.up * 3,
                Rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f),
                Parent = null
            };
        }

        public void Run()
        {
            if (Time.time - _lastSpawnTime < _spawnDelay)
                return;
            
            foreach (var transform in _sceneData.EnemySpawnTransforms)
            {
                _world.NewEntity().Get<SpawnPrefab>() = new SpawnPrefab
                {
                    Prefab = _staticData.EnemyPrefab,
                    Position = transform.position,
                    Rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f),
                    Parent = null
                };
            }
            _lastSpawnTime = Time.time;
        }
    }
}
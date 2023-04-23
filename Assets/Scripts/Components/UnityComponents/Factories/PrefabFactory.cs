using Components.Common;
using Leopotam.Ecs;
using UnityComponents.MonoLinks.Base;
using UnityEngine;

namespace UnityComponents.Factories
{
    public class PrefabFactory : MonoBehaviour
    {
        private EcsWorld _world;

        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }

        public void Spawn(SpawnPrefab spawnData)
        {
            GameObject gameObject = Instantiate(spawnData.Prefab, spawnData.Position, spawnData.Rotation, spawnData.Parent);
            if (spawnData.XScale != 0 && spawnData.YScale != 0)
                gameObject.transform.localScale = new Vector3(spawnData.XScale, spawnData.YScale, 1);
            var monoEntity = gameObject.GetComponent<MonoEntity>();
            if (monoEntity == null) 
                return;
            EcsEntity ecsEntity = _world.NewEntity();
            monoEntity.Make(ref ecsEntity);
        }
    }
}
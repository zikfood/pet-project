using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        public GameObject UnitPrefab;
        public GameObject EnemyPrefab;
        public GameObject AttackPrefab;

        public Vector3 GlobalGravitation;
        public int UnitMoveLenght;
    }
}
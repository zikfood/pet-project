using UnityEngine;

namespace UnityComponents.Common
{
    [CreateAssetMenu(menuName = "Config/CardData", fileName = "CardData", order = 1)]
    public class CardData : ScriptableObject
    {
        public string Name;
        public Sprite Background;
        public Sprite UnitImage;
    }
}
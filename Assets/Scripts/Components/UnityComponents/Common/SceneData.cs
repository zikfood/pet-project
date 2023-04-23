using System;
using System.Collections.Generic;
using UnityComponents.Factories;
using UnityEngine;
using Components.UnityComponents.UI;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        public float Velocity;
        public List<Transform> EnemySpawnTransforms;

        public Input InputSystem;
        
        public PrefabFactory Factory;

        public GameHud Hud;

        private void Awake()
        {
            InputSystem = new Input();
            InputSystem.Enable();
        }
    }
}
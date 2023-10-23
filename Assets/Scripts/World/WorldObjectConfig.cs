using System;
using UnityEngine;

namespace World
{
    [CreateAssetMenu(fileName = "Object", menuName = "World Object", order = 0)]
    public class WorldObjectConfig : ScriptableObject
    {
        [Range(-1f, 1f)] public float Speed;
        public GameObject WorldObjectPrefab;
    }
}
using UnityEditor;
using UnityEngine;

namespace Pipes
{
    [CreateAssetMenu(fileName = "Pipe", menuName = "Pipes", order = 0)]
    public class PipeConfig : ScriptableObject
    {
        public float Speed;
        public int SpawnDelay;
        public float DestenationPosX;
        public float SpawnPosX;
        public float SpawnMinY;
        public float SpawnMaxY;
    }
}
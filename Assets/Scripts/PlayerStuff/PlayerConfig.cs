using UnityEngine;

namespace PlayerStuff
{
    [CreateAssetMenu(fileName = "Player", menuName = "Players", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public float JumpForce;
        public Vector3 StartPosition;
    }
}
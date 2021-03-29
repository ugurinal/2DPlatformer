using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Player
{
    [CreateAssetMenu(menuName = "2DPlatformer/Player/Player Settings")]
    public class PlayerSettings : ScriptableObject
    {
        public float MovementSpeed;
    }
}
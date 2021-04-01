using UnityEngine;

namespace Platformer2D.PlayerInput
{
    [CreateAssetMenu(menuName = "2DPlatformer/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public float HorizontalAxis;
        public bool Jump;
    }
}
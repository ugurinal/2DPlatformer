using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        private static InputManager _instance;
        public static InputManager Instance { get; private set; }

        [SerializeField] private InputData _input;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void SetHorizontalAxis(float value)
        {
            _input.HorizontalAxis = value;
        }

        public void ResetHorizontalAxis()
        {
            _input.HorizontalAxis = 0;
        }

        public void SetJumpButton()
        {
            _input.Jump = true;
            StartCoroutine(ResetJumpButton());
        }

        private IEnumerator ResetJumpButton()
        {
            yield return new WaitForEndOfFrame();
            _input.Jump = false;
        }

        private void Update()
        {
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
                _input.ProcessInput();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2D.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerControls _inputActions;
        [SerializeField] private InputData _inputData;

        private void Awake()
        {
            _inputActions = new PlayerControls();
        }

        private void OnEnable()
        {
            _inputActions.Enable();

            _inputActions.Player.Jump.started += OnJump;
        }

        private void OnDisable()
        {
            _inputActions.Disable();
            _inputActions.Player.Jump.started -= OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            _inputData.Jump = true;
            StartCoroutine(ResetJump());
        }

        private IEnumerator ResetJump()
        {
            yield return new WaitForEndOfFrame();
            _inputData.Jump = false;
        }

        private void Update()
        {
            _inputData.HorizontalAxis = _inputActions.Player.HorizontalMovement.ReadValue<float>();
        }
    }
}
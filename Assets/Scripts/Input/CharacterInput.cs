using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.CharacterInputSystem
{
    //public class CharacterInput : MonoBehaviour
    //{
    //    [SerializeField] private InputData _inputData;
    //    private PlayerInputActions _inputActions;

    //    private void Awake()
    //    {
    //        _inputActions = new PlayerInputActions();
    //    }

    //    private void OnEnable()
    //    {
    //        _inputActions.Enable();

    //        _inputActions.Player.Jump.performed += OnJump;
    //        _inputActions.Player.Movement.performed += OnMovement;
    //    }

    //    private void OnMovement(InputAction.CallbackContext context)
    //    {
    //        var value = context.ReadValue<float>();
    //        _inputData.HorizontalAxis = value;
    //    }

    //    private void OnJump(InputAction.CallbackContext context)
    //    {
    //        _inputData.Jump = true;
    //        StartCoroutine(ResetJump());
    //    }

    //    private void OnDisable()
    //    {
    //        _inputActions.Player.Jump.performed -= OnJump;

    //        _inputActions.Disable();
    //    }

    //    private IEnumerator ResetJump()
    //    {
    //        yield return new WaitForEndOfFrame();
    //        _inputData.Jump = false;
    //    }
    //}
}
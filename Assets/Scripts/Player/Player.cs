using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.PlayerInput;

namespace Platformer2D.Player
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField] protected InputData _input;

        [SerializeField] protected float _movementSpeed;
        [SerializeField] protected float _jumpSpeed;

        protected Rigidbody2D _rb;
        protected bool isGrounded;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            MoveHorizontal();
            Jump();
        }

        private void MoveHorizontal()
        {
            _rb.velocity = new Vector2(_input.HorizontalAxis * _movementSpeed, _rb.velocity.y);
            FlipCharacter();
        }

        private void FlipCharacter()
        {
            if (_input.HorizontalAxis == 0)
                return;
            if (_input.HorizontalAxis < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
        }

        protected abstract void Jump();
    }
}
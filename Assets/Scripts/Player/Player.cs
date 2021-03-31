using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.PlayerInput;

namespace Platformer2D.Player
{
    public abstract class Player : MonoBehaviour
    {
        [Header("Input")]
        [SerializeField] protected InputData input;

        [Header("Player Movement")]
        [SerializeField] protected float movementSpeed;

        [Header("PlayerJump")]
        [SerializeField] protected float jumpSpeed;
        [SerializeField] protected LayerMask whatIsGround;

        [Header("Player Dash")]
        [SerializeField] protected float dashSpeed;
        [SerializeField] protected float gravityWhileDash;
        [SerializeField] protected bool canMoveWhileDash;

        [Header("player Surroundings")]
        [SerializeField] protected Transform groundTransform;
        [SerializeField] protected float groundCheckRadius;
        [SerializeField] protected float sideWallCheckDistance;
        [SerializeField] protected float topWallCheckDistance;

        protected Rigidbody2D rb;
        protected bool isFacingRight;
        protected bool isDashing;
        protected bool isGrounded;
        protected bool isTouchingWall;

        protected bool canMove;
        protected bool canJump;
        protected bool canDash;

        protected void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            isFacingRight = !(GetComponent<SpriteRenderer>().flipX);
            canMove = true;
            canDash = true;
        }

        protected abstract void Update();

        protected void MoveHorizontal()
        {
            if (!canMove)
                return;

            rb.velocity = new Vector2(input.HorizontalAxis * movementSpeed, rb.velocity.y);
            FlipCharacter();
        }

        private void FlipCharacter()
        {
            if (input.HorizontalAxis == 0)
                return;

            if (input.HorizontalAxis < 0)
            {
                //GetComponent<SpriteRenderer>().flipX = true;
                transform.localScale = new Vector3(-1f, 1f, 1f);
                isFacingRight = false;
            }
            else
            {
                //GetComponent<SpriteRenderer>().flipX = false;
                transform.localScale = new Vector3(1f, 1f, 1f);
                isFacingRight = true;
            }
        }

        protected abstract void Jump();

        protected abstract void Dash();

        protected void CheckGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(groundTransform.position, groundCheckRadius, whatIsGround);
            canJump = isGrounded;

            if (isGrounded)
            {
                canDash = true;
            }
        }

        protected void CheckSurroundings()
        {
            Vector2 rayDirection = isFacingRight ? Vector2.right : Vector2.left;

            bool sideWall = Physics2D.Raycast(transform.position, rayDirection, sideWallCheckDistance, whatIsGround);
            bool topWall = Physics2D.Raycast(transform.position, Vector2.up, topWallCheckDistance, whatIsGround);

            if (sideWall || topWall)
                isTouchingWall = true;
            else
                isTouchingWall = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundTransform.position, groundCheckRadius);
        }
    }
}
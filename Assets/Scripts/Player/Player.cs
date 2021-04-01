using UnityEngine;
using Platformer2D.PlayerInput;
using Platformer2D.DamageSystem;

namespace Platformer2D.Player
{
    public abstract class Player : MonoBehaviour, IDamagable
    {
        [Header("Player Input")]
        [SerializeField] protected InputData input;

        [Header("Player Movement")]
        [SerializeField] protected float movementSpeed;

        [Header("Player Jump")]
        [SerializeField] protected float jumpSpeed;

        [Header("Player Surroundings")]
        [SerializeField] protected Transform groundTransform;
        [SerializeField] protected float groundCheckRadius;
        [SerializeField] protected LayerMask whatIsGround;

        protected float sideWallCheckDistance;
        protected float topWallCheckDistance;

        protected Rigidbody2D rb;
        protected bool isFacingRight;
        protected bool isDashing;
        protected bool isGrounded;
        protected bool isTouchingWall;

        protected bool canMove;
        protected bool canJump;
        protected bool canDash;

        #region COMMON_METHODS

        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            InitializePlayer();
        }

        protected void Update()
        {
            if (Time.timeScale == 0f)
                return;

            CheckGrounded();
            CheckSurroundings();
            MoveHorizontal();
            Jump();

            if (isDashing)
            {
                Dash();
            }
        }

        protected void InitializePlayer()
        {
            sideWallCheckDistance = GetComponent<CapsuleCollider2D>().bounds.extents.x + 0.1f;
            topWallCheckDistance = GetComponent<CapsuleCollider2D>().bounds.extents.y + 0.1f;

            isFacingRight = transform.localScale.x == 1;
            canMove = true;
        }

        protected void MoveHorizontal()
        {
            if (!canMove)
                return;

            rb.velocity = new Vector2(input.HorizontalAxis * movementSpeed, rb.velocity.y);
            FlipCharacter();
        }

        protected void FlipCharacter()
        {
            if (input.HorizontalAxis == 0)
                return;

            if (input.HorizontalAxis < 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                isFacingRight = false;
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                isFacingRight = true;
            }
        }

        protected void Jump()
        {
            if (input.Jump)
            {
                if (canJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
                else
                {
                    if (canDash)
                    {
                        isDashing = true;
                        canDash = false;
                    }
                }
            }
        }

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

        public void TakeDamage(int amount)
        {
            Debug.Log("DAMAGE");
        }

        #endregion COMMON_METHODS

        #region ABSTRACT_METHODS

        protected abstract void Dash();

        protected abstract void Attack();

        #endregion ABSTRACT_METHODS

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundTransform.position, groundCheckRadius);
        }
    }
}
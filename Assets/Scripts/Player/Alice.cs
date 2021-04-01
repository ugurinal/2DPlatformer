using UnityEngine;

namespace Platformer2D.Player
{
    public class Alice : Player
    {
        [Header("Player Dash")]
        [SerializeField] protected float dashSpeed;
        [SerializeField] protected float dashTime;
        [SerializeField] protected float gravityWhileDash;
        [SerializeField] protected bool canMoveWhileDash;

        private float dashTimeLeft;

        protected override void Start()
        {
            base.Start();
            dashTimeLeft = dashTime;
        }

        protected override void Dash()
        {
            rb.gravityScale = gravityWhileDash;
            canMove = canMoveWhileDash;

            dashTimeLeft -= Time.deltaTime;

            Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
            rb.velocity = direction * dashSpeed;

            if (dashTimeLeft <= 0 || isTouchingWall)
            {
                canMove = true;
                isDashing = false;
                dashTimeLeft = dashTime;
                rb.gravityScale = 1f;
            }
        }

        protected override void Attack()
        {
            Debug.Log("ATTACK");
        }
    }   // alice
}   // namespace
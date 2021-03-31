using UnityEngine;

namespace Platformer2D.Player
{
    public class Alice : Player
    {
        [Header("Player Dash")]
        [SerializeField] protected float dashSpeed;
        [SerializeField] protected float dashTime;
        [SerializeField] protected bool canMoveWhileDash;
        [SerializeField] protected float gravityWhileDash;

        private float dashTimeLeft;

        private new void Start()
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
    }   // alice
}   // namespace
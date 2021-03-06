using UnityEngine;

namespace Platformer2D.Player
{
    public class Bob : Player
    {
        [Header("Player Dash")]
        [SerializeField] protected float dashSpeed;

        protected override void Dash()
        {
            canMove = false;

            rb.velocity = new Vector2(rb.velocity.x, -1 * dashSpeed); //direction * dashSpeed;

            if (isGrounded)
            {
                canMove = true;
                isDashing = false;
            }
        }

        protected override void Attack()
        {
            Debug.Log("ATTACK");
        }
    }   // bob
}   // namespace
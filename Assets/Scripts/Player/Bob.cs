﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Player
{
    public class Bob : Player
    {
        [SerializeField] protected float dashTime;

        private float dashTimeLeft;

        private new void Start()
        {
            base.Start();
            dashTimeLeft = dashTime;
        }

        protected override void Update()
        {
            CheckGrounded();
            MoveHorizontal();
            Jump();

            if (isDashing)
            {
                Dash();
            }
        }

        protected override void Jump()
        {
            if (input.Jump)
            {
                if (canJump)
                {
                    rb.velocity = Vector2.up * jumpSpeed;
                }
                else
                {
                    if (canDash)
                    {
                        isDashing = true;
                    }
                }
            }
        }

        protected override void Dash()
        {
            canMove = canMoveWhileDash;
            canDash = false;

            dashTimeLeft -= Time.deltaTime;

            Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
            rb.velocity = direction * dashSpeed;

            rb.gravityScale = gravityWhileDash;

            if (dashTimeLeft <= 0 || isTouchingWall)
            {
                canMove = true;
                canDash = false;
                isDashing = false;
                dashTimeLeft = dashTime;
                rb.gravityScale = 1f;
            }
        }
    }   // bob
}   // namespace
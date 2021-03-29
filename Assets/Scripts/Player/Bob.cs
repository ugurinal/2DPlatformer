using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D.Player
{
    public class Bob : Player
    {
        protected override void Jump()
        {
            _rb.velocity += new Vector2(0f, _input.JumpAxis * _jumpSpeed);
        }
    }
}
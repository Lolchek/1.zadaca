using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Ball : Sprite
    {
        /// <summary>
        /// Initial ball speed. Constant
        /// </summary>
        public const float InitialSpeed = 0.4f;
        /// <summary>
        /// Defines a factor of speed increase when bumping on the paddle.
        /// Constant
        /// </summary>
        public const float BumpSpeedIncreaseFactor = 1.01f;
        /// <summary>
        /// Defines ball size. Constant
        /// </summary>
        public const int BallSize = 50;
        /// <summary>
        /// Defines current ball speed in time.
        /// </summary>
        public float Speed { get; set; }
        /// <summary>
        /// Defines ball direction.
        /// Valid values (-1,-1), (1,1), (1,-1), (-1,1).
        /// Using Vector2 to simplify game calculation. Potentially
        /// dangerous because vector 2 can swallow other values as well.
        /// Think about creating your own, more suitable type.
        /// </summary>
        public Vector2 Direction;
        public Ball(Texture2D spriteTexture)
            : base(spriteTexture, BallSize, BallSize)
        {
            Speed = InitialSpeed;
            // Initial direction
            Direction = new Vector2(1, 1);
        }

    }
}

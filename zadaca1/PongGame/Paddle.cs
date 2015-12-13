using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Paddle : Sprite
    {
        /// <summary>
        /// Initial paddle speed. Constant
        /// </summary>
        private const float InitialSpeed = 0.9f;
        /// <summary>
        /// Paddle height. Constant
        /// </summary>
        private const int PaddleHeight = 20;
        /// <summary>
        /// Paddle width. Constant
        /// </summary>
        private const int PaddleWidth = 200;
        /// <summary>
        /// Current paddle speed in time
        /// </summary>
        public float Speed { get; set; }
        public Paddle(Texture2D spriteTexture)
            : base(spriteTexture, PaddleWidth, PaddleHeight)
        {
            Speed = InitialSpeed;
        }
        /// <summary>
        /// Overriding draw method. Masking paddle texture with black color.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Size, Color.Black);
        }
    }
}

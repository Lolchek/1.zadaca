using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    public class CollisionDetector
    {
        /// <summary>
        /// Calculates if rectangles describing two sprites
        /// are overlapping on screen.
        /// </summary>
        /// <param name="s1">First sprite</param>
        /// <param name="s2">Second sprite</param>
        /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Sprite s1, Sprite s2)
        {
             Rectangle s1Position = new Rectangle((int)s1.Position.X, (int)s1.Position.Y, (int)s1.Size.Width, (int)s1.Size.Height);
             Rectangle s2Position = new Rectangle((int)s2.Position.X, (int)s2.Position.Y, (int)s2.Size.Width, (int)s2.Size.Height);
            //bool cond = (s1.Position.X + s1.Size.Width < (s2.Position.X + s2.Size.Width) || s1.Position.X > s2.Position.X) && (s1.Position.Y + s1.Size.Height < (s2.Position.Y + s2.Size.Height) || s1.Position.Y > s2.Position.Y);
            //bool cond2 = s1.Size.Intersects(s2.Size);
            //if (cond2)
            //  return true;
            //else
            //  return false;
            return s1Position.Intersects(s2Position);
            return false;
        }

    }
}

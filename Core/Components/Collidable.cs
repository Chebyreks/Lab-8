using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab6.Core
{
    internal class Collidable: Component
    {
        public Vector2 pos_collider; // UP LEFT CORNER
        public Vector2 dimensions;
        public Movable move_comp;

        public Collidable(ref Movable move_comp, Vector2 pos, Vector2 dimensions)
        {
            this.pos_collider = pos;
            this.dimensions = new Vector2(dimensions.X, dimensions.Y);
            this.move_comp = move_comp;
        }

        override public void Update()
        {
            if (move_comp != null)
            {
                pos_collider += move_comp.velocity;
                Vector2 res_velocity = Collision.CheckCollision(Entity, this, move_comp);
                if (res_velocity.X != 0 || res_velocity.Y != 0)
                {
                    move_comp.UpdateVar(res_velocity, new Vector2(0, 0));
                }
            } else
            {
                Vector2 res_velocity = Collision.CheckCollision(Entity, this, move_comp);
            }
        }
    }
}

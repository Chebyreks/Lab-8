using Lab6.Core;
using Lab6.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab6.Objects
{
    internal class InvisibleObject : Entity
    {
        override public void Update()
        {
            foreach (Component comp in Components)
            {
                comp.Update();
            }
        }

        public InvisibleObject(String name, Vector2 pos, Vector2 dimensions) : base()
        {
            this.Name = name;
            this.Position = pos;
            Movable move_comp = null;
            Collidable coll_comp = new Collidable(ref move_comp, pos, dimensions);
            coll_comp.Added(this);
            Components.Add(coll_comp);

            Collision.InitGrid(this, coll_comp);
        }
    }
}

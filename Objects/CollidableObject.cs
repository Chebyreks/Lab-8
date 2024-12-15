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
    internal class CollidableObject: Entity
    {
        override public void Update()
        {
            foreach (Component comp in Components)
            {
                comp.Update();
            }
        }

        public CollidableObject(String name, Vector2 pos, Vector2 velocity, Texture2D texture) : base()
        {
            this.Name = name;
            this.Position = pos;
 
            Image image_comp = new Image(texture);
            image_comp.Added(this);
            Components.Add(image_comp);

            Movable movable_comp = new Movable(velocity, new Vector2(0, 0));

            Collidable coll_comp = new Collidable(ref movable_comp, pos, new Vector2 (texture.Bounds.Width, texture.Bounds.Height));
            coll_comp.Added(this);
            Components.Add(coll_comp);


            movable_comp.Added(this);
            Components.Add(movable_comp);

            Collision.InitGrid(this, coll_comp);
        }
    }
}

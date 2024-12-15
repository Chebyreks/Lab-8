using Lab6.Core;
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
    internal class PointLight:Entity
    {
        Vector2 dims;
        Color color;
        override public void Draw(ref SpriteBatch batch)
        {
            Image img = (Image)Components[0];
            img.Draw(ref batch, dims, color);
        }

        public PointLight(String name, Vector2 pos, Vector2 dims, Color color, Texture2D texture) : base()
        {
            this.Name = name;
            this.Position = pos;
            this.dims = dims;
            this.color = color;
            Image image_comp = new Image(texture);
            image_comp.Added(this);
            Components.Add(image_comp);
        }
    }
}

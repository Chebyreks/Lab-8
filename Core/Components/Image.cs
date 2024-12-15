using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;

namespace Lab6.Core
{
    internal class Image: Component
    {
        public Texture2D Texture;

        public float Getangle(Vector2 vec)
        {
            var angle = Math.Atan2(vec.Y, vec.X);   //radians
                                                      // you need to devide by PI, and MULTIPLY by 180: //degrees
            return (float)angle; //round number, avoid
        }

        public Image(Texture2D texture) 
        {
            Texture = texture;
        }

        override public void Draw(ref Microsoft.Xna.Framework.Graphics.SpriteBatch batch) 
        {
            batch.Draw(Texture, Entity.Position, Color.White);
        }

        public void Draw(ref Microsoft.Xna.Framework.Graphics.SpriteBatch batch, Vector2 dims, Color color)
        {
            Rectangle dest = new Rectangle(0, 0, (int)Texture.Width, (int)Texture.Height);
            SpriteEffects effects = SpriteEffects.None;
            Vector2 scale = dims / new Vector2((int)Texture.Width, (int)Texture.Height);
            batch.Draw(Texture, Entity.Position, dest, color, 0, new Vector2(0, 0), scale, effects, 0);
        }

        public void Draw(ref Microsoft.Xna.Framework.Graphics.SpriteBatch batch, Vector2 dims, Color color, Vector2 direction)
        {
            Rectangle dest = new Rectangle(0, 0, (int)Texture.Width, (int)Texture.Height);
            SpriteEffects effects = SpriteEffects.None;
            Vector2 scale = dims / new Vector2((int)Texture.Width, (int)Texture.Height);
            batch.Draw(Texture, Entity.Position, dest, color, Getangle(direction), new Vector2(0, 0), scale, effects, 0);
        }
    }
}

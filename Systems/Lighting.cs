using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lab6.Core;
using Lab6.Objects;

namespace Lab6.Systems
{
    internal class Lighting
    {
        Texture2D point_light_text;
        Texture2D direction_light_text;
        List<Entity> lights;

        public Lighting(Texture2D point, Texture2D direct)
        {
            point_light_text = point;
            direction_light_text = direct;
            lights = new List<Entity>();
        }

        public void Draw(ref SpriteBatch batch)
        {
            foreach (var entity in lights)
            {
                entity.Draw(ref batch);
            }
        }

        public void AddPoint(Vector2 pos, Vector2 dims, Color color)
        {
            lights.Add(new PointLight(lights.Count().ToString(), pos, dims, color, point_light_text));
        }
        public void AddDirect(Vector2 pos, Vector2 dims, Color color, Vector2 direction)
        {
            lights.Add(new Objects.DirectionalLight(lights.Count().ToString(), pos, dims, color, direction_light_text, direction));
        }
    }
}

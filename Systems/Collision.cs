using Lab6.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Lab6.Core;

namespace Lab6.Systems
{
    internal class Collision
    {
        static public SpatialGrid grid;

        static public void CreateGrid(int cell_size)
        {
            grid = new SpatialGrid(cell_size);
        }
        
        static public void InitGrid(Entity entity, Collidable coll_comp)
        {
            grid.UpdateGrid(coll_comp.pos_collider, entity);
        }

        static public bool SidesCollision(Vector2 pos1,  Vector2 pos2, Vector2 dim1, Vector2 dim2)
        {
            Vector2 center1 = pos1 + (dim1 / 2);
            Vector2 center2 = pos2 + (dim2 / 2);
            Vector2 diff = center1 - center2;
            Vector2 min_dist = (dim1 / 2) + (dim2 / 2);
            Vector2 depth;
            depth.X = diff.X > 0 ? min_dist.X - diff.X : -min_dist.X - diff.X;
            depth.Y = diff.Y > 0 ? min_dist.Y - diff.Y : -min_dist.Y - diff.Y;
            if (Math.Abs(depth.X) < Math.Abs(depth.Y))
            {
                return true;
            } else
            {
                return false;
            }
        }

        static public Vector2 CheckCollision(Entity entity, Collidable coll_comp, Movable move_comp)
        {
            grid.UpdateGrid(coll_comp.pos_collider, entity);
            List<Entity> neighbours = grid.hash_dict[grid.objects[entity]];
            Vector2 result_velocity = Vector2.Zero;
            Vector2 pos1 = coll_comp.pos_collider;
            Vector2 dim1 = coll_comp.dimensions;
            Vector2 pos2 = Vector2.Zero;
            Vector2 dim2 = Vector2.Zero;
            if (neighbours.Count != 1)
            {
                foreach (Entity ent in neighbours)
                {
                    if (ent != entity && move_comp != null)
                    {
                        Collidable coll_comp2 = (Collidable)ent.Components.Find(x => x.GetType() == typeof(Collidable));
                        pos2 = coll_comp2.pos_collider;
                        dim2 = coll_comp2.dimensions;
                        if (CheckAABBCollision(pos1, dim1, pos2, dim2))
                        {
                            result_velocity = new Vector2(move_comp.velocity.X, move_comp.velocity.Y);
                            if (SidesCollision(pos1, pos2, dim1, dim2))
                            {
                                result_velocity.X *= -1;
                            } else
                            {
                                result_velocity.Y *= -1;
                            }
                        }
                    }
                }
            }
            return result_velocity;
        }
        
        static public bool CheckAABBCollision(Vector2 pos1, Vector2 dim1, Vector2 pos2, Vector2 dim2)
        {
            if (pos1.X + dim1.X < pos2.X || pos2.X + dim2.X < pos1.X ||
                pos1.Y + dim1.Y < pos2.Y || pos2.Y + dim2.Y < pos1.Y)
            {
                return false;
            }
            return true;
        }
    }
}

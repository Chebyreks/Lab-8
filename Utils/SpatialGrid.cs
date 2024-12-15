using Lab6.Core;
using System;
using System.Collections.Generic;


namespace Lab6.Utils
{
    internal class SpatialGrid
    {
        public Dictionary<int, List<Entity>> hash_dict;
        public Dictionary<Entity, int> objects;
        public int cell_size;

        public SpatialGrid(int cell_size)
        {
            this.cell_size = cell_size;
            hash_dict = new Dictionary<int, List<Entity>>();
            objects = new Dictionary<Entity, int>();
        }

        public void Insert(Microsoft.Xna.Framework.Vector2 pos, Entity entity)
        {
            int key = Key(pos);
            if (hash_dict.ContainsKey(key))
            {
                hash_dict[key].Add(entity);
            }
            else
            {
                hash_dict[key] = new List<Entity> { entity };
            }
            objects[entity] = key;
        }

        public void Insert(int divx, int divy, Entity entity)
        {
            int key = Key(divx, divy);
            if (hash_dict.ContainsKey(key))
            {
                hash_dict[key].Add(entity);
            }
            else
            {
                hash_dict[key] = new List<Entity> { entity };
            }
            objects[entity] = key;
        }

        public void UpdateGrid(Microsoft.Xna.Framework.Vector2 pos, Entity entity)
        {
            if (objects.ContainsKey(entity))
            {
                hash_dict[objects[entity]].Remove(entity);
            }
            Insert(pos, entity);
        }

        public int Key(Microsoft.Xna.Framework.Vector2 pos)
        {
            int hash = ((int)Math.Floor(pos.X / cell_size) * 73856093) ^ ((int)Math.Floor(pos.Y / cell_size) * 19349663);
            return hash;
        }

        public int Key(int divX, int divY)
        {
            int hash = (divX * 73856093) ^ (divY * 19349663);
            return hash;
        }
    }
}

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
using Lab6.Utils;
using Lab6.Systems;

namespace Lab6
{


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Entity> _entities;
        Texture2D texture1;
        Texture2D texture2;
        Texture2D texture_background;
        Texture2D pointlight;
        Texture2D directlight;
        Lighting light;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            _graphics.PreferredBackBufferWidth = 1080;
            _graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            Collision.CreateGrid(1280);
            _entities.Add(new StaticObject("Background", new Vector2(0, 0), texture_background));
            light = new Lighting(pointlight, directlight);
            light.AddPoint(new Vector2(60, 120), new Vector2(512, 512), Color.White);
            light.AddPoint(new Vector2(300, 0), new Vector2(512, 512), Color.White);
            light.AddDirect(new Vector2(512, 256), new Vector2(256, 256), Color.White, new Vector2(0, 0));
            light.AddDirect(new Vector2(512, 64), new Vector2(512, 512), Color.White, new Vector2(1, 1));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _entities = new List<Entity>();

            texture1 = Content.Load<Texture2D>("shaurma1");
            texture2 = Content.Load<Texture2D>("shaurma2");
            pointlight = Content.Load<Texture2D>("dotlight");
            directlight = Content.Load<Texture2D>("vectorlight");
            texture_background = Content.Load<Texture2D>("blacksquare");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            foreach (Entity entity in _entities)
            {
                entity.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Entity entity in _entities)
            {
                entity.Draw(ref _spriteBatch);
            }
            _spriteBatch.End();
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            light.Draw(ref _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

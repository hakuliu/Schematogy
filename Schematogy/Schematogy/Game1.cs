using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Schematogy.UI;
using Schematogy.Util;

namespace Schematogy
{
    //THIS IS A SILLY MESSAGE HASGKJAGHLADSG
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MouseState mouse;
        SpriteContent mousePic;
        UI.WindowFrame window;
        Button testButton;
        Grid theGrid;
        bool rawr = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            window = new UI.WindowFrame();
            theGrid = new Grid();
            testButton = new Button();
            testButton.Bound = new Rectangle(500, 500, 100, 100);
            testButton.Enabled = true;
            testButton.HoverEnabled = true;
            testButton.PressDownEnabled = true;
            testButton.IdleTexture = "ResistorButtonIdle";
            testButton.HoverTexture = "ResistorButtonHover";
            testButton.PressedTexture = "ResistorButtonPressed";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 1024;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            UI.UIContentManager.getInstance().LoadContents(Content);
            mousePic = UI.UIContentManager.getInstance().getTexture("mouse");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Update(gameTime);
            Util.UserInputCenter.Update(this);
            testButton.Update(gameTime);
            
            mouse = Util.UserInputCenter.mouse;
            window.Update(gameTime);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            window.Draw(gameTime, spriteBatch);
            
            testButton.Draw(gameTime, spriteBatch);

            mousePic.Draw(gameTime, spriteBatch, new Rectangle(mouse.X, mouse.Y, mousePic.Width / 3, mousePic.Height / 3));


            theGrid.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

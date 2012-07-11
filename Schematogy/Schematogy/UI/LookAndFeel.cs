using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    public abstract class LookAndFeel
    {
        protected abstract void DrawTopLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBotLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBot(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBotRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawTopRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawTop(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawCenter(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);

        public void drawBorder(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds)
        {
            this.DrawCenter(gameTime, spriteBatch, bounds);
            this.DrawBot(gameTime, spriteBatch, bounds);
            this.DrawLeft(gameTime, spriteBatch, bounds);
            this.DrawRight(gameTime, spriteBatch, bounds);
            this.DrawTop(gameTime, spriteBatch, bounds);
            this.DrawTopLeft(gameTime, spriteBatch, bounds);
            this.DrawTopRight(gameTime, spriteBatch, bounds);
            this.DrawBotLeft(gameTime, spriteBatch, bounds);
            this.DrawBotRight(gameTime, spriteBatch, bounds);
        }
    }
}

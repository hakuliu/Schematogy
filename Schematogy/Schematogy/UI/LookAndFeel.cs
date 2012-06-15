using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    public abstract class LookAndFeel
    {
        protected abstract void DrawTopLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBotLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBot(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawBotRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawTopRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawTop(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);
        protected abstract void DrawCenter(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds);

        public void drawBorder(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Rectangle bounds)
        {
            this.DrawBot(spriteBatch, bounds);
            this.DrawBotLeft(spriteBatch, bounds);
            this.DrawBotRight(spriteBatch, bounds);
            this.DrawLeft(spriteBatch, bounds);
            this.DrawRight(spriteBatch, bounds);
            this.DrawTop(spriteBatch, bounds);
            this.DrawTopLeft(spriteBatch, bounds);
            this.DrawTopRight(spriteBatch, bounds);
            this.DrawCenter(spriteBatch, bounds);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Schematogy.Util;

namespace Schematogy.UI
{
    class BasicLookAndFeel : LookAndFeel
    {
        protected override void DrawTopLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("CornerChunkUpperLeft"));
            Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X, bounds.Y, Image.Width, Image.Height));
        }

        protected override void DrawLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("BorderChunkLeft"));
            int TileCount = (int)(bounds.Height / Image.Height);
            for (int i = 0; i < TileCount; i++)
            {
                Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X, bounds.Y + i * Image.Height, Image.Width, Image.Height));
            }
        }

        protected override void DrawBotLeft(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("CornerChunkLowerLeft"));
            Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height));
        }

        protected override void DrawBot(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            //Borders: find distance, edge length % tile length = # of times to tile 
            SpriteContent Image = (UIContentManager.getInstance().getTexture("BorderChunkBottom"));
            int TileCount = bounds.Width / Image.Width;
            for (int i = 1; i < TileCount; i++)
            {
                Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X + i * Image.Width, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height));
            }
        }

        protected override void DrawBotRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("CornerChunkLowerRight"));
            Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height));
        }

        protected override void DrawRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("BorderChunkRight"));
            int TileCount = (int)(bounds.Height / Image.Height);
            for (int i = 0; i < TileCount; i++)
            {
                Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y + i * Image.Height, Image.Width, Image.Height));
            }
        }

        protected override void DrawTopRight(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("CornerChunkUpperRight"));
            Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y, Image.Width, Image.Height));
        }

        protected override void DrawTop(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("BorderChunkTop"));
            int TileCount = bounds.Width / Image.Width;
            for (int i = 1; i < TileCount; i++)
            {
                Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X + i * Image.Width, bounds.Y, Image.Width, Image.Height));
            }
        }

        protected override void DrawCenter(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            SpriteContent Image = (UIContentManager.getInstance().getTexture("BigChunk"));
            Image.Draw(gameTime, spriteBatch, new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height));
        }
    }
}

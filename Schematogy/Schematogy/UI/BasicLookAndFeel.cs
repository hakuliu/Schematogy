using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    class BasicLookAndFeel : LookAndFeel
    {
        protected override void DrawTopLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("CornerChunkUpperLeft"));
            spriteBatch.Draw(Image, new Rectangle(bounds.X, bounds.Y, Image.Width, Image.Height), new Rectangle(0, Image.Height, Image.Width, -Image.Height), Color.White);
        }

        protected override void DrawLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("BorderChunkLeft"));
            int TileCount = (int)(bounds.Height / Image.Height);
            for (int i = 0; i < TileCount; i++)
            {
                spriteBatch.Draw(Image, new Rectangle(bounds.X, bounds.Y + i * Image.Height, Image.Width, Image.Height), Color.White);
            }
        }

        protected override void DrawBotLeft(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("CornerChunkLowerLeft"));
            spriteBatch.Draw(Image, new Rectangle(bounds.X, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height), Color.White);
        }

        protected override void DrawBot(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            //Borders: find distance, edge length % tile length = # of times to tile 
            Texture2D Image = (UIContentManager.getInstance().getTexture("BorderChunkBottom"));
            int TileCount = bounds.Width / Image.Width;
            for (int i = 1; i < TileCount; i++)
            {
                spriteBatch.Draw(Image, new Rectangle(bounds.X + i * Image.Width, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height), Color.White);
            }
        }

        protected override void DrawBotRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("CornerChunkLowerRight"));
            spriteBatch.Draw(Image, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y + bounds.Height - Image.Height, Image.Width, Image.Height), new Rectangle(Image.Width, 0, -Image.Width, Image.Height), Color.White);
        }

        protected override void DrawRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("BorderChunkRight"));
            int TileCount = (int)(bounds.Height / Image.Height);
            for (int i = 0; i < TileCount; i++)
            {
                spriteBatch.Draw(Image, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y + i * Image.Height, Image.Width, Image.Height), Color.White);
            }
        }

        protected override void DrawTopRight(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("CornerChunkUpperRight"));
            spriteBatch.Draw(Image, new Rectangle(bounds.X + bounds.Width - Image.Width, bounds.Y, Image.Width, Image.Height), new Rectangle(Image.Width, Image.Height, -Image.Width, -Image.Height), Color.White);
        }

        protected override void DrawTop(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("BorderChunkTop"));
            int TileCount = bounds.Width / Image.Width;
            for (int i = 1; i < TileCount; i++)
            {
                spriteBatch.Draw(Image, new Rectangle(bounds.X + i * Image.Width, bounds.Y, Image.Width, Image.Height), Color.White);
            }
        }

        protected override void DrawCenter(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Microsoft.Xna.Framework.Rectangle bounds)
        {
            Texture2D Image = (UIContentManager.getInstance().getTexture("BigChunk"));
            spriteBatch.Draw(Image, new Rectangle(bounds.X , bounds.Y, bounds.Width, bounds.Height), Color.White);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Schematogy.Util;
using Microsoft.Xna.Framework.Input;

namespace Schematogy
{
    class Grid : Util.Drawable, Util.Updatable
    {
        int cellSizeX = 64;
        int cellSizeY = 64;
        int sizeX = 16;
        int sizeY = 10;
        Rectangle bounds;
        Location2i highlightedGrid;

        public Grid()
        {
            bounds = new Rectangle(538, 175, 850, 520);
            cellSizeX = bounds.Width / sizeX;
            cellSizeY = bounds.Height / sizeY;
            highlightedGrid = new Location2i();
            
        }



        #region Drawable Members

        public void Draw(GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            SpriteContent gridIdle = UI.UIContentManager.getInstance().getTexture("GridIdle");
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Rectangle dest = new Rectangle(bounds.X + x * cellSizeX, bounds.Y + y * cellSizeY, cellSizeX, cellSizeY);
                    gridIdle.Draw(game, spriteBatch, dest);
                }
            }

            SpriteContent gridHover = UI.UIContentManager.getInstance().getTexture("GridHover");
            Rectangle dest2 = new Rectangle(bounds.X + highlightedGrid.X * cellSizeX, bounds.Y + highlightedGrid.Y * cellSizeY, cellSizeX, cellSizeY);
            gridHover.Draw(game, spriteBatch, dest2);
        }

        #endregion




        #region Updatable Members

        public void Update(GameTime gameTime)
        {
            MouseState mousePoller = Util.UserInputCenter.mouse;

            int x = mousePoller.X;
            int y = mousePoller.Y;

            x -= this.bounds.X;
            y -= this.bounds.Y;

            x /= this.cellSizeX;
            y /= this.cellSizeY;

            if (x < 0)
            {
                x = 0;
            }
            if (y < 0)
            {
                y = 0;
            }
            if (x >= sizeX)
            {
                x = sizeX - 1;
            }
            if (y >= sizeY)
            {
                y = sizeY - 1;
            }

            highlightedGrid = new Location2i(x, y);
        }

        #endregion
    }
}

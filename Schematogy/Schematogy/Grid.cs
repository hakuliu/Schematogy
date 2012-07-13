using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Schematogy.Util;

namespace Schematogy
{
    class Grid : Util.Drawable
    {
        int cellSizeX = 64;
        int cellSizeY = 64;
        int sizeX = 8;
        int sizeY = 4;
        Rectangle bounds;


        public Grid()
        {
            bounds = new Rectangle(500, 200, 8 * 100,  4 * 100);
            cellSizeX = bounds.Width / sizeX;
            cellSizeY = bounds.Height / sizeY;
        }



        #region Drawable Members

        public void Draw(GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            SpriteContent gridIdle = UI.UIContentManager.getInstance().getTexture("GridIdle");
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Rectangle dest = new Rectangle(bounds.X + x * cellSizeX, bounds.Y + y * cellSizeX, cellSizeX, cellSizeX);
                    gridIdle.Draw(game, spriteBatch, dest);
                }
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schematogy.Util;

namespace Schematogy.UI
{
    class WindowFrame : Container, Util.Drawable
    {

        #region Drawable Members


        private static Rectangle minSize = new Rectangle(0, 0, 32 * 2, 32 * 2);


        public void Draw(Microsoft.Xna.Framework.GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Rectangle bounds = Bounds;
            Texture2D kitteh = UIContentManager.getInstance().getTexture("rawr");

            //delete this later and use the methods.
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X, bounds.Y, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X + 32, bounds.Y, 128, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X + 32 + 128, bounds.Y, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X, bounds.Y + 32, 32, 64), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X, bounds.Y + 32 + 64, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X + 32, bounds.Y + 32 + 64, 128, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X + 32 + 128, bounds.Y + 32 + 64, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(bounds.X + 32 + 128, bounds.Y + 32, 32, 64), Color.White);

        }

        #endregion

        public WindowFrame()
        {
            Bounds = new Rectangle(50, 50, 200, 100);
        }


        private void DrawTopLeft()
        {
        }

        
        
    }
}

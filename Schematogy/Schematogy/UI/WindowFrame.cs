using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schematogy.Util;

namespace Schematogy.UI
{
    class WindowFrame : Util.Drawable, Util.Locatable
    {

        #region Drawable Members


        private static const Rectangle minSize = new Rectangle(0, 0, 32 * 2, 32 * 2);

        //test values, will be included in locatable soon.
        private Location2i loc;
        private Rectangle boundary;


        public void Draw(Microsoft.Xna.Framework.GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //MAGIC VALUES THAT SHOULD REALLY BE CHANGED LATER BUT I WANT TO SEE WINDOWS RIGHT NOW DAMN IT.
            Texture2D kitteh = UIContentManager.getInstance().getTexture("rawr");

            spriteBatch.Draw(kitteh, new Rectangle(x, y, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x + 32, y, 128, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x + 32 + 128, y, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x, y + 32, 32, 64), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x, y + 32 + 64, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x + 32, y + 32 + 64, 128, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x + 32 + 128, y + 32 + 64, 32, 32), Color.White);
            spriteBatch.Draw(kitteh, new Rectangle(x + 32 + 128, y + 32, 32, 64), Color.White);

        }

        #endregion

        #region Locatable Members

        public Schematogy.Util.Location2i Loc
        {
            get { return loc;  }
        }

        #endregion

        public WindowFrame()
        {
            loc = new Location2i(50, 50);
        }

        
    }
}

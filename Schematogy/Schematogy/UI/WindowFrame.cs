using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schematogy.UI
{
    class WindowFrame : Util.Drawable
    {

        #region Drawable Members


        //test values, will be included in locatable soon.
        int x = 50;
        int y = 50;


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
    }
}

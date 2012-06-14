using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;


namespace Schematogy.Util
{
    interface Drawable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch">begin should have been called by now.</param>
        void Draw(GameTime game, SpriteBatch spriteBatch);
    }
}

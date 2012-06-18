using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schematogy.UI
{
    abstract class Component : Util.Updatable
    {

        #region Updatable Members

        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        #endregion
    }
}

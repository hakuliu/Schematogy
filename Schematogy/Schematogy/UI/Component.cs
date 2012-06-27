using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    public abstract class Component : Util.Updatable, Util.Bounded, Util.Drawable
    {
        private Rectangle bounds;
        private bool enabled;
        #region Updatable Members

        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        #endregion


        #region Drawable Members

        public abstract void Draw(GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);

        #endregion

        public Component()
        {
            this.initialize(new Rectangle(0, 0, 0, 0));
        }
        public Component(Rectangle b)
        {
            this.initialize(b);
        }
        public void initialize(Rectangle b)
        {
            this.bounds = b;
        }

        public Rectangle Bound { get { return bounds; } set { bounds = value; } }
        public bool Enabled { get { return enabled; } set { enabled = value; } }

    }
}

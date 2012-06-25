using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Schematogy.Util;
using Microsoft.Xna.Framework.Input;

namespace Schematogy.UI
{
    class WindowFrame : Container, Util.Drawable, UI.Draggable
    {

        #region Drawable Members


        private static Rectangle minSize = new Rectangle(0, 0, 32 * 2, 32 * 2);
        private LookAndFeel lnf;

        private bool isInMovableBounds(int x, int y)
        {
            Rectangle realBound = new Rectangle(bounds.X + movableBounds.X, bounds.Y + movableBounds.Y, movableBounds.Width, movableBounds.Height);
            if (x >= this.bounds.X && x <= this.bounds.X + bounds.Width)
            {
                if (y >= bounds.Y && y <= bounds.Y + bounds.Height)
                {
                    return true;
                }
            }
            return false;
        }


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

            try
            {
                lnf.drawBorder(spriteBatch, bounds);
            }
            catch (NotImplementedException e)
            {
                //Console.WriteLine("You haven't implemented lnf yet!");
            }
        }

        #endregion

        
        //the following are for moving the window.
        //from the top left of the bounds.
        Rectangle movableBounds = new Rectangle(0, 0, 200, 100);
        bool moving = false;

        public WindowFrame()
        {
            Bounds = new Rectangle(50, 50, 200, 100);
            this.setupListeners();
            this.SetLookAndFeel(new BasicLookAndFeel());
        }

        public void SetLookAndFeel(LookAndFeel feel)
        {
            this.lnf = feel;
        }


        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Util.UserInputCenter.mouse;
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                
                if (isInMovableBounds(mouse.X, mouse.Y))
                {
                    Console.WriteLine("moving!");
                }
            }
        }

        #region Draggable Members

        public Rectangle MovableBounds
        {
            get { return movableBounds; }
        }

        public Rectangle MovingBounds
        {
            set { this.bounds = value; }
        }

        public bool Moving
        {
            get
            {
                return moving;
            }
            set
            {
                moving = value;
            }
        }

        public void handleDraggableMouseMotionEvent(MouseMotionEvent e)
        {
            if (Moving)
            {
                this.Bounds = new Rectangle(this.Bounds.X + e.DX, this.Bounds.Y + e.DY, this.Bounds.Width, this.Bounds.Height);
            }
        }

        public void handleDraggableMouseEvent(MouseEvent e)
        {
            if (e.Pressed == ButtonState.Pressed)
            {
                if (!Moving && isInMovableBounds(e.X, e.Y))
                {
                    Moving = true;
                }
            }
            else
            {
                Moving = false;
            }
        }

        public void setupListeners()
        {
            GameEventManager.Instance.addHandler<MouseEvent>(new GameEventHandler<MouseEvent>(handleDraggableMouseEvent));
            GameEventManager.Instance.addHandler<MouseMotionEvent>(new GameEventHandler<MouseMotionEvent>(handleDraggableMouseMotionEvent));
        }

        #endregion
    }
}

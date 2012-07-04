using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Schematogy.UI
{
    public class Button : Component
    {
        private Rectangle bound;

        private bool hoverEnabled = false;
        private bool pressDownEnabled = false;
        private String idleTexture = "MissingImageButton";
        private String hoverTexture = "MissingImageButton";
        private String pressedTexture = "MissingImageButton";

        private enum MyButtonState { Idle, Hover, Pressed };
        private MyButtonState imgState;

        public Button()
        {
            imgState = MyButtonState.Idle;

            GameEventManager.Instance.addHandler<MouseMotionEvent>(new GameEventHandler<MouseMotionEvent>(handleButtonMouseMotionAction));
            GameEventManager.Instance.addHandler<MouseEvent>(new GameEventHandler<MouseEvent>(handleButtonMouseAction));
        }


        private void handleButtonMouseAction(MouseEvent e)
        {
            if (this.PressDownEnabled && e.Pressed == Microsoft.Xna.Framework.Input.ButtonState.Pressed && isInBounds(e.X, e.Y))
            {
                imgState = MyButtonState.Pressed;
            }
            else if(this.HoverEnabled && isInBounds(e.X, e.Y))
            {
                imgState = MyButtonState.Hover;
            }
            else if (!this.HoverEnabled)
            {
                imgState = MyButtonState.Idle;
            }
        }
        private void handleButtonMouseMotionAction(MouseMotionEvent e) 
        {
            if (this.HoverEnabled)
            {
                if (isInBounds(e.X, e.Y))
                {
                    imgState = MyButtonState.Hover;
                }
                else
                {
                    imgState = MyButtonState.Idle;
                }
            }
        }
        private bool isInBounds(int x, int y)
        {
            if(x >= this.Bound.X && x <= this.Bound.X + this.Bound.Width) 
            {
                if (y >= this.Bound.Y && y <= this.Bound.Y + this.Bound.Height)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HoverEnabled { get { return hoverEnabled; } set { hoverEnabled = value; } }
        public bool PressDownEnabled { get { return pressDownEnabled; } set { pressDownEnabled = value; } }
        public String IdleTexture { get { return idleTexture; } set { idleTexture = value; } }
        public String HoverTexture { get { return hoverTexture; } set { hoverTexture = value; } }
        public String PressetTexture { get { return pressedTexture; } set { pressedTexture = value; } }

        public override void Update(GameTime gameTime)
        {
            //do nothing...?
        }

        public override void Draw(GameTime game, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            Texture2D imgToDraw = UIContentManager.getInstance().getTexture(IdleTexture);
            if (imgState == MyButtonState.Idle)
            {
                imgToDraw = UIContentManager.getInstance().getTexture(IdleTexture);
            }
            else if (imgState == MyButtonState.Hover && HoverEnabled)
            {
                imgToDraw = UIContentManager.getInstance().getTexture(HoverTexture);
            }
            else if (imgState == MyButtonState.Pressed && PressDownEnabled)
            {
                imgToDraw = UIContentManager.getInstance().getTexture(PressetTexture);
            }

            spriteBatch.Draw(imgToDraw, Bound, Color.White); 
        }
    }
}

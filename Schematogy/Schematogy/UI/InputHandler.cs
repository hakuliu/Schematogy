using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Schematogy.UI;

namespace Schematogy.UI
{

   /// <summary>
    /// this class will actually get all the user input from the game, and pass it along as events to all the components of the game.
    /// This part of the game will give out the state indescriminently.  Later in the Event handler, it'll be a little better in that it'll have rudeness.
    /// 
    /// This class has a dual function.  it will pass the controller state to any that's subscribed...AND it'll create UI events to the event manager, which will handle the events.
    /// </summary>
    /// <remarks>
    /// please refer to http://www.riemers.net/eng/Tutorials/XNA/Csharp/Series2D/Keyboard_input.php for how to handle events frok things like keyboard.
    /// </remarks>
    class InputHandler
    {
        private ButtonState lastLeftPressed;
        private ButtonState lastRightPressed;
        private ButtonState lastMiddlePressed;
        private int lastMouseX;
        private int lastMouseY;
        private int lastScroll;
        private HashSet<Keys> lastKeysPressed;
        private List<ReceivesUI> subscribers;
        private InputHandler()
        {
            subscribers = new List<ReceivesUI>();
            lastKeysPressed = new HashSet<Keys>();
        }
        public void subscribe(ReceivesUI subscriber)
        {
            subscribers.Add(subscriber);
        }
        public void Update(GameTime gameTime)
        {
            //states of user inputs
            KeyboardState keyState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            //figure out the MouseState
            if (lastLeftPressed != mouseState.LeftButton)
            {
                //make a mouseEvent
                GameEventManager.Instance.passEvent<MouseEvent>(new MouseEvent(mouseState.LeftButton, mouseState.X, mouseState.Y, MouseButton.LEFT_BUTTON));
                //pass it on to the event handler
                //to be implemented
            }
            if (lastRightPressed != mouseState.RightButton)
            {
                GameEventManager.Instance.passEvent<MouseEvent> ( new MouseEvent(mouseState.RightButton, mouseState.X, mouseState.Y, MouseButton.RIGHT_BUTTON));
            }
            if (lastMiddlePressed != mouseState.MiddleButton)
            {
                GameEventManager.Instance.passEvent<MouseEvent>( new MouseEvent(mouseState.MiddleButton, mouseState.X, mouseState.Y, MouseButton.MIDDLE_BUTTON));
            }

            //reset the mouse button states.
            lastLeftPressed = mouseState.LeftButton;
            lastRightPressed = mouseState.RightButton;
            lastMiddlePressed = mouseState.MiddleButton;


            //figure out the MouseMotionState
            if (lastMouseX != mouseState.X | lastMouseY != mouseState.Y | lastScroll != mouseState.ScrollWheelValue)
            {
                GameEventManager.Instance.passEvent<MouseMotionEvent>( new MouseMotionEvent(mouseState.X, mouseState.Y, mouseState.ScrollWheelValue, mouseState.X - lastMouseX, mouseState.Y - lastMouseY, mouseState.ScrollWheelValue - lastScroll));
            }
            //reset the mouse motion states for next update.
            lastMouseX = mouseState.X;
            lastMouseY = mouseState.Y;
            lastScroll = mouseState.ScrollWheelValue;

            //seems like since this is a method, it's probably a good idea to only call it once.
            Keys[] pressed = keyState.GetPressedKeys();
            //need to keep a collection of the old...
            foreach(Keys k in pressed)
            {
                if (lastKeysPressed.Contains(k))
                {
                    //this means the ButtonState hasn't changed and it's still pressed.
                    lastKeysPressed.Remove(k);
                }
                else
                {
                    //this means that it's the first time this key has been pressed, so create an event!
                    GameEventManager.Instance.passEvent<KeyboardEvent>(new KeyboardEvent(ButtonState.Pressed, k));
                }
            }
            //now all the keys left in lastKeyPressed are the ones that have been released.
            foreach (Keys k in lastKeysPressed)
            {
                //make event for key being released
                GameEventManager.Instance.passEvent<KeyboardEvent>(new KeyboardEvent(ButtonState.Released, k));
            }
            
            //reset the keys
            lastKeysPressed.Clear();
            lastKeysPressed.UnionWith(pressed);

            foreach(ReceivesUI component in subscribers) {
                component.ReceiveUI(keyState, mouseState);
            }

            
        }
        //decided to make the class a Singleton.
        private static InputHandler instance;
        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }
    }
}
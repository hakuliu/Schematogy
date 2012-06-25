using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Schematogy.UI
{
    class GameEventManager
    {
        //these are all the event handler queues.
        private GameEventHandlerQueue<MouseEvent> QMouseEvent;
        private GameEventHandlerQueue<MouseMotionEvent> QMouseMotionEvent;
        private GameEventHandlerQueue<KeyboardEvent> QKeyboardEvent;

        public GameEventManager()
        {
            QMouseEvent = new GameEventHandlerQueue<MouseEvent>();
            QMouseMotionEvent = new GameEventHandlerQueue<MouseMotionEvent>();
            QKeyboardEvent = new GameEventHandlerQueue<KeyboardEvent>();
        }

        public void addHandler<T>(GameEventHandler<T> h) where T : GameEvent
        {
            if (h is GameEventHandler<MouseEvent>)
            {
                QMouseEvent.addHandler(h as GameEventHandler<MouseEvent>);
            }
            else if (h is GameEventHandler<MouseMotionEvent>)
            {
                QMouseMotionEvent.addHandler(h as GameEventHandler<MouseMotionEvent>);
            }
            else if (h is GameEventHandler<KeyboardEvent>)
            {
                QKeyboardEvent.addHandler(h as GameEventHandler<KeyboardEvent>);
            }
            else
            {
                throw new Exception("GameEventManager.addHandler Could not recognize that event type.");
            }
        }
        public void removeHandler<T>(GameEventHandler<T> h) where T : GameEvent
        {
            if (h is GameEventHandler<MouseEvent>)
            {
                QMouseEvent.removeHandler(h as GameEventHandler<MouseEvent>);
            }
            else if (h is GameEventHandler<MouseMotionEvent>)
            {
                QMouseMotionEvent.removeHandler(h as GameEventHandler<MouseMotionEvent>);
            }
            else if (h is GameEventHandler<KeyboardEvent>)
            {
                QKeyboardEvent.removeHandler(h as GameEventHandler<KeyboardEvent>);
            }
            else
            {
                throw new Exception("GameEventManager.removeHandler could not recognize that event type.");
            }
        }

        public void passEvent<T>(T e) where T : GameEvent
        {
            if (e is MouseEvent)
            {
                QMouseEvent.fire(e as MouseEvent);
            }
            else if (e is MouseMotionEvent)
            {
                QMouseMotionEvent.fire(e as MouseMotionEvent);
            }
            else if (e is KeyboardEvent)
            {
                QKeyboardEvent.fire(e as KeyboardEvent);
            }
            else
            {
                throw new Exception("An unknown Event type has been passed into the EventManager.");
            }
        }

        //EventManger is also a singleton state.
        private static GameEventManager instance;
        public static GameEventManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameEventManager();
                }
                return instance;
            }
        }
        private class GameEventHandlerQueue<T> where T : GameEvent
        {
            HashSet<GameEventHandler<T>> queue;
            public GameEventHandlerQueue()
            {
                queue = new HashSet<GameEventHandler<T>>();
            }
            public void addHandler(GameEventHandler<T> h)
            {
                this.queue.Add(h);
            }
            public void removeHandler(GameEventHandler<T> h)
            {
                this.queue.Remove(h);//don't really care if it failed to remove because it wasn't in the list.
            }
            public void fire(T e)
            {
                //should be done in sorted order.
                foreach (GameEventHandler<T> h in queue)
                {
                    h.fire(e);
                }
            }
        }
    }
}

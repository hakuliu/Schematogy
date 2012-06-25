using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schematogy.UI
{
    /// <summary>
    /// this is the delegate which will be called when an event happens.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="e"></param>
    /// <returns></returns>
    public delegate bool HandlerDelegate<T>(T e) where T : GameEvent;
    /// <summary>
    /// a class wrapper for the handler...because i wanted priorities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GameEventHandler<T> : IComparable<GameEventHandler<T>> where T : GameEvent
    {
        private int priority;
        private HandlerDelegate<T> del;
        
        

        int Priority
        {
            get { return priority; }
        }
        public GameEventHandler(HandlerDelegate<T> handler, int priority)
        {
            this.priority = priority;
            this.del = handler;
        }

        public bool fire(T e)
        {
            if (del != null)
                return del(e);
            return false;
        }



        public int CompareTo(GameEventHandler<T> other)
        {
            return this.priority - other.priority;
        }
    }

    
}

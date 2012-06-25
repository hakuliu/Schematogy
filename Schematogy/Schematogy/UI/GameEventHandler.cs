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
    public delegate void HandlerDelegate<T>(T e) where T : GameEvent;
    /// <summary>
    /// a class wrapper for the handler...because i wanted priorities.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GameEventHandler<T> where T : GameEvent
    {
        
        private HandlerDelegate<T> del;
        
        
        public GameEventHandler(HandlerDelegate<T> handler)
        {
            
            this.del = handler;
        }

        public void fire(T e)
        {
            if (del != null)
                del(e);
            
        }

    }

    
}

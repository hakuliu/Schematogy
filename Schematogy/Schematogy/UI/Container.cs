using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    abstract class Container
    {
        protected Rectangle bounds;

        protected List<Component> components;


        public Rectangle Bounds 
        {
            get { return bounds; }
            set { bounds = value; }
        }
    }
}

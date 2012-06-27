using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.Util
{
    interface Bounded
    {
        Rectangle Bound { get; set; }
    }
}

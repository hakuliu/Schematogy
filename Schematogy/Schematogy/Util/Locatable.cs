using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schematogy.Util
{
    /// <summary>
    /// something that has a location, obviously.
    /// default on integer. not really even sure we'll ever need floats for this game...XD
    /// </summary>
    interface Locatable
    {
        Location2i Loc
        {
            get;
        }
    }
}

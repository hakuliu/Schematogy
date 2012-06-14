using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Schematogy.Util
{
    interface IsAContentManager
    {
        void LoadContents(ContentManager Content);

        void UnloadContents(ContentManager Content);
    }
}

using System;
using System.Collections.Generic;

namespace _Scripts.Utils
{
    [Serializable]
    public class TagsSettings
    {
        [TagSelector] public string PlayerTag;
        [TagSelector] public string WallTag;
        [TagSelector] public string PlayerHoleTag;
    }
}
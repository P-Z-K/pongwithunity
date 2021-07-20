using System;
using System.Collections.Generic;

namespace _Scripts.Utils
{
    [Serializable]
    public class TagsSettings
    {
        [TagSelector] public string PlayerPongBatTag;
        [TagSelector] public string WallTag;
        [TagSelector] public string PlayerHoleTag;
        [TagSelector] public string MainCameraTag;
    }
}
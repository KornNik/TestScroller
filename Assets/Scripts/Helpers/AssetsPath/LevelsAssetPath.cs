﻿using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class LevelsAssetPath
    {
        #region Fields

        public static readonly Dictionary<LevelTypes, string> LevelsPath = new Dictionary<LevelTypes, string>
        {
            {
                LevelTypes.First, "Prefabs/Levels/Prefabs_Levels_First"
            }

        };

        #endregion
    }
}
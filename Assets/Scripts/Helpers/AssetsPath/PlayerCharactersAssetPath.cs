using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class PlayerCharactersAssetPath
    {
        #region Fields

        public static readonly Dictionary<PlayerCharacterTypes, string> CharactersPath = new Dictionary<PlayerCharacterTypes, string>
        {
            {
                PlayerCharacterTypes.Gunner, "Prefabs/Characters/Players/Prefabs_Characters_Players_Gunner"
            }

        };

        #endregion
    }
}
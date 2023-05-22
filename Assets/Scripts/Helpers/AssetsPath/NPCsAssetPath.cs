using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class NPCsAssetPath
    {
        #region Fields

        public static readonly Dictionary<NPCTypes, string> NPCsPath = new Dictionary<NPCTypes, string>
        {
            {
                NPCTypes.Zombie, "Prefabs/Characters/Enemies/Prefabs_Characters_Enemies_Zombie"
            },
            {
                NPCTypes.Thing, "Prefabs/Characters/Enemies/Prefabs_Characters_Enemies_Thing"
            }

        };

        #endregion
    }
}
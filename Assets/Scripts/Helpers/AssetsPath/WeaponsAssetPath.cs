using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    sealed class WeaponsAssetPath
    {
        public static readonly Dictionary<WeaponType, string> WeaponsPath = new Dictionary<WeaponType, string>
        {
            {
                WeaponType.Melee, "Prefabs/Items/Weapons/Prefabs_Items_Weapons_Melee"
            },
            {
                WeaponType.Pistol, "Prefabs/Items/Weapons/Prefabs_Items_Weapons_Pistol"
            },
            {
                WeaponType.Rifle, "Prefabs/Items/Weapons/Prefabs_Items_Weapons_Rifle"
            }

        };
    }
}

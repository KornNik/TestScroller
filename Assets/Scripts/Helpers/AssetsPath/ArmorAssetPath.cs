using System.Collections.Generic;
using SideScroller.Helpers.Types;

namespace SideScroller.Helpers.AssetsPath
{
    class ArmorAssetPath
    {
        public static readonly Dictionary<ArmorTypes, string> ArmorsPath = new Dictionary<ArmorTypes, string>
        {
            {
                ArmorTypes.BooletProofCloack, "Prefabs/Items/Armors/Prefabs_Items_Armors_BooletProofCloack"
            },
            {
                ArmorTypes.BooletProofLeg, "Prefabs/Items/Armors/Prefabs_Items_Armors_BooletProofLeg"
            },
            {
                ArmorTypes.BooletProofHand, "Prefabs/Items/Armors/Prefabs_Items_Armors_BooletProofHand"
            },
            {
                ArmorTypes.BooletProofHeadGear, "Prefabs/Items/Armors/Prefabs_Items_Armors_BooletProofHead"
            }
        };
    }
}

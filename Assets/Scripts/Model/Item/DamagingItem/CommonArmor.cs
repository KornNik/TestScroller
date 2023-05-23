using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Model.Item
{
    class CommonArmor : BaseItem
    {
        [SerializeField] protected ArmorPlaceTypes _armorType;

        public ArmorPlaceTypes ArmorType => _armorType;

        protected override void Awake()
        {
            base.Awake();
        }
    }
}

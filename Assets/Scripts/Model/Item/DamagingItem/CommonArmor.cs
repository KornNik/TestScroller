using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Model.Item
{
    class CommonArmor : BaseItem
    {
        #region Fields

        [SerializeField] protected ArmorPlaceTypes _armorType;

        #endregion


        #region Properties

        public ArmorPlaceTypes ArmorType => _armorType;

        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
        }

        #endregion
    }
}

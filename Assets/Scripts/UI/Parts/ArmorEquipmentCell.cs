using UnityEngine;
using SideScroller.Model.Item;
using UnityEngine.EventSystems;
using SideScroller.Helpers.Types;

namespace SideScroller.UI.Parts
{
    class ArmorEquipmentCell : ItemCell
    {
        [SerializeField] private ArmorPlaceTypes _armorType;

        public ArmorPlaceTypes ArmorType => _armorType;


        #region IPointerClickHandler

        public override void OnPointerClick(PointerEventData pointerEventData)
        {
            if (_item is BaseItem)
            {
                _characterMenu.EquipmentUI.EquipmentItemClick?.Invoke(_item);
            }
        }

        #endregion
    }
}

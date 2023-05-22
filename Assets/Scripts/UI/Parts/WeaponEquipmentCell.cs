﻿using SideScroller.Model.Item;
using UnityEngine.EventSystems;

namespace SideScroller.UI.Parts
{
    class WeaponEquipmentCell : ItemCell
    {

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

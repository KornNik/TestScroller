using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.Helpers;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Model.Unit;

namespace SideScroller.Model.Inventory
{
    class BaseInventory : IListenerScreen
    {
        private BaseUnit _unit;
        private BaseItem[] _itemsInBag;

        protected CharacterEquipmentUI _equipmentUI;
        protected CharacterInventoryUI _inventoryUI;

        public BaseItem[] ItemList => _itemsInBag;


        #region ClassLifeCycle

        public BaseInventory(BaseUnit unit)
        {
            _unit = unit;
            _itemsInBag = new BaseItem[_unit.InventoryParameters.InventorySize];
            ScreenInterface.GetInstance().AddObserver(ScreenTypes.InventoryMenu, this);
        }

        ~BaseInventory()
        {
            ScreenInterface.GetInstance().RemoveObserver(ScreenTypes.InventoryMenu, this);
            _equipmentUI.EquipmentItemClick -= OnEquipmentItemClick;
            _inventoryUI.InventoryItemClick -= OnInventoryItemClick;
            _inventoryUI.InventoryUIEnabled -= CheckInventory;
        }

        #endregion


        #region Methods

        private void CheckInventory(ItemCell[] itemCells)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] != null)
                {
                    itemCells[i].FillCellInfo(_itemsInBag[i]);
                }
            }
        }

        public void AddItemToInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (i == _itemsInBag.Length - 1 && _itemsInBag[i] != null)
                {
                    item.Drop();
                }
                if (_itemsInBag[i] == null)
                {
                    _itemsInBag[i] = item;
                    RenderVisibility.SpriteRenderVisibilityChange(item.transform, item.ItemSpriteRenderer, false);
                    ColliderEnabler.ColliderEnabledChanger(item.transform, item.ItemCollider, false);
                    return;
                }
            }
        }
        public void DeleteItemFromInventory(BaseItem item)
        {
            for (int i = 0; i < _itemsInBag.Length; i++)
            {
                if (_itemsInBag[i] == item)
                {
                    _itemsInBag[i] = null;
                }
            }
        }

        private void SelectingItem(BaseItem item)
        {
            _unit.Equipment.Equip(item);
            DeleteItemFromInventory(item);
        }
        private void OnInventoryItemClick(BaseItem item)
        {
            DeleteItemFromInventory(item);
        }
        private void OnEquipmentItemClick(BaseItem item)
        {
            AddItemToInventory(item);
        }

        #endregion


        #region IListnerScreen

        public void ShowScreen()
        {
            if (ScreenInterface.GetInstance().CurrentWindow is CharacterMenu)
            {
                _equipmentUI = Object.FindObjectOfType<CharacterEquipmentUI>();
                _inventoryUI = Object.FindObjectOfType<CharacterInventoryUI>();

                _equipmentUI.EquipmentItemClick += OnEquipmentItemClick;
                _inventoryUI.InventoryItemClick += OnInventoryItemClick;
                _inventoryUI.InventoryUIEnabled += CheckInventory;
            }
        }

        public void HideScreen()
        {

        }

        #endregion

    }
}

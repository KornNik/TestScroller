using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterInventoryUI : MonoBehaviour, IListenerScreen
    {
        public Action<ItemCell[]> InventoryUIEnabled;
        public Action<BaseItem> InventoryItemClick;

        [SerializeField] private GridLayoutGroup _itemsPlace;
        [SerializeField] private ItemCell[] _itemsCellList;

        private CharacterMenu _characterMenu;
        private int _emptyListCount;


        public GridLayoutGroup ItemPlace => _itemsPlace;


        #region UnityMethods

        private void Awake()
        {
            if (_itemsPlace == null)
            {
                _itemsPlace = GetComponentInChildren<GridLayoutGroup>();
            }
        }

        private void OnEnable()
        {
            ScreenInterface.GetInstance().AddObserver(Types.ScreenTypes.InventoryMenu, this);

            InventoryUIEnabled?.Invoke(_itemsCellList);

        }
        private void OnDisable()
        {
            InventoryItemClick -= OnInventoryItemClick;
            _characterMenu.EquipmentUI.EquipmentItemClick -= OnEquipmentItemClick;

            ScreenInterface.GetInstance().RemoveObserver(Types.ScreenTypes.InventoryMenu, this);
        }

        #endregion


        #region Methods

        public void FillItemsArray(ItemCell[] itemCells)
        {
            _itemsCellList = itemCells;
            _emptyListCount = _itemsCellList.Length;
        }

        private void FillItemCellInUI(BaseItem item)
        {
            if (_emptyListCount != 0)
            {
                for (int i = 0; i < _itemsCellList.Length; i++)
                {
                    if (_itemsCellList[i].IsEmpty)
                    {
                        _itemsCellList[i].FillCellInfo(item);
                        _emptyListCount--;
                        return;
                    }
                }
            }
        }
        private void RemoveItemCellFromUI(BaseItem item)
        {
            if (_emptyListCount != _itemsCellList.Length)
            {
                for (int i = 0; i < _itemsCellList.Length; i++)
                {
                    if(_itemsCellList[i].Item == item)
                    {
                        _itemsCellList[i].EmptyCell();
                        _emptyListCount++;
                        return;
                    }
                }
            }
        }
        private void OnInventoryItemClick(BaseItem item)
        {
            RemoveItemCellFromUI(item);
        }

        private void OnEquipmentItemClick(BaseItem item)
        {
            FillItemCellInUI(item);
        }

        #endregion

        #region IListnerScreen

        public void ShowScreen()
        {
            if (_characterMenu == null)
            {
                _characterMenu = ScreenInterface.GetInstance().CurrentWindow as CharacterMenu;

                if (_characterMenu is CharacterMenu)
                {
                    InventoryItemClick += OnInventoryItemClick;
                    _characterMenu.EquipmentUI.EquipmentItemClick += OnEquipmentItemClick;
                }
            }
        }

        public void HideScreen()
        {

        }

        #endregion
    }
}

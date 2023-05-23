using System;
using UnityEngine;
using UnityEngine.UI;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterInventoryUI : MonoBehaviour
    {
        public Action<ItemCell[]> InventoryUIEnabled;
        public Action<BaseItem> InventoryItemClick;

        [SerializeField] private GridLayoutGroup _itemsPlace;
        [SerializeField] private ItemCell[] _itemsCellList;

        private CharacterEquipmentUI _equipmentUI; 
        private int _emptyListCount;


        public GridLayoutGroup ItemPlace => _itemsPlace;


        #region UnityMethods

        private void Awake()
        {
            if (_itemsPlace == null)
            {
                _itemsPlace = GetComponentInChildren<GridLayoutGroup>();
            }
            _equipmentUI = FindObjectOfType<CharacterEquipmentUI>();
        }

        private void OnEnable()
        {
            InventoryUIEnabled?.Invoke(_itemsCellList);
            _equipmentUI.EquipmentItemClick += OnEquipmentItemClick;
            InventoryItemClick += OnInventoryItemClick;
        }
        private void OnDisable()
        {
            InventoryItemClick -= OnInventoryItemClick;
            _equipmentUI.EquipmentItemClick -= OnEquipmentItemClick;
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
    }
}

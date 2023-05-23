using System;
using UnityEngine;
using SideScroller.Helpers.Types;
using SideScroller.Model.Item;

namespace SideScroller.UI.Parts
{
    class CharacterEquipmentUI : MonoBehaviour
    {
        #region Fields

        public Action<WeaponEquipmentCell, ArmorEquipmentCell[]> EquipmentEnabledUI;
        public Action<BaseItem> EquipmentItemClick;

        [SerializeField] private WeaponEquipmentCell _weaponEquipmentCell;
        [SerializeField] private ArmorEquipmentCell[] _armorEquipmentCells;

        protected CharacterInventoryUI _inventoryUI;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _inventoryUI = FindObjectOfType<CharacterInventoryUI>();
            FillDefault();
        }
        private void OnEnable()
        {
            EquipmentEnabledUI?.Invoke(_weaponEquipmentCell,_armorEquipmentCells);

            _inventoryUI.InventoryItemClick += OnInventoryItemClick;
            EquipmentItemClick += OnEquipmentItemClick;
        }
        private void OnDisable()
        {
            _inventoryUI.InventoryItemClick -= OnInventoryItemClick;
            EquipmentItemClick -= OnEquipmentItemClick;
        }
        #endregion


        #region Methods

        private void FillDefault()
        {
            if (_weaponEquipmentCell.IsEmpty)
            {
                _weaponEquipmentCell.EmptyCell();
            }
            for (int i = 0; i < _armorEquipmentCells.Length; i++)
            {
                if (_armorEquipmentCells[i].IsEmpty)
                {
                    _armorEquipmentCells[i].EmptyCell();
                }
            }
        }

        private void AddEquipmentInUI(BaseItem item)
        {
            if(item is Weapon)
            {
                AddWeaponCell(item as Weapon);
            }
            else if(item is CommonArmor)
            {
                AddArmorCell(item as CommonArmor);
            }
        }
        private void RemoveEquipmentFromUI(BaseItem item)
        {
            if (item is CommonArmor)
            {
                RemoveArmorCell(item as CommonArmor);
            }
            else if(item is Weapon)
            {
                RemoveWeaponCell();
            }
        }

        private void RemoveWeaponCell()
        {
            _weaponEquipmentCell.EmptyCell();
        }
        private void RemoveArmorCell(CommonArmor armor)
        {
            FindArmorCellByType(armor.ArmorType).EmptyCell();
        }

        private void AddWeaponCell(Weapon weapon)
        {
            _weaponEquipmentCell.FillCellInfo(weapon);
        }
        private void AddArmorCell(CommonArmor armor)
        {
            FindArmorCellByType(armor.ArmorType).FillCellInfo(armor);
        }

        private ArmorEquipmentCell FindArmorCellByType(ArmorPlaceTypes armorType)
        {
            for (int i = 0; i < _armorEquipmentCells.Length; i++)
            {
                if (_armorEquipmentCells[i].ArmorType == armorType)
                {
                    return _armorEquipmentCells[i];
                }
            }
            return null;
        }
        private void OnInventoryItemClick(BaseItem item)
        {
            AddEquipmentInUI(item);
        }
        private void OnEquipmentItemClick(BaseItem item)
        {
            RemoveEquipmentFromUI(item);
        }

        #endregion
    }
}

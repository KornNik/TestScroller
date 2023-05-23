using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.UI.Parts;
using SideScroller.Model.Item;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Types;
using SideScroller.Helpers;

namespace SideScroller.Model.Inventory
{
    class Equipment : IListenerScreen
    {
        #region Fields

        private Weapon _weapon;
        private ArmorPlaces _armor;
        private BaseUnit _unit;

        protected CharacterEquipmentUI _equipmentUI;
        protected CharacterInventoryUI _inventoryUI;

        #endregion


        #region Properties

        public Weapon Weapon => _weapon;
        public ArmorPlaces Armor => _armor;

        #endregion


        #region ClassLifeCycle

        public Equipment(BaseUnit unit)
        {
            _unit = unit;
            ScreenInterface.GetInstance().AddObserver(ScreenTypes.InventoryMenu, this);
        }

        ~Equipment()
        {
            ScreenInterface.GetInstance().RemoveObserver(ScreenTypes.InventoryMenu, this);

            _equipmentUI.EquipmentEnabledUI -= CheckEquipment;
            _equipmentUI.EquipmentItemClick -= OnEquipmentItemClick;
            _inventoryUI.InventoryItemClick -= OnInventoryItemClick;
        }

        #endregion


        #region Methods

        public void Equip(BaseItem item)
        {
            if (item is Weapon)
            {
                EquipWeapon(item as Weapon);
            }
            else if (item is CommonArmor)
            {
                EquipArmor(item as CommonArmor);
            }

            RenderVisibility.SpriteRenderVisibilityChange(item.transform, item.ItemSpriteRenderer, true);
            ColliderEnabler.ColliderEnabledChanger(item.transform, item.ItemCollider, false);

            _unit.InventoryEventManager.EquipmentChanged?.Invoke();
        }

        private void EquipWeapon(Weapon weapon)
        {
            Unequip(_weapon);
            _weapon = weapon;
            _weapon.transform.parent = _unit.WeaponPlace;
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
            var autoAim = _weapon.GetComponent<AutoAim>();
            if (autoAim)
            {
                autoAim.enabled = true;
            }
            _unit.UnitBoolStates.IsWeaponOut = true;
            _unit.UnitEventManager.WeaponOut?.Invoke(true);
        }
        private void EquipArmor(CommonArmor armor)
        {
            _armor.SetArmor(armor);
            armor.transform.position = _unit.InventoryTransform.position;
        }

        private void Unequip(BaseItem item)
        {
            if(item is Weapon)
            {
                _weapon = null;
                _unit.UnitBoolStates.IsWeaponOut = false;
                _unit.UnitEventManager.WeaponOut?.Invoke(false);
                var autoAim = _weapon.GetComponent<AutoAim>();
                if (autoAim)
                {
                    autoAim.enabled = true;
                }
            }
            else if (item is CommonArmor)
            {
                var armor = item as CommonArmor;
                _armor.SetArmor(null);
            }
        }
        private void CheckEquipment(WeaponEquipmentCell weaponEquipmentCell, ArmorEquipmentCell[] armorEquipmentCells)
        {
            if(_weapon != null)
            {
                weaponEquipmentCell.FillCellInfo(_weapon);
            }
            FillArmorEquipmentCell(_armor.GetArmor(ArmorPlaceTypes.Head), armorEquipmentCells);
            FillArmorEquipmentCell(_armor.GetArmor(ArmorPlaceTypes.Hands), armorEquipmentCells);
            FillArmorEquipmentCell(_armor.GetArmor(ArmorPlaceTypes.Body), armorEquipmentCells);
            FillArmorEquipmentCell(_armor.GetArmor(ArmorPlaceTypes.Legs), armorEquipmentCells);
        }

        private void FillArmorEquipmentCell(CommonArmor armor, ArmorEquipmentCell[] armorEquipmentCells)
        {
            if (armor != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == armor.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(armor);
                    }
                }
            }
        }

        private void OnInventoryItemClick(BaseItem item)
        {
            Equip(item);
        }
        private void OnEquipmentItemClick(BaseItem item)
        {
            Unequip(item);
        }

        #endregion

        #region IListnerScreen

        public void ShowScreen()
        {
            if (ScreenInterface.GetInstance().CurrentWindow is CharacterMenu)
            {
                _equipmentUI = Object.FindObjectOfType<CharacterEquipmentUI>();
                _inventoryUI = Object.FindObjectOfType<CharacterInventoryUI>();

                _equipmentUI.EquipmentEnabledUI += CheckEquipment;
                _equipmentUI.EquipmentItemClick += OnEquipmentItemClick;
                _inventoryUI.InventoryItemClick += OnInventoryItemClick;
            }
        }

        public void HideScreen()
        {

        }

        #endregion
    }
}

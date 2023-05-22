using UnityEngine;
using SideScroller.UI;
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
        private CharacterMenu _characterMenu;
        private CharacterEquipmentUI _equipmentUI;
        private CharacterInventoryUI _inventoryUI;

        #endregion


        #region Properties

        public Weapon Weapon => _weapon;
        public ArmorPlaces Armor => _armor;

        #endregion


        #region ClassLifeCycle

        public Equipment(BaseUnit unit)
        {
            _unit = unit;
            ScreenInterface.GetInstance().AddObserver(UI.Types.ScreenTypes.InventoryMenu, this);
        }

        ~Equipment()
        {
            _equipmentUI.EquipmentEnabledUI -= CheckEquipment;
            _equipmentUI.EquipmentItemClick -= OnEquipmentItemClick;
            _inventoryUI.InventoryItemClick -= OnInventoryItemClick;

            ScreenInterface.GetInstance().RemoveObserver(UI.Types.ScreenTypes.InventoryMenu, this);
        }

        #endregion


        #region Methods

        public void Equip(BaseItem item)
        {
            if (item is Weapon)
            {
                EquipWeapon(item as Weapon);
                RenderVisibility.SpriteRenderVisibilityChange(item.transform, item.ItemSpriteRenderer, true);
            }
            else if (item is CommonArmor)
            {
                EquipArmor(item as CommonArmor);
                RenderVisibility.SpriteRenderVisibilityChange(item.transform, item.ItemSpriteRenderer, true);
                ColliderEnabler.ColliderEnabledChanger(item.transform, item.ItemCollider, false);
            }

            _unit.InventoryEventManager.EquipmentChanged?.Invoke();
        }

        private void EquipWeapon(Weapon weapon)
        {
            Unequip(_weapon);
            _weapon = weapon;
            _weapon.transform.parent = _unit.InventoryTransform;
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
            _unit.UnitBoolStates.IsWeaponOut = true;
            _unit.UnitEventManager.WeaponOut?.Invoke(true);
            ColliderEnabler.ColliderEnabledChanger(_weapon.transform, _weapon.ItemCollider, true);
        }
        private void EquipArmor(CommonArmor armor)
        {
            switch (armor.ArmorType)
            {
                case ArmorPlaceTypes.Hands:
                    Unequip(_armor.Hands);
                    _armor.Hands = armor;
                    break;
                case ArmorPlaceTypes.Legs:
                    Unequip(_armor.Legs);
                    _armor.Legs = armor;
                    break;
                case ArmorPlaceTypes.Body:
                    Unequip(_armor.Body);
                    _armor.Body = armor;
                    break;
                case ArmorPlaceTypes.Head:
                    Unequip(_armor.Head);
                    _armor.Head = armor;
                    break;
                default:

                    break;
            }
        }

        private void Unequip(BaseItem item)
        {
            if(item is Weapon)
            {
                _weapon = null;
                _unit.UnitBoolStates.IsWeaponOut = false;
                _unit.UnitEventManager.WeaponOut?.Invoke(false);
            }
            else if (item is CommonArmor)
            {

            }
        }
        private void CheckEquipment(WeaponEquipmentCell weaponEquipmentCell, ArmorEquipmentCell[] armorEquipmentCells)
        {
            if(_weapon != null)
            {
                weaponEquipmentCell.FillCellInfo(_weapon);
            }
            if (_armor.Body != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Body.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Body);
                    }
                }
            }
            if (_armor.Hands != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Hands.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Hands);
                    }
                }
            }
            if (_armor.Head != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Head.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Head);
                    }
                }
            }
            if (_armor.Legs != null)
            {
                for (int i = 0; i < armorEquipmentCells.Length; i++)
                {
                    if (armorEquipmentCells[i].ArmorType == _armor.Legs.ArmorType)
                    {
                        armorEquipmentCells[i].FillCellInfo(_armor.Legs);
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
            if (_characterMenu == null)
            {
                _characterMenu = ScreenInterface.GetInstance().CurrentWindow as CharacterMenu;

                if (_characterMenu is CharacterMenu)
                {
                    _equipmentUI = _characterMenu.EquipmentUI;
                    _inventoryUI = _characterMenu.InventoryUI;
                    _equipmentUI.EquipmentItemClick += OnEquipmentItemClick;
                    _inventoryUI.InventoryItemClick += OnInventoryItemClick;
                    _equipmentUI.EquipmentEnabledUI += CheckEquipment;
                }
            }
        }

        public void HideScreen()
        {

        }

        #endregion
    }
}

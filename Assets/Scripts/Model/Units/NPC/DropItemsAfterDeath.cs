using UnityEngine;
using SideScroller.Data.Unit;
using SideScroller.Helpers;
using SideScroller.Model.Item;
using SideScroller.Helpers.AssetsPath;

namespace SideScroller.Model.Unit
{
    class DropItemsAfterDeath
    {
        private NPCsDropingItems _dropingItems;
        private BaseNPC _unit;

        public DropItemsAfterDeath(NPCsDropingItems dropingItems,BaseNPC unit)
        {
            _dropingItems = dropingItems;
            _unit = unit;
            _unit.UnitEventManager.Death += DropItemOnDeath;
        }

        private void DropItemOnDeath()
        {
            var randomItem = _dropingItems.GetRandomItem();
            if (randomItem._weaponType != Helpers.Types.WeaponType.None)
            {
                var dropingItem = randomItem._weaponType;
                var weapon = CustomResources.Load<BaseItem>(WeaponsAssetPath.WeaponsPath[dropingItem]);
                Object.Instantiate(weapon, _unit.transform.position, _unit.transform.rotation);
            }
            else if (randomItem._armorType != Helpers.Types.ArmorTypes.None)
            {
                var dropingItem = randomItem._armorType;
                var armor = CustomResources.Load<BaseItem>(ArmorAssetPath.ArmorsPath[dropingItem]);
                Object.Instantiate(armor, _unit.transform.position, _unit.transform.rotation);
            }

        }
    }
}

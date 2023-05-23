using System;
using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Unit
{
    [Serializable]
    struct DropingItems
    {
        public ArmorTypes _armorType;
        public WeaponType _weaponType;
    }
    [CreateAssetMenu(fileName ="DropingItems",menuName ="Data/Unit/DropingItems")]
    class NPCsDropingItems : ScriptableObject
    {
        [SerializeField] private DropingItems[] _dropingItems; 

        public DropingItems GetRandomItem()
        {
            var randomValue = UnityEngine.Random.Range(0, _dropingItems.Length);
            return _dropingItems[randomValue];
        }
    }
}

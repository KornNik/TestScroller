using SideScroller.Model.Item;
using SideScroller.Helpers.Types;

namespace SideScroller.Model.Inventory
{
    struct CurrentArmor
    {
        public ArmorPlaceTypes ArmorPlace;
        public CommonArmor Armor;
    }
    struct ArmorPlaces
    {
        #region MyRegion

        private CurrentArmor _head;
        private CurrentArmor _body;
        private CurrentArmor _legs;
        private CurrentArmor _hands;

        #endregion

        public void SetArmor(CommonArmor armor)
        {
            switch (armor.ArmorType)
            {
                case ArmorPlaceTypes.Hands:
                    _hands.Armor = armor;
                    break;
                case ArmorPlaceTypes.Legs:
                    _legs.Armor = armor;
                    break;
                case ArmorPlaceTypes.Body:
                    _body.Armor = armor;
                    break;
                case ArmorPlaceTypes.Head:
                    _head.Armor = armor;
                    break;
                default:

                    break;
            }
        }

        public CommonArmor GetArmor(ArmorPlaceTypes armorPlace)
        {
            switch (armorPlace)
            {
                case ArmorPlaceTypes.Hands:
                    return _hands.Armor;
                case ArmorPlaceTypes.Legs:
                    return _legs.Armor;
                case ArmorPlaceTypes.Body:
                    return _body.Armor;
                case ArmorPlaceTypes.Head:
                    return _head.Armor;
                default:
                    return null;
            }
        }

    }
}

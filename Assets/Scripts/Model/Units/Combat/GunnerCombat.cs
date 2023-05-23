using SideScroller.Data.Unit;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    class GunnerCombat : BaseCombat
    {
        public GunnerCombat(BaseCombatParameters unitCombatParameters, BaseUnit unitBehaviour) : base(unitCombatParameters, unitBehaviour)
        {
            _combatParameters = unitCombatParameters;
            _unitBehaviour = unitBehaviour;
        }

        #region ICombat

        public override void AttackOnEventAnimation()
        {
            base.AttackOnEventAnimation();
            if(_unitBehaviour.Equipment.Weapon is CommonRangedWeapon)
            {
                _unitBehaviour.Equipment.Weapon.WeaponAttack();
            }
        }
        public override void Protect()
        {
            throw new System.NotImplementedException();
        }
        public override void Dodge()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

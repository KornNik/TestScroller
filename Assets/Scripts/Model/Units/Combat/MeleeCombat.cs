using UnityEngine;
using SideScroller.Data.Unit;
using SideScroller.Helpers.Managers;
using SideScroller.Model.Item;

namespace SideScroller.Model.Unit.Combat
{
    class MeleeCombat : BaseCombat
    {
        #region ClassLifeCycle

        public MeleeCombat(BaseCombatParameters unitCombatParameters, BaseUnit unitBehaviour) : base(unitCombatParameters, unitBehaviour)
        {
            _combatParameters = unitCombatParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region ICombat

        public override void AttackOnEventAnimation()
        {
            base.AttackOnEventAnimation();
            var result = Physics2D.OverlapCircleNonAlloc(_unitBehaviour.AttackArea.position, 0.2f, _damagingObjects, LayersManager.PlayerLayer);
            for (int i = 0; i < result; i++)
            {
                var victim = _damagingObjects[i].GetComponent<IDamageable>();
                if (victim != null)
                {
                    _unitBehaviour.Equipment.Weapon.InflictDamage(victim);
                }
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

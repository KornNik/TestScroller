using SideScroller.Helpers;

namespace SideScroller.Model.Unit.Death
{
    class BaseDeath
    {

        private BaseUnit _unit;


        #region ClassLifeCycle

        public BaseDeath(BaseUnit unit)
        {
            _unit = unit;

            _unit.UnitEventManager.Death += Dying;
            _unit.UnitEventManager.Recover += Recover;
        }

        ~BaseDeath()
        {
            _unit.UnitEventManager.Death -= Dying;
            _unit.UnitEventManager.Recover -= Recover;
        }

        #endregion


        #region Methods

        public void Dying()
        {
            RenderVisibility.SpriteRenderVisibilityChange(_unit.UnitModel, false);
            ColliderEnabler.ColliderEnabledChanger(_unit.transform, _unit.UnitCollider, false);
            _unit.UnitRigidbody.isKinematic = true;
            _unit.UnitBoolStates.IsDead = true;
        }
        public void Recover()
        {
            RenderVisibility.SpriteRenderVisibilityChange(_unit.UnitModel, true);
            ColliderEnabler.ColliderEnabledChanger(_unit.transform, _unit.UnitCollider, true);
            _unit.UnitRigidbody.isKinematic = false;
            _unit.UnitBoolStates.IsDead = false;
        }

        #endregion
    }
}

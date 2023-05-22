using SideScroller.Model.Unit.Combat;

namespace SideScroller.Model.Unit
{
    class Gunner : BasePlayerCharacter
    {
        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _combat = new GunnerCombat(_unitCombatParameters, this);
        }

        #endregion
    }
}
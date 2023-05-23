using SideScroller.Helpers;
using SideScroller.UI;

namespace SideScroller.Model.Unit.Death
{
    class PlayerDeath : BaseDeath
    {
        public PlayerDeath(BaseUnit unit) : base(unit)
        {
            _unit = unit;
        }

        public override void Dying()
        {
            base.Dying();

            ScreenInterface.GetInstance().Execute(UI.Types.ScreenTypes.EndGameMenu);

        }
    }
}

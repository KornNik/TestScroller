using SideScroller.Model.Unit.Movement;
using SideScroller.Model.Unit.Death;

namespace SideScroller.Model.Unit
{
    abstract class BasePlayerCharacter : BaseUnit
    {
        protected override void Awake()
        {
            base.Awake();
            _movement = new PlayerMovement(_unitMovementParameters, this);
            _death = new PlayerDeath(this);
        }
    }
}

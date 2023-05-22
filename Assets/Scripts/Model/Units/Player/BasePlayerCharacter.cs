using SideScroller.Model.Unit.Movement;

namespace SideScroller.Model.Unit
{
    abstract class BasePlayerCharacter : BaseUnit
    {
        protected override void Awake()
        {
            base.Awake();
            _movement = new PlayerMovement(_unitMovementParameters, this);
        }
    }
}

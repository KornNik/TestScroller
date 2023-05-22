using UnityEngine;
using SideScroller.Data.Unit;

namespace SideScroller.Model.Unit.Movement
{
    abstract class BaseMovement : IMoveable
    {
        #region Fields

        protected BaseMovementParameters _movementParameters;
        protected BaseUnit _unitBehaviour;

        protected float _movementValue = 0f; 

        #endregion


        #region ClassLifeCycle

        public BaseMovement(BaseMovementParameters movementParameters, BaseUnit unitBehaviour)
        {
            _movementParameters = movementParameters;
            _unitBehaviour = unitBehaviour;
        }

        #endregion


        #region Methods

        public virtual void Move(Vector2 movingDirection)
        {
            FlipUnit(movingDirection.x);
            _unitBehaviour.UnitBoolStates.IsMoving = true;
            _unitBehaviour.UnitEventManager.Moving?.Invoke(true);
        }
        public virtual void Stop()
        {
            _unitBehaviour.UnitBoolStates.IsMoving = false;
            _unitBehaviour.UnitEventManager.Moving?.Invoke(false);
        }
        protected virtual void FlipUnit(float movingInput)
        {
            _unitBehaviour.UnitBoolStates.IsFlip = movingInput < 0;
            _unitBehaviour.transform.rotation = Quaternion.Euler(new Vector3
                (0f, _unitBehaviour.UnitBoolStates.IsFlip ? 180 : 0f, 0f));
        }

        #endregion
    }
}

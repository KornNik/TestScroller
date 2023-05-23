using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.UI;
using SideScroller.UI.Types;

namespace SideScroller.Controller
{
    sealed class PlayerController : MonoBehaviour, IListenerScreen
    {
        #region Fields

        private BasePlayerCharacter _player;
        private GameMenu _gameMenu;

        private bool _isActive;

        #endregion


        #region UnityMethods

        private void OnEnable()
        {
            ScreenInterface.GetInstance().AddObserver(ScreenTypes.GameMenu, this);
        }

        private void OnDisable()
        {
            _gameMenu.Attack -= Attack;
        }

        private void Awake()
        {
            _player = GetComponent<BasePlayerCharacter>();
        }

        private void FixedUpdate()
        {
            if (_isActive)
            {
                Vector2 inputAxisJoystick;
                inputAxisJoystick.x = _gameMenu.MovementJoystick.Direction.x;
                inputAxisJoystick.y = _gameMenu.MovementJoystick.Direction.y;

                if (inputAxisJoystick.x != 0 || inputAxisJoystick.y != 0)
                {
                    _player.Movement.Move(inputAxisJoystick);
                }
                else
                {
                    _player.Movement.Stop();
                }
            }
        }

        #endregion


        #region Methods

        private void Attack()
        {
            _player.Combat.BegginAttack();
        }

        #endregion


        #region IListnerScreen
        public void ShowScreen()
        {
            _isActive = true;
            if (_gameMenu == null)
            {
                _gameMenu = ScreenInterface.GetInstance().CurrentWindow as GameMenu;
                _gameMenu.Attack += Attack;
            }
        }

        public void HideScreen()
        {
            _isActive = false;
        }

        #endregion
    }
}

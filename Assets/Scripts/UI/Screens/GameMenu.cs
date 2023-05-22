using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SideScroller.UI.Parts;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Services;

namespace SideScroller.UI
{
    class GameMenu : BaseUI
    {
        #region Fields

        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private ControlButton _attackButton;
        [SerializeField] private Joystick _joystic;

        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _pauseButton;

        public UnityAction Attack;

        #endregion

        public Joystick MovementJoystick => _joystic;


        #region UnityMethods

        private void OnEnable()
        {
            _attackButton.onClick.AddListener(OnAttackClick);
            _inventoryButton.onClick.AddListener(OnInventoryButtonDown);
            _pauseButton.onClick.AddListener(OnPauseButtonDown);

            if (Services.Instance.PlayerService.PlayerCharacter is BaseUnit)
            {
                _healthBar.SetUnit(Services.Instance.PlayerService.PlayerCharacter);
            }
        }

        private void OnDisable()
        {
            _attackButton.onClick.RemoveListener(OnAttackClick);
            _inventoryButton.onClick.RemoveListener(OnInventoryButtonDown);
            _pauseButton.onClick.RemoveListener(OnPauseButtonDown);

        }

        #endregion


        #region Methods

        private void OnInventoryButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.InventoryMenu);
        }
        private void OnAttackClick()
        {
            Attack?.Invoke();
        }
        private void OnPauseButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.PauseMenu);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        #endregion
    }
}
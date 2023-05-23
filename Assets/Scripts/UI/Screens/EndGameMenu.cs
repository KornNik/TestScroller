using UnityEngine;
using UnityEngine.UI;

namespace SideScroller.UI
{
    class EndGameMenu : BaseUI
    {
        [SerializeField] Button _quitButton;

        private void OnEnable()
        {
            _quitButton.onClick.AddListener(OnQuitButtonDown);
        }
        private void OnDisable()
        {
            _quitButton.onClick.RemoveListener(OnQuitButtonDown);
        }

        private void OnQuitButtonDown()
        {
            Application.Quit();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            HideUI.Invoke();
        }
    }
}

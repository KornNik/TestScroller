using UnityEngine;
using UnityEngine.UI;

namespace SideScroller.UI
{
    class PauseMenu : BaseUI
    {
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _quitButton;


        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonDown);
            _quitButton.onClick.AddListener(OnQuitButtonDown);
        }
        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumeButtonDown);
            _quitButton.onClick.RemoveListener(OnQuitButtonDown);

        }

        private void OnResumeButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Types.ScreenTypes.GameMenu);
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

using UnityEngine;
using SideScroller.UI;
using SideScroller.UI.Types;
using SideScroller.Model.Unit;
using SideScroller.Model.LevelModel;
using SideScroller.Helpers;
using SideScroller.Helpers.Types;
using SideScroller.Model.CameraBeh;

namespace SideScroller
{
    class GameManager : Singleton<GameManager>
    {
        #region Fields

        [SerializeField] private int _levelQuality = 0;
        [SerializeField] private int _targetFrameRate = 60;

        private Level _level;
        private LevelLoader _levelLoader;
        private BasePlayerCharacter _player;
        private CameraBehaviour _playerCamera;

        #endregion


        #region Properties

        public Level Level => _level;
        public CameraBehaviour PlayerCamera => _playerCamera;
        public BasePlayerCharacter PlayerCharacter => _player;

        public LevelLoader LevelLoader => _levelLoader;

        public static GameManager Instance
        {
            get
            {
                return (GameManager)_instanceSingleton;
            }
        }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            Application.targetFrameRate = _targetFrameRate;
            QualitySettings.SetQualityLevel(_levelQuality);
            ScreenInterface.GetInstance().Execute(ScreenTypes.MainMenu);
            _levelLoader = new LevelLoader();

            _levelLoader.LoadCamera(CameraTypes.LevelCameras, Vector3.zero);
        }

        #endregion


        #region Methods

        public bool IsLevelExist()
        {
            if (_level)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Load()
        {
            if (SaveManager.Instance.IsSaveExist()) 
            {
                LoadWithSaveFile();
            }
            else
            {
                LoadDefault();
            }
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryMenu);
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);

        }

        private void LoadDefault()
        {
            _level = _levelLoader.LoadLevel(LevelTypes.First);
            _level.NPCList =  _levelLoader.LoadNPCs();
            _player = _levelLoader.LoadPlayer(PlayerCharacterTypes.Gunner, WeaponType.Pistol, _level.PlayerSpawnTransform.position);
        }
        private void LoadWithSaveFile()
        {
            LoadDefault();
            SaveManager.Instance.LoadData();
        }

        #endregion
    }
}
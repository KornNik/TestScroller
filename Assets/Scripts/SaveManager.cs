using SideScroller.Helpers.Save;
using SideScroller.Helpers;

namespace SideScroller
{
    class SaveManager : Singleton<SaveManager>
    {
        private DeserializationSavingData _savingData;

        public static SaveManager Instance
        {
            get
            {
                return (SaveManager)_instanceSingleton;
            }
        }
        private void SaveData()
        {
            if (_savingData == null)
            {
                _savingData = new DeserializationSavingData();
            }
            _savingData.Save();
        }
        public void LoadData()
        {
            if (_savingData == null)
            {
                _savingData = new DeserializationSavingData();
            }
            _savingData.Load();
        }
        private void OnApplicationQuit()
        {
            if (!GameManager.Instance.IsLevelExist())
            {
                return;
            }
            SaveData();
        }
        public bool IsSaveExist()
        {
            if (_savingData == null) { return false; }

            if (_savingData.SaveSystem.CheckDirectory()) { return true; }
            else { return false; }
        }
    }
}
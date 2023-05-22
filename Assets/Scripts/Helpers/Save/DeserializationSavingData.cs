using System.Collections.Generic;
using SideScroller.Model.Unit;
using SideScroller.Model.LevelModel;


namespace SideScroller.Helpers.Save
{
    class DeserializationSavingData
    {
        #region Fields

        private SaveData _myData;
        private BaseUnit _character;
        private List<BaseNPC> _enemies;
        private Level _level;

        private ISaveSystem<SaveData> _saveSystem;

        #endregion


        public ISaveSystem<SaveData> SaveSystem => _saveSystem;


        #region ClassLifeSycle

        public DeserializationSavingData()
        {
            _enemies = new List<BaseNPC>();

            _myData = new SaveData();
            _saveSystem = new JsonService<SaveData>();
            _character = GameManager.Instance.PlayerCharacter;
            _enemies = GameManager.Instance.Level.NPCList; ;
            _level = GameManager.Instance.Level;
        }

        #endregion


        #region Methods

        public void Save()
        {
            _myData.Level = _level.name;
            _myData.serializableGameObjects.Add(new SerializableGameObject
            {
                Name = _character.name,
                Position = _character.transform.position,
                Rotation = _character.transform.rotation,
                IsEnable = _character.enabled
            });
            foreach (var item in _enemies)
            {
                _myData.serializableGameObjects.Add(new SerializableGameObject
                {
                    Name = item.GetInstanceID().ToString(),
                    Position = item.transform.position,
                    Rotation = item.transform.rotation,
                    IsEnable = item.enabled
                });
            }
            _saveSystem.Save(_myData);
        }

        public void Load()
        {
            _myData = _saveSystem.Load();
            foreach (var item in _myData.serializableGameObjects)
            {
                if (item.Name == _character.name)
                {
                    _character.transform.position = item.Position;
                    _character.transform.rotation = item.Rotation;
                    _character.enabled = item.IsEnable;
                }
                foreach (var enemy in _enemies)
                {
                    if (item.Name == enemy.GetInstanceID().ToString())
                    {
                        enemy.transform.position = item.Position;
                        enemy.transform.rotation = item.Rotation;
                        enemy.enabled = item.IsEnable;
                    }
                }
            }
        }

        #endregion
    }
}

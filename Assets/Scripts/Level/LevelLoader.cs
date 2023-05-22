using System.Collections.Generic;
using UnityEngine;
using SideScroller.Helpers;
using SideScroller.Model.Unit;
using SideScroller.Helpers.Types;
using SideScroller.Model.CameraBeh;
using SideScroller.Model.LevelModel;
using SideScroller.Helpers.Services;
using SideScroller.Helpers.AssetsPath;

namespace SideScroller
{
    class LevelLoader
    {
        #region Fields

        private Level _level;
        private CameraBehaviour _playerCamera;
        private BasePlayerCharacter _playerCharacter;

        #endregion


        #region Methods

        public Level LoadLevel(LevelTypes levelType)
        {
            var resources = CustomResources.Load<Level>(LevelsAssetPath.LevelsPath[levelType]);
            _level = Object.Instantiate(resources, Vector3.zero, Quaternion.identity);
            return _level;
        }
        public BasePlayerCharacter LoadPlayer(PlayerCharacterTypes playerType, WeaponType weaponType, Vector3 position)
        {
            _playerCharacter = new PlayerLoader().CreateHero(playerType).WithWeapon(weaponType).OnPosition(position);
            Services.Instance.PlayerService.SetPlayer(_playerCharacter);

            if (_playerCamera)
            {
                _playerCamera.SetPlayer(_playerCharacter);
            }

            return _playerCharacter;
        }
        public void LoadCamera(CameraTypes cameraType,Vector3 position)
        {
            var resources = CustomResources.Load<CameraBehaviour>(CamerasAssetPath.CamerasPath[cameraType]);
            _playerCamera = Object.Instantiate(resources, position, Quaternion.identity);
        }
        public List<BaseNPC> LoadNPCs()
        {
            List<BaseNPC> NPCsList = new List<BaseNPC>(_level.LevelData.NPCTypesArray.Length);

            for (int i = 0; i < _level.LevelData.NPCTypesArray.Length; i++)
            {
                NPCsList.Add(new NPCLoader().CreateNPC(_level.LevelData.NPCTypesArray[i])
                    .WithWeapon(WeaponType.Melee).OnPosition(_level.EnemiesSpawnTransform[i].position));
            }

            return NPCsList;
        }

        #endregion

    }
}
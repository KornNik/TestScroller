using UnityEngine;
using SideScroller.Data.Level;
using SideScroller.Model.Unit;
using System.Collections.Generic;

namespace SideScroller.Model.LevelModel
{
    class Level : MonoBehaviour
    {
        #region Fields

        [SerializeField] private LevelParameters _levelData;
        [SerializeField] private Transform[] _enemiesSpawnTransform;
        [SerializeField] private Transform _playerSpawnTransform;

        private List<BaseNPC> _NPCsList;

        #endregion


        #region Properties

        public LevelParameters LevelData => _levelData;
        public List<BaseNPC> NPCList { get { return _NPCsList; } set { _NPCsList = value; } }
        public Transform[] EnemiesSpawnTransform => _enemiesSpawnTransform;
        public Transform PlayerSpawnTransform => _playerSpawnTransform;

        #endregion

        private void Awake()
        {
            _NPCsList = new List<BaseNPC>();
        }
    }
}
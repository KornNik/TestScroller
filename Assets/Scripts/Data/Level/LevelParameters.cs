using UnityEngine;
using SideScroller.Helpers.Types;

namespace SideScroller.Data.Level
{
    [CreateAssetMenu(fileName = "LevelParameters", menuName = "Data/Level/LevelParameters")]
    class LevelParameters : ScriptableObject
    {
        [SerializeField] private NPCTypes[] _NPCTypesArray;
        [SerializeField] private Vector3[] _NPCPositions;

        public NPCTypes[] NPCTypesArray => _NPCTypesArray;
        public Vector3[] NPCPositions => _NPCPositions;

    }
}
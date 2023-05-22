using System;
using UnityEngine;
using SideScroller.Model.Unit;
using SideScroller.Controller;

namespace SideScroller.Helpers.Services
{
    sealed class PlayerService
    {

        private BasePlayerCharacter _playerCharacter;

        public BasePlayerCharacter PlayerCharacter => _playerCharacter;

        public PlayerService()
        {

        }
        ~PlayerService()
        {

        }

        public void SetPlayer(BasePlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }
    }
}

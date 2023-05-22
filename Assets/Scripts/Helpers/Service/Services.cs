using System;

namespace SideScroller.Helpers.Services
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public Services()
        {
            Initialize();
        }

        public static Services Instance => _instance.Value;
        public PlayerService PlayerService { get; private set; }

        private void Initialize()
        {
            PlayerService = new PlayerService();
        }
    }
}

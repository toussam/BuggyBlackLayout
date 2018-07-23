using System.Collections.Generic;

namespace BuggyBlackLayout.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        #region Private Properties

        private List<string> videoUrls;

        #endregion

        #region Public Properties

        public List<string> VideoUrls { get { return videoUrls; } set { videoUrls = value; OnPropertyChanged(); } }

        #endregion

        #region Constructors

        public MainPageViewModel()
        {
            InitializeVideoUrls();
        }

        #endregion

        #region Private Methods

        private void InitializeVideoUrls()
        {
            videoUrls = new List<string>
            {
                @"https://www.youtube.com/watch?v=ipeXRXetmFE",
                @"https://www.youtube.com/watch?v=ipeXRXetmFE",
                //@"https://www.youtube.com/watch?v=ipeXRXetmFE",
            };
        }

        #endregion
    }
}
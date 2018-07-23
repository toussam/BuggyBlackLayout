using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Xamarin.Forms;

namespace BuggyBlackLayout.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly INavigation Navigation;

        /// <summary>
        /// Un token qui se cancel lorsqu'une touche "back" est utilisée pour quitter l'écran.
        /// A utiliser dans tous les appels ws pour les annuler.
        /// </summary>
        public CancellationTokenSource BackCancel { get; } = new CancellationTokenSource();

        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (var name in propertyNames)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void OnAllPropertyChanged()
        {
            OnPropertyChanged("");
        }

        /// <summary>
        /// You may override this method, don't forget to call base.
        /// </summary>
        /// <remarks>
        /// Do not call this method directly; Called only from NavigationEventPage.
        /// </remarks>
        internal virtual void OnPopped()
        {
            BackCancel.Cancel();
        }
    }
}

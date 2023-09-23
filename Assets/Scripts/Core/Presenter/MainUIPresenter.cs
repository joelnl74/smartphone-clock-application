using Core.Presenter;
using Core.UI.Presenter.Interfaces;
using Core.UI.View.Interfaces;
using UnityEngine;

namespace Core.UI.Presenter
{
    public class MainUIPresenter : Presenter<IUITabview>,
        IMainUIPresenter
    {
        private int _currentIndex = 0;
        
        /// <summary>
        /// Switch page and play animation.
        /// </summary>
        /// <param name="index">Page you wish to navigate to.</param>
        public void ChangePage(int index)
        {
            _view.DidChangePage(_currentIndex, index);
            _currentIndex = index;
        }

        /// <summary>
        /// Close the application.
        /// </summary>
        public void CloseApplication()
            => Application.Quit();
    }
}

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
        
        public void ChangePage(int index)
        {
            _view.DidChangePage(_currentIndex, index);
            _currentIndex = index;
        }

        public void CloseApplication()
            => Application.Quit();
    }
}

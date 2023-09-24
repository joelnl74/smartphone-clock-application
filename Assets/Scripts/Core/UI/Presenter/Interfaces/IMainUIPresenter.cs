using Core.Interfaces;
using Core.UI.View.Interfaces;

namespace Core.UI.Presenter.Interfaces
{
    public interface IMainUIPresenter : IPresenter<IUITabview>
    {
        void CloseApplication();
        void ChangePage(int index);
    }
}


using Core.Interfaces;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter.Interfaces
{
    public interface IBaseTimerPresenter<T> : IPresenter<T> where T : IView
    {
        void LoadData(float time = 0);
        void Reset();
    }
}

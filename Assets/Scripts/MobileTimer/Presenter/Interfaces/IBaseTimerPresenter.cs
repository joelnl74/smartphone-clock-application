
using Core.Interfaces;

namespace MobileClock.Presenter.Interfaces
{
    public interface IBaseTimerPresenter<T> : IPresenter<T> where T : IView
    {
        void LoadData(int time = 0);
        void StartTimer();
        void Stop();
    }
}

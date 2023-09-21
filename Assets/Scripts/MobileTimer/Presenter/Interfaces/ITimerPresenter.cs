using Core.Interfaces;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter.Interfaces
{
    public interface ITimerPresenter : IBaseTimerPresenter<ITimerView>
    {
        void IncreaseTimer(int time);
        void DecreaseTimer(int time);
        void Reset();
    }
}


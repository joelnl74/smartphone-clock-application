using Core.ViewController;
using MobileClock.Presenter.Interfaces;
using MobileClock.View;
using MobileClock.View.Interfaces;

namespace MobileClock.ViewController
{
    public class MobileTimerViewController : ViewController<ITimerPresenter, ITimerView, TimerView>
    {
    }
}


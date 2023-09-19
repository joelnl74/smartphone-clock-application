using Core.ViewController;
using MobileClock.Presenter.Interfaces;
using MobileClock.View;
using MobileClock.View.Interfaces;

namespace MobileClock.ViewController
{
    public class MobileClockViewController : ViewController<IClockPresenter, IClockView, ClockView>
    {
        private void Start()
            => _presenter.LoadData();
    }
}

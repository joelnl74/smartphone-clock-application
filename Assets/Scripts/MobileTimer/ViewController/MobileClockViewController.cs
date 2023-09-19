using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;

public class MobileClockViewController : ViewController<IClockPresenter, IClockView, ClockView>
{
    private void Start()
        => _presenter.LoadData();
}

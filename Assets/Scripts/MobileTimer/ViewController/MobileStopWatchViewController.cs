using Core.ViewController;
using MobileClock.Presenter.Interfaces;
using MobileClock.View;
using MobileClock.View.Interfaces;

namespace MobileClock.ViewController
{
    public class MobileStopWatchViewController : ViewController<IStopWatchPresenter, IStopWatchView, StopWatchView>
    {

        private void Start()
        {
            _presenter.LoadData();

            view.startButton.onClick.AddListener(() =>
            {
                _presenter.StartTimer();
            });
            view.stopButton.onClick.AddListener(() =>
            {
                _presenter.Stop();
                _presenter.Reset();
            });
        }
    }
}

using Core.ViewController;
using MobileClock.Presenter.Interfaces;
using MobileClock.View;
using MobileClock.View.Interfaces;
using UniRx;

namespace MobileClock.ViewController
{
    public class MobileStopWatchViewController : ViewController<IStopWatchPresenter, IStopWatchView, StopWatchView>
    {
        private void Start()
        {
            _presenter.LoadData();

            view.actionButton.OnClickAsObservable().Subscribe(_ => { HandleActionButtonPressed(); });
            view.lapButton.OnClickAsObservable().Subscribe(_ => { HandleLapButton(); });
        }

        private void HandleActionButtonPressed()
        {
            switch (view.state)
            {
                case StopWatchState.Start:
                case StopWatchState.Stop:
                    _presenter.StartTimer();
                    break;
                case StopWatchState.Running:
                    _presenter.Stop();
                    break;
            }
        }

        private void HandleLapButton()
        {
            switch (view.state)
            {
                case StopWatchState.Running:
                    _presenter.SetLapTime();
                    break;
                case StopWatchState.Stop:
                    _presenter.Reset();
                    break;
            }
        }
    }
}

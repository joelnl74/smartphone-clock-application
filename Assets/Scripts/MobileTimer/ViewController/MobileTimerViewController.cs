using Core.ViewController;
using MobileClock.Presenter.Interfaces;
using MobileClock.View;
using MobileClock.View.Interfaces;
using UniRx;

namespace MobileClock.ViewController
{
    public class MobileTimerViewController : ViewController<ITimerPresenter, ITimerView, TimerView>
    {
        private void Start()
        {
            _presenter.LoadData();

            SetupIncreateButton();
            SetupDecreaseButton();
            
            view.actionButton.OnClickAsObservable().Subscribe(_ => { HandleActionButtonPressed(); });
            view.resetButton.OnClickAsObservable().Subscribe(_ => { _presenter.Reset(); });
        }

        private void SetupIncreateButton()
        {
            for (var i = 0; i < view.additionButtons.Count; i++)
            {
                var increase = view.additionButtons[i].seconds;
                view.additionButtons[i].button.OnClickAsObservable().Subscribe(_ => { _presenter.IncreaseTimer(increase); });
            }
        }

        private void SetupDecreaseButton()
        {
            for (var i = 0; i < view.decreaseButtons.Count; i++)
            {
                var decrease = view.decreaseButtons[i].seconds;
                view.decreaseButtons[i].button.OnClickAsObservable().Subscribe(_ => { _presenter.DecreaseTimer(decrease); });
            }
        }

        private void HandleActionButtonPressed()
        {
            switch (view.state)
            {
                case TimerViewState.Start:
                case TimerViewState.Stop:
                    _presenter.StartTimer();
                    break;
                case TimerViewState.Running:
                    _presenter.Stop();
                    break;
            }
        }
    }
}


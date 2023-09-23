using Core.Presenter;
using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using UniRx;

namespace MobileClock.Presenter
{
    public abstract class BaseTimerPresenter<TView> : Presenter<TView> where TView : class, IBaseTimerView
    {
        protected const int millisecondsInSecond = 1000;
        protected TimerModel timerModel;

        private readonly ITimerModelMapper _timerModelMapper;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public BaseTimerPresenter(ITimerModelMapper timerModelMapper)
            => _timerModelMapper = timerModelMapper;

        public abstract void UpdateTimer();

        /// <summary>
        /// Base method to start a timers.
        /// </summary>
        public virtual void StartTimer()
        {
            Observable.EveryUpdate().Subscribe(x => UpdateTimer()).AddTo(_disposables);
            _view.DidStartTimer();
        }
        
        /// <summary>
        /// Load starting data.
        /// </summary>
        /// <param name="time">Time in seconds.</param>
        public void LoadData(int time = 0)
        {
            timerModel = _timerModelMapper.MapSingle(time);
            _view.DidLoadData(timerModel);
        }

        /// <summary>
        /// Stop the timers.
        /// </summary>
        public void Stop()
        {
            _disposables.Clear();
            _view.DidStop();
        }
    }
}

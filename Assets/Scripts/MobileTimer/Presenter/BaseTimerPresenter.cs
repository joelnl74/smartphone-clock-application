using Codice.Client.BaseCommands.TubeClient;
using Core.Presenter;
using MobileClock.Mapper;
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

        public void StartTimer()
        {
            timerModel.isRunning = true;
            Observable.EveryUpdate().Subscribe(x => UpdateTimer()).AddTo(_disposables);

            _view.DidStartTimer();
        }
        public void LoadData(int time = 0)
        {
            timerModel = _timerModelMapper.MapSingle(time);
            _view.DidLoadData(timerModel);
        }

        public void Stop()
        {
            _disposables.Clear();
            _view.DidStop();
        }
    }
}

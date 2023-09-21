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
        protected TimerModel timerModel;

        private readonly ITimerModelMapper _timerModelMapper;
        private CompositeDisposable _disposables = new CompositeDisposable();

        public BaseTimerPresenter(ITimerModelMapper timerModelMapper)
        {
            _timerModelMapper = timerModelMapper;
        }

        public abstract void UpdateTimer();

        public void StartTimer()
        {
            Observable.EveryUpdate().Subscribe(x => UpdateTimer()).AddTo(_disposables);
        }

        public void LoadData(float time = 0)
        {
            timerModel = _timerModelMapper.MapSingle(time);
            _view.DidLoadData(timerModel);
        }

        public void Reset()
            => LoadData();

        public void Stop()
        {
            _disposables.Clear();
            LoadData();
        }
    }
}

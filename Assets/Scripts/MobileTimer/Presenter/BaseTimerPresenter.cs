using Core.Presenter;
using MobileClock.Mapper.Interface;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter
{
    public class BaseTimerPresenter<TView> : Presenter<TView> where TView : class, IBaseTimerView
    {
        private readonly ITimerModelMapper _timerModelMapper;

        public BaseTimerPresenter(ITimerModelMapper timerModelMapper)
        {
            _timerModelMapper = timerModelMapper;
        }
        
        public void LoadData(float time = 0)
            => _view.DidLoadData(_timerModelMapper.MapSingle(time));

        public void Reset()
            => LoadData();

        public void Stop()
            => _view.DidStop();
    }
}

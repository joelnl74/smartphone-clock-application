using Core.Presenter;
using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using System;
using UniRx;

namespace MobileClock.Presenter
{
    public class ClockPresenter : Presenter<IClockView>, IClockPresenter
    {
        private ClockModel _clockModel;
        private readonly IClockModelMapper _clockModelMapper;

        public ClockPresenter(IClockModelMapper clockModelMapper)
            => _clockModelMapper = clockModelMapper;

        /// <summary>
        /// Load data and start the clock.
        /// </summary>
        public void LoadData()
        {
            _clockModel = _clockModelMapper.MapSingle();
            Observable.EveryUpdate().Subscribe(x => UpdateClock());
        }

        /// <summary>
        /// Update timer with current date time.
        /// </summary>
        private void UpdateClock()
        {
            _clockModel.currentDateTime = DateTime.Now;
            _view.DidLoadData(_clockModel);
        }
    }
}

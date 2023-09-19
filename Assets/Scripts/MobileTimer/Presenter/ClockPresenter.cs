using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using System;

namespace MobileClock.Presenter
{
    public class ClockPresenter : Presenter<IClockView>, IClockPresenter
    {
        private ClockModel _clockModel;
        private readonly IClockModelMapper _clockModelMapper;

        public ClockPresenter(IClockModelMapper clockModelMapper) 
        {
            _clockModelMapper = clockModelMapper;
        }

        public void LoadData()
        {
            _clockModel = _clockModelMapper.MapSingle();

            _view.DidLoadData(_clockModel);
        }
    }
}

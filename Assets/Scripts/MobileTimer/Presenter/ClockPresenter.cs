using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using System;

namespace MobileClock.Presenter
{
    public class ClockPresenter : Presenter<IClockView>, IClockPresenter
    {
        private ClockModel _clockModel;

        public ClockPresenter() { }

        public void LoadData()
        {
            _clockModel = new ClockModel(DateTime.Now.Ticks);

            _view.DidLoadData(_clockModel);
        }
    }
}

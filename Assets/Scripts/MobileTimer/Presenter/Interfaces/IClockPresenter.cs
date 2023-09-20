using Core.Interfaces;
using MobileClock.View.Interfaces;

namespace MobileClock.Presenter.Interfaces
{
    public interface IClockPresenter : IPresenter<IClockView>
    {
        void LoadData();
    }
}

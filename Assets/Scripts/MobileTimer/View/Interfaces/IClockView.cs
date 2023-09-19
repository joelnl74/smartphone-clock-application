using Core.Interfaces;

namespace MobileClock.View.Interfaces
{
    public interface IClockView : IView
    {
        void DidLoadData(ClockModel clockModel);
    }
}


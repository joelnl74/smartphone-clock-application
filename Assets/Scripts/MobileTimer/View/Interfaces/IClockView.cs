using Core.Interfaces;
using MobileClock.Models;

namespace MobileClock.View.Interfaces
{
    public interface IClockView : IView
    {
        void DidLoadData(ClockModel clockModel);
    }
}


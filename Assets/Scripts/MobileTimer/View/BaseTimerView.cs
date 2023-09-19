using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;

public class BaseTimerView : BaseView
    ,IBaseTimerView
{
    public void DidLoadData(TimerModel timerModel)
    {
    }

    public void DidReset()
    {
    }
}
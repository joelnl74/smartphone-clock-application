using MobileClock.View.Interfaces;
using UnityEngine;

namespace MobileClock.View
{
    public class StopWatchView : BaseTimerView
        , IStopWatchView
    {
        [field: SerializeField] public UIButton startButton;
        [field: SerializeField] public UIButton stopButton;
    }
}

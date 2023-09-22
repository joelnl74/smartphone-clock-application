using Core.UI;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using MobileTimer.View;
using UnityEngine;

namespace MobileClock.View
{
    public enum StopWatchState
    {
        Start,
        Running,
        Stop
    }

    public class StopWatchView : BaseTimerView
        ,IStopWatchView
    {
        public StopWatchState state { get; private set; }

        [field: SerializeField] public UIButton actionButton;
        [field: SerializeField] public UIButton lapButton;

        [SerializeField] private StopWatchLapView _stopWatchLapView;

        private void Start()
            => SetDefaultState();

        public void DidUpdateLapTime(TimerLapModel model)
            => _stopWatchLapView.Add(model);

        public override void DidStartTimer()
        {
            state = StopWatchState.Running;
            SetActiveState();
        }

        public override void DidStop()
        {
            state = StopWatchState.Stop;
            SetPauseState();
        }

        public void DidReset()
        {
            state = StopWatchState.Start;

            SetDefaultState();
            _stopWatchLapView.Clear();
        }

        private void SetDefaultState()
        {
            actionButton.ApplyStle(ButtonStyle.Blue);
            actionButton.SetText("Start");

            lapButton.SetText("Lap");
            lapButton.ApplyStle(ButtonStyle.Grey);
            lapButton.interactable = false;
        }

        private void SetPauseState()
        {
            actionButton.ApplyStle(ButtonStyle.Blue);
            actionButton.SetText("Resume");

            lapButton.SetText("Reset");
            lapButton.interactable = true;
            lapButton.ApplyStle(ButtonStyle.Red);
        }

        private void SetActiveState()
        {
            actionButton.ApplyStle(ButtonStyle.LightBlue);
            actionButton.SetText("Pause");

            lapButton.SetText("Lap");
            lapButton.interactable = true;
            lapButton.ApplyStle(ButtonStyle.Blue);
        }
    }
}

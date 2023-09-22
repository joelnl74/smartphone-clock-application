using Core.UI;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MobileClock.View
{
    public enum TimerViewState
    {
        Start,
        Running,
        Stop
    }
    
    [Serializable]
    public class TimerControlButton
    {
        public UIButton button;
        public int seconds;
    }

    public class TimerView : BaseTimerView
        ,ITimerView
    {
        public TimerViewState state { get; private set; }

        [field: SerializeField] public List<TimerControlButton> additionButtons;
        [field: SerializeField] public List<TimerControlButton> decreaseButtons;
        [field: SerializeField] public UIButton actionButton;
        [field: SerializeField] public UIButton resetButton;

        private void Start()
            => SetDefaultState();

        public void DidSetTimer(TimerModel timerModel)
            => DidLoadData(timerModel);

        public void DidReset()
        {
            state = TimerViewState.Start;
            SetDefaultState();
        }

        public override void DidStartTimer()
        {
            base.DidStartTimer();

            state = TimerViewState.Running;
            SetRunningState();
        }

        public override void DidStop()
        {
            base.DidStop();

            state = TimerViewState.Stop;
            SetPauseState();
        }

        private void SetRunningState()
        {
            actionButton.ApplyStle(ButtonStyle.Red);
            actionButton.SetText("Pause");

            resetButton.gameObject.SetActive(true);
        }

        private void SetPauseState()
        {
            actionButton.ApplyStle(ButtonStyle.LightBlue);
            actionButton.SetText("Resume");
        }

        private void SetDefaultState()
        {
            actionButton.ApplyStle(ButtonStyle.Blue);
            actionButton.SetText("Start");

            resetButton.gameObject.SetActive(false);
        }
    }
}

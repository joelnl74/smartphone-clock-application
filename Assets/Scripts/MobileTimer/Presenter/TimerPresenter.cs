using Audio;
using MobileClock.Mapper.Interface;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using System;
using UnityEngine;
using Zenject;

namespace MobileClock.Presenter
{
    public class TimerPresenter : BaseTimerPresenter<ITimerView>,
        ITimerPresenter
    {
        private readonly SignalBus _signalBus;

        public TimerPresenter(ITimerModelMapper timerModelMapper, SignalBus signalBus) : base(timerModelMapper)
            => _signalBus = signalBus;

        /// <summary>
        /// Start timer.
        /// </summary>
        public override void StartTimer()
        {
            if (timerModel.timeSpan.TotalSeconds <= 0)
            {
                return;
            }

            base.StartTimer();
        }

        /// <summary>
        /// Increase timer.
        /// </summary>
        /// <param name="time">Time in seconds to increase.</param>
        public void IncreaseTimer(int time)
        {
            timerModel.timeSpan = timerModel.timeSpan.Add(new TimeSpan(0, 0, time));
            _view.DidLoadData(timerModel);
        }

        /// <summary>
        /// Decrease timer.
        /// </summary>
        /// <param name="time">Time in seconds to decrease.</param>
        public void DecreaseTimer(int time)
        {
            if (timerModel.timeSpan.TotalSeconds - time < 0)
            {
                return;
            }
            
            timerModel.timeSpan = timerModel.timeSpan.Subtract(new TimeSpan(0, 0, time));
            _view.DidLoadData(timerModel);
        }

        /// <summary>
        /// Reset the timers.
        /// </summary>
        public void Reset()
        {
            Stop();
            LoadData();

            _view.DidReset();
        }
        
        /// <summary>
        /// Update the timer.
        /// </summary>
        public override void UpdateTimer()
        {
            var ms = millisecondsInSecond * Time.deltaTime;

            timerModel.timeSpan = timerModel.timeSpan.Subtract(new TimeSpan(0, 0, 0, 0, (int)ms));

            if (timerModel.timeSpan.Seconds <= 0)
            {
                HandleTimerFinished();
                
                return;
            }
            
            _view.DidLoadData(timerModel);
        }

        private void HandleTimerFinished()
        {
            Reset();

            _signalBus.Fire(new PlayAudioSignal { audioType = Audio.AudioType.Alarm });
        }
    }
}


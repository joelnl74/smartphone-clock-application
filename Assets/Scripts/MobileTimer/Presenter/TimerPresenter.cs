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
        {
            _signalBus = signalBus;
        }

        public void IncreaseTimer(int time)
        {
            timerModel.timeSpan = timerModel.timeSpan.Add(new TimeSpan(0, 0, time));
            _view.DidLoadData(timerModel);
        }

        public void DecreaseTimer(int time)
        {
            if (timerModel.timeSpan.Seconds - time < 0)
            {
                return;
            }
            
            timerModel.timeSpan = timerModel.timeSpan.Subtract(new TimeSpan(0, 0, time));
            _view.DidLoadData(timerModel);
        }

        public void Reset()
        {
            LoadData();
        }
        
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
            Stop();
            Reset();

            _signalBus.Fire(new PlayAudioSignal { audioType = Audio.AudioType.Alarm });
            _view.DidReset();
            LoadData();
        }
    }
}


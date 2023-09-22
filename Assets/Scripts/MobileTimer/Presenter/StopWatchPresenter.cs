using MobileClock.Mapper.Interface;
using MobileClock.Models;
using MobileClock.Presenter.Interfaces;
using MobileClock.View.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MobileClock.Presenter
{
    public class StopWatchPresenter : BaseTimerPresenter<IStopWatchView>,
        IStopWatchPresenter
    {
        private readonly ITimerLapModelMapper _mapper;
        private List<TimerLapModel> _timerLapModels = new List<TimerLapModel>();

        public StopWatchPresenter(ITimerModelMapper timerModelMapper, ITimerLapModelMapper timerLapModelMapper) : base(timerModelMapper)
        {
            _mapper = timerLapModelMapper;
        }

        public void SetLapTime()
        {
            var model = _mapper.MapSingle(timerModel, _timerLapModels);
            _timerLapModels.Add(model);
            _view.DidUpdateLapTime(model);
        }

        public void Reset()
        {
            _timerLapModels.Clear();

            LoadData();
            _view.DidReset();
        }

        public override void UpdateTimer()
        {
            var ms = millisecondsInSecond * Time.deltaTime;
            
            timerModel.timeSpan = timerModel.timeSpan.Add(new TimeSpan(0, 0, 0, 0, (int)ms));
            _view.DidLoadData(timerModel);
        }
    }
}


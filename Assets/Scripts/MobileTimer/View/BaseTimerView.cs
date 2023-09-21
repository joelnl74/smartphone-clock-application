using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using System;
using TMPro;
using UnityEngine;

namespace MobileClock.View
{
    public class BaseTimerView : BaseView
    , IBaseTimerView
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        public void DidLoadData(TimerModel timerModel)
            => _timerText.text = $"{new TimeSpan(0, 0, (int)timerModel.Time):t}";

        public void DidReset()
        {
        }

        public void DidStop()
        {
        }
    }
}

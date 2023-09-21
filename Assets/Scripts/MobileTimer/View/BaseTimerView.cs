using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using TMPro;
using UnityEngine;

namespace MobileClock.View
{
    public class BaseTimerView : BaseView
        ,IBaseTimerView
    {
        [SerializeField] private string formatString;
        [SerializeField] private TextMeshProUGUI _timerText;

        public void DidLoadData(TimerModel timerModel)
            => _timerText.text = timerModel.timeSpan.ToString(formatString);

        public virtual void DidStartTimer() { }

        public virtual void DidStop(){ }
    }
}

using Core.View;
using MobileClock.Models;
using MobileClock.View.Interfaces;
using TMPro;
using UnityEngine;

namespace MobileClock.View
{
    public class ClockView : BaseView, IClockView
    {
        [SerializeField] private TextMeshProUGUI _localTimeText;

        public void DidLoadData(ClockModel clockModel)
            => _localTimeText.text = clockModel.currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
    }
}

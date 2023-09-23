using MobileClock.Models;
using MobileClock.View.Interfaces;
using TMPro;
using UnityEngine;

namespace MobileClock.View
{
    public class StopWatchLapTimeCellView : MonoBehaviour
        ,IStopWatchLapTimeCellView
    {
        [SerializeField] TextMeshProUGUI _lapTimeText;

        /// <summary>
        /// Called once a timer model has been created.
        /// </summary>
        /// <param name="timerLapModel">Timer lap model.</param>
        public void Configure(TimerLapModel timerLapModel)
            => _lapTimeText.text = timerLapModel.lapTimeSpan.ToString(@"hh\:mm\:ss\:ff");
    }
}

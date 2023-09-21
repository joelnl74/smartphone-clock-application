using MobileClock.Models;
using TMPro;
using UnityEngine;

namespace MobileClock.View
{
    public class StopWatchLapTimeCellView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _lapTimeText;

        public void Configure(TimerLapModel timerLapModel)
            => _lapTimeText.text = timerLapModel.lapTimeSpan.ToString(@"hh\:mm\:ss\:ff");
    }
}

using Core.Pooling;
using MobileClock.Models;
using MobileClock.View;
using MobileClock.View.Interfaces;
using UnityEngine;

namespace MobileTimer.View
{   
    public class StopWatchLapView : MonoBehaviour
        ,IStopWatchLapView
    {
        [SerializeField] private int _startingPool = 10;
        [SerializeField] RectTransform _content;
        [SerializeField] StopWatchLapTimeCellView _entry;

        private BaseObjectPool<StopWatchLapTimeCellView> _objectPool;

        private void Start()
        {
            _objectPool = new BaseObjectPool<StopWatchLapTimeCellView>();
            _objectPool.Configure(_entry, _content, _startingPool);
        }

        /// <summary>
        /// Add/Create timer lap view.
        /// </summary>
        /// <param name="timerLapModel"></param>
        public void Add(TimerLapModel timerLapModel)
        { 
            var cell = _objectPool.Get();
            cell.Configure(timerLapModel);
        }

        /// <summary>
        /// Clear all views and pool them.
        /// </summary>
        public void Clear()
            => _objectPool.ReleaseAll();
    }
}

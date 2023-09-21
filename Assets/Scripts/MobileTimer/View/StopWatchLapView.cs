using Core.Pooling;
using MobileClock.Models;
using MobileClock.View;
using UnityEngine;

namespace MobileTimer.View
{   
    public class StopWatchLapView : MonoBehaviour
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

        public void Add(TimerLapModel timerLapModel)
        { 
            var cell = _objectPool.pool.Get();
            cell.Configure(timerLapModel);
        }

        public void Clear()
            => _objectPool.ReleaseAll();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Core.UI
{
    public class UITabView : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private List<UIButton> _buttons;
        [SerializeField] private float _scrollAnimationDuration = 0.25f;

        private int _currentIndex = 0;

        private void Awake()
        {
            for (var i = 0; i < _buttons.Count; i++)
            {
                var index = i;

                _buttons[i].onClick.AsObservable().Subscribe(_ => StartCoroutine(ScrollTo(index, _scrollAnimationDuration)));
                _buttons[i].ApplyStle(ButtonStyle.Blue);
            }

            _buttons[_currentIndex].ApplyStle(ButtonStyle.LightBlue);
        }

        private IEnumerator ScrollTo(int index, float duration)
        {
            var endXPos = (float)index * 1 / (_buttons.Count - 1);
            var endPositionX = new Vector2(endXPos, 0);
            var time = 0.0f;

            while (time < duration)
            {
                time += Time.deltaTime;
                var percent = Mathf.Clamp01(time / duration);

                _scrollRect.normalizedPosition = Vector3.Lerp(_scrollRect.normalizedPosition, endPositionX, percent);

                yield return null;
            }

            SetButtonState(_currentIndex, index);
            _currentIndex = index;
        }

        private void SetButtonState(int from, int to)
        {
            _buttons[from].ApplyStle(ButtonStyle.Blue);
            _buttons[to].ApplyStle(ButtonStyle.LightBlue);
        }
    }
}

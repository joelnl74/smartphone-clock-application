using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Core.View;
using Core.UI.View.Interfaces;

namespace Core.UI.View
{
    public class UITabView : BaseView
        , IUITabview
    {
        [field: SerializeField] public List<UIButton> buttons;
        [field: SerializeField] public UIButton closeGameButton;

        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private float _scrollAnimationDuration = 0.25f;

        public void DidChangePage(int from, int to)
            => ChangePageAnimation(from, to).ToObservable();

        private IEnumerator ChangePageAnimation(int from, int to)
        {
            var endXPos = (float)to * 1 / (buttons.Count - 1);
            var endPositionX = new Vector2(endXPos, 0);
            var time = 0.0f;

            while (time < _scrollAnimationDuration)
            {
                time += Time.deltaTime;
                var percent = Mathf.Clamp01(time / _scrollAnimationDuration);

                _scrollRect.normalizedPosition = Vector3.Lerp(_scrollRect.normalizedPosition, endPositionX, percent);

                yield return null;
            }

            SetButtonState(from, to);
        }

        private void SetButtonState(int from, int to)
        {
            buttons[from].ApplyStle(ButtonStyle.Blue);
            buttons[to].ApplyStle(ButtonStyle.LightBlue);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class UITabView : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private List<UIButton> _buttons;
    [SerializeField] private float _scrollAnimationDuration = 0.25f;

    private void Awake()
    {
        for (var i = 0; i < _buttons.Count; i++) 
        {
            var index = i;

            _buttons[i].onClick.AsObservable().Subscribe(_ => StartCoroutine(ScrollTo(index, _scrollAnimationDuration)));
        }
    }

    public IEnumerator ScrollTo(int index, float duration)
    {
        var endXPos = (float)index * 1 / (_buttons.Count - 1);
        var endPositionX = new Vector2(endXPos, 0);
        var time = 0.0f;

        while (time < 0.2f)
        {
            time += Time.deltaTime;
            var percent = Mathf.Clamp01(time / duration);

            _scrollRect.normalizedPosition = Vector3.Lerp(_scrollRect.normalizedPosition, endPositionX, percent);

            yield return null;
        }
    }
}

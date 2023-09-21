using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UITabViewController : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private List<UIButton> _buttons;

    private void Awake()
    {
        for (var i = 0; i < _buttons.Count; i++) 
        {
            var index = i;

            _buttons[i].onClick.AsObservable().Subscribe(_ => StartCoroutine(ScrollTo(index)));
        }
    }

    // TODO convert to UniRX + Create animation.
    public IEnumerator ScrollTo(int index)
    {
        yield return new WaitForEndOfFrame();

        var xPos = (float)index * 1 / (_buttons.Count - 1);

        _scrollRect.normalizedPosition = new Vector2(xPos, 0);
    }
}

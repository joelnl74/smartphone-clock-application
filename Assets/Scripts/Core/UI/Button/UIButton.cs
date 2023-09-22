using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public enum ButtonStyle
    {
        None = 0,
        Blue = 1,
        Red = 2,
        Green = 3,
        Grey = 4,
        LightBlue = 5
    }
    
    public class UIButton : Button
    {
        [SerializeField] private ButtonStyleDefinitionCollection _buttonStyleDefinitionCollection;
        [SerializeField] private TextMeshProUGUI _text;
        
        public void ApplyStle(ButtonStyle buttonStyle)
        {
            var definition = _buttonStyleDefinitionCollection.Get(buttonStyle);
            image.sprite = definition.sprite;
        }

        public void SetText(string text)
            => _text.text = text;
    }
}


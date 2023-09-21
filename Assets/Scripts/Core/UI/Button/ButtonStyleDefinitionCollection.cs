using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.UI
{
    [CreateAssetMenu(menuName = "UI/Button/StyleCollection")]
    public class ButtonStyleDefinitionCollection : ScriptableObject
    , IButtonStyleDefintionCollection
    {
        [SerializeField] private List<ButtonStyleDefinition> _buttonStyleList;

        public ButtonStyleDefinition Get(ButtonStyle style)
            => _buttonStyleList.FirstOrDefault(x => x.style == style);
    }
}

using Core.UI.Presenter.Interfaces;
using Core.UI.View;
using Core.UI.View.Interfaces;
using Core.ViewController;
using System.Linq;
using UniRx;

namespace Core.UI.ViewController
{
    public class MainTabViewController : ViewController<IMainUIPresenter, IUITabview, UITabView>
    {
        private void Awake()
        {
            for (var i = 0; i < view.buttons.Count; i++)
            {
                var index = i;

                view.buttons[i].onClick.AsObservable().Subscribe(_ => _presenter.ChangePage(index));
                view.buttons[i].ApplyStle(ButtonStyle.Blue);
            }

            view.closeGameButton.onClick.AsObservable().Subscribe(_ => _presenter.CloseApplication());
            view.buttons.First().ApplyStle(ButtonStyle.LightBlue);
        }
    }
}

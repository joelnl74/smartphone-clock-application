using Core.Interfaces;
using UnityEngine;
using Zenject;

public class ViewController<TPresenter, TIView, TBaseView> : MonoBehaviour
    where TIView : IView
    where TBaseView : TIView
    where TPresenter : IPresenter<TIView>
{
    [SerializeField] private TBaseView _baseView;
    protected TPresenter _presenter;

    [Inject]
    public void Constructor(TPresenter presenter)
    { 
        _presenter = presenter;
        _presenter.Bind(_baseView);
    }
}

using Core.Interfaces;
using System.Collections;

namespace Core.UI.View.Interfaces
{
    public interface IUITabview : IView
    {
        void DidChangePage(int from, int to);
    }
}

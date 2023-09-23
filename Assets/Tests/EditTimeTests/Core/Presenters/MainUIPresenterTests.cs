using Core.UI.Presenter;
using Core.UI.View.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Linq;

namespace Tests.Core.UI
{
    [TestFixture]
    public class MainUIPresenterTests
    {
        [Test]
        public void View_NotInvoked()
        {
            // Arrange.
            var view = Substitute.For<IUITabview>();
            var sut = new MainUIPresenter();

            // Act.
            sut.Bind(view);

            // Assert.
            Assert.That(view.ReceivedCalls().Count(), Is.EqualTo(0));
        }

        [TestCase(1, 0, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(3, 0, 3)]
        public void View_DidChangePage_Invoked(int index, int from, int to)
        {
            // Arrange.
            var view = Substitute.For<IUITabview>();
            var sut = new MainUIPresenter();

            sut.Bind(view);

            // Act.
            sut.ChangePage(index);

            // Assert.
            view.Received(1).DidChangePage(from, to);
        }

        [Test]
        public void Presenter_DidCallApplicationQuit_Invoked()
        {
            // Arrange.
            var presenter = Substitute.For<MainUIPresenter>();

            // Act.
            presenter.CloseApplication();

            // Assert.
            presenter.Received(1).CloseApplication();
        }
    }
}

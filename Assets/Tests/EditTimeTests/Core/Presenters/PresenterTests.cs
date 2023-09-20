using Core.Interfaces;
using Core.Presenter;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Core.Presenter
{
    public interface IMockView : IView { }
    public class MockPresenter : Presenter<IMockView> {}

    public class PresenterTests
    {
        [Test]
        public void Presenter_Bind_View_Correctly()
        {
            // Arrange.
            var view = Substitute.For<IMockView>();
            var presenter = Substitute.For<MockPresenter>();

            // Act.
            presenter.Bind(view);

            // Assert.
            presenter.Received(1).Bind(Arg.Any<IMockView>());
        }
    }
}

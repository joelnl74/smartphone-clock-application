using Core.Interfaces;
using Core.View;
using Core.ViewController;
using NSubstitute;
using NUnit.Framework;

namespace Tests.Core.ViewController
{
    public class ViewControllerTests
    {
        public interface IMockView : IView { }
        public interface IMockPresenter : IPresenter<IMockView> { }

        public class MockView : BaseView, IMockView { }
        public class MockViewController : ViewController<IMockPresenter, IMockView, MockView> { }

        [Test]
        public void Presenter_Bind_View_Correctly()
        {
            // Arrange.
            var presenter = Substitute.For<IMockPresenter>();
            var sut = Substitute.For<MockViewController>();

            // Act.
            sut.Constructor(presenter);

            // Assert.
            sut.Received(1).Constructor(Arg.Any<IMockPresenter>());
        }
    }
}

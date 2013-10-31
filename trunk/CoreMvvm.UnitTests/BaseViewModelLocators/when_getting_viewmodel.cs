using Castle.Windsor;
using CoreIoC;
using CoreTest;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace CoreMvvm.UnitTests.BaseViewModelLocators
{
    [TestFixture]
    public class when_getting_viewmodel : BaseTest
    {
        private TestViewModelLocator _viewModelLocator;
        private TestViewModel _viewModel;

        [SetUp]
        public void Context()
        {
            _viewModel = new TestViewModel();
            var container = Stub<IWindsorContainer>().Stubs(x => x.Resolve<TestViewModel>()).Returns(_viewModel);
            IoC.Initialize(container);
            _viewModelLocator = new TestViewModelLocator();
        }

        [Test]
        public void viewmodel_is_correct()
        {
            _viewModelLocator.ViewModel.ShouldBe(_viewModel);
        }

        [TearDown]
        public void TearDown()
        {
            IoC.Initialize(null);
        }

        private class TestViewModel : NotifyingObject
        {            
        }

        private class TestViewModelLocator : BaseViewModelLocator<TestViewModel>
        {            
        }
    }
}

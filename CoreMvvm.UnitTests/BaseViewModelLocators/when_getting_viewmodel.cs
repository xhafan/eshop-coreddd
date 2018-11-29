using CoreIoC;
using NUnit.Framework;
using Rhino.Mocks;
using Shouldly;

namespace CoreMvvm.UnitTests.BaseViewModelLocators
{
    [TestFixture]
    public class when_getting_viewmodel
    {
        private TestViewModelLocator _viewModelLocator;
        private TestViewModel _viewModel;

        [SetUp]
        public void Context()
        {
            _viewModel = new TestViewModel();
            var container = MockRepository.GenerateStub<IContainer>();
            container.Stub(x => x.Resolve<TestViewModel>()).Return(_viewModel);

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

        private class TestViewModel : BaseViewModel
        {            
        }

        private class TestViewModelLocator : BaseViewModelLocator<TestViewModel>
        {            
        }
    }
}

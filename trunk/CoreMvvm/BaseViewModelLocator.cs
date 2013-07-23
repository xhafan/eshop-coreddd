using CoreIoC;

namespace CoreMvvm
{
    // http://blog.roboblob.com/2010/01/17/wiring-up-view-and-viewmodel-in-mvvm-and-silverlight-4-blendability-included/
    public abstract class BaseViewModelLocator<TViewModel> where TViewModel : NotifyingObject
    {
        private TViewModel _viewModel;

        public TViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = IoC.Resolve<TViewModel>()); }
        }
    }
}


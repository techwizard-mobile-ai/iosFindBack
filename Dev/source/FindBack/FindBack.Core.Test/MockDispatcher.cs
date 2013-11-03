using System;
using System.Collections.Generic;
using Cirrious.CrossCore.Core;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace FindBack.Core.Test
{
    public class MockDispatcher
        : MvxMainThreadDispatcher 
          , IMvxViewDispatcher
    {
        public List<IMvxViewModel> CloseRequests = new List<IMvxViewModel>();
        public readonly List<MvxViewModelRequest> NavigateRequests = new List<MvxViewModelRequest>();

        public bool RequestMainThreadAction(Action action)
        {
            action();
            return true;
        }

        public bool RequestClose(IMvxViewModel whichViewModel)
        {
            CloseRequests.Add(whichViewModel);
            return true;
        }

        public bool ShowViewModel(MvxViewModelRequest request)
        {
            NavigateRequests.Add(request);
            return true;
        }

        public bool ChangePresentation(MvxPresentationHint hint)
        {
            throw new NotImplementedException();
        }
    }
}
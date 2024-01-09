using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Manager_UI.ViewModel
{
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Collections.Generic;
    using Video_Manager_UI.Model;

    class VideoManagerViewModel
    {
        private String? _content;
        private VideoManagerModel _videoManager;

        public VideoManagerViewModel()
        {
            _content = "App Init!";
            _videoManager = new VideoManagerModel();
        }

        public String? Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private ICommand mFetcher;

        public ICommand FetchCommand
        {
            get
            {
                if (mFetcher == null)
                    mFetcher = new Fetcher(_videoManager);
                return mFetcher;
            }
            set
            {
                mFetcher = value;
            }
        }

        private class Fetcher : ICommand
        {
            private VideoManagerModel _videoManager;

            public Fetcher(VideoManagerModel videoManagerModel) 
            {
                this._videoManager = videoManagerModel;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                _videoManager.FetchFiles();
            }
        }
    }
}

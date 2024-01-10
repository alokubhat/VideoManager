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

    class VideoManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private VideoManagerModel _videoManager;

        public VideoManagerViewModel()
        {
            _videoManager = new VideoManagerModel();
            _videoManager.PropertyChanged += OnPropertyChanged;
        }

        public String? Content
        {
            get { return _videoManager.Content; }
            set { _videoManager.Content = value; }
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

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(e.PropertyName));
            }
        }
    }
}

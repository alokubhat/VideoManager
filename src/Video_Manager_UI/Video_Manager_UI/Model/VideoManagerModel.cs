using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOpsAdapter;

namespace Video_Manager_UI.Model
{
    using System.ComponentModel;

    public class VideoManagerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private String? content;
        public String? Content {
            get 
            {
                return this.content;
            }
            set
            {
                this.content = value;
                OnPropertyChanged("Content");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void FetchFiles() {
            DatabaseOpsAdapter.DatabaseOpsAdapter databaseOpsAdapter = new DatabaseOpsAdapter.DatabaseOpsAdapter();
            var content = databaseOpsAdapter.GetVideoDetails().Result;
            Content = content;
        }
    }
}

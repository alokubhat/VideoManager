using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseOpsAdapter;

namespace Video_Manager_UI.Model
{
    using System.ComponentModel;
    using System.Windows.Input;

    public class VideoManagerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private String? content = "Init string";
        public String? Content {
            get 
            {
                return this.content;
            }
            set
            {
                this.content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        private DatabaseOpsAdapter.DatabaseOpsAdapter databaseOpsAdapter;
        public VideoManagerModel()
        {
            databaseOpsAdapter = new DatabaseOpsAdapter.DatabaseOpsAdapter();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void FetchFiles() {
            var content = databaseOpsAdapter.GetVideoDetails().Result;
            Content = content.ToString();
        }
    }
}

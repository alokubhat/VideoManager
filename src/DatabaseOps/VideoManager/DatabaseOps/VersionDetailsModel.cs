using System.ComponentModel.DataAnnotations;

namespace DatabaseOps
{
    public class VersionDetailsModel
    {
        public int Id
        {
            get;
            set;
        }

        public int File_Id
        {
            get;
            set;
        }

        public int VersionNum
        {
            get;
            set;
        }

        public string? FilePath
        {
            get;
            set;
        }

        public DateTime UploadedOn
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }

        public string? SizeInKB
        {
            get;
            set;
        }

        public int TimeInSecs
        {
            get;
            set;
        }

        public string? Comment
        {
            get;
            set;
        }
    }
}

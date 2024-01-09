using DatabaseOps.TableSpecs;
using System.ComponentModel.DataAnnotations;

namespace DatabaseOps
{
    public class FileDetailsModel
    {
        public int Id
        {
            get;
            set;
        }

        public string? FileName
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public virtual ICollection<VersionDetailsModel> Versions
        {
            get;
            set;
        }
    }
}

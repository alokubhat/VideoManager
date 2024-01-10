using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOpsAdapter.Models
{
    public class VersionDetails
    {
        public int id
        {
            get;
            set;
        }

        public int file_Id
        {
            get;
            set;
        }

        public int versionNum
        {
            get;
            set;
        }

        public String filePath
        {
            get;
            set;
        }

        public DateTime uploadedOn
        {
            get;
            set;
        }

        public DateTime modifiedOn
        {
            get;
            set;
        }

        public String sizeInKB
        {
            get;
            set;
        }

        public int timeInSecs
        {
            get;
            set;
        }

        public String comment
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseOpsAdapter.Models
{
    public class FileDetails
    {
        public int id
        {
            get;
            set;
        }

        public String fileName
        {
            get;
            set;
        }

        public String description
        {
            get;
            set;
        }

        public virtual List<VersionDetails> versions
        {
            get;
            set;
        }
    }
}

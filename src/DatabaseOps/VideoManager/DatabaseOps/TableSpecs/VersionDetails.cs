namespace DatabaseOps.TableSpecs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("version_details")]
    public class VersionDetails
    {
        [Key, Required]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public int VersionNum
        {
            get;
            set;
        }

        [Required]
        public string? FilePath
        {
            get;
            set;
        }

        [Required]
        public DateTime UploadedOn
        {
            get;
            set;
        }

        [Required]
        public DateTime ModifiedOn
        {
            get;
            set;
        }

        [Required]
        public string? SizeInKB
        {
            get;
            set;
        }

        [Required]
        public int TimeInSecs
        {
            get;
            set;
        }

        [Required]
        public string? Comment
        {
            get;
            set;
        }

        [Required]
        public virtual FileDetails File
        {
            get;
            set;
        }
    }
}

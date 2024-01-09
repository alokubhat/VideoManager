namespace DatabaseOps.TableSpecs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("file_details")]
    public class FileDetails
    {
        [Key, Required]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string? FileName
        {
            get;
            set;
        }

        [Required]
        public string? Description
        {
            get;
            set;
        }
    }
}

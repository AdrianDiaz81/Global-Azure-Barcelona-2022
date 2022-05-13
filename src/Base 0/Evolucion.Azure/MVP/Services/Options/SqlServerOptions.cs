using System.ComponentModel.DataAnnotations;

namespace MVP.Services.Options
{
    public class SqlServerOptions
    {
        public const string OptionsName = "SqlDb";
        [Required]
        public string ConnectionString { get; set; }
        [Required]
        public string AvengersTableName { get; set; }
    }
}

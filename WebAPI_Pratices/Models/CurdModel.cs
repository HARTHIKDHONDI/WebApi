using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;
namespace WebAPI_Pratices.Models
{
    public class CurdModel
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailID { get; set; }
        public long Mobile { get; set; }
        public string Gender { get; set; }
        public string TypeOfWork { get; set; }
        public string Password { get; set; }    
        public string Status { get; set; }
    }
}

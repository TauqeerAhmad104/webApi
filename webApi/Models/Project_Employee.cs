using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Project_Employee
    {
        [Key]
        public int Id { get; set; }
        public int project_Id { get; set; }
        public int Employee_id { get; set; }

        [ForeignKey("project_Id")]
        public virtual Projects Projects { get; set; }
        [ForeignKey("Employee_id")]
        public virtual Employees Employees { get; set; }
        // try creating controller
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Projects
    {
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ClintName { get; set; }
        public string InitiationDate { get; set; }
        public string? duration { get; set; }

      //  public ICollection<Employee_Project> EmployeeProject { get; set; }

     //   [NotMapped]
     //   public List <int> EmployeeIds { get; set; }


        /* project name, client name, duration, initiation date */
    }
}

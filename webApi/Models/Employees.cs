using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string DateOfBirth { get; set; }
        public string phoneNo { get; set; }
      
        public string Position { get; set; }


        [NotMapped]
        public string name
        {
            get
            {
                return firstName + " " + lastName;
            }

            //  public ICollection<Employee_Project> EmployeeProject { get; set; }
        }
    }
}

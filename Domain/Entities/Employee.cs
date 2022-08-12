using Domain.Base;

namespace Domain.Entities
{
    public class Employee:BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }  
        public string LastName { get; set; }
    }
}

namespace Business.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName  { get; set; }
        public string LastName { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }


    }
}

namespace Business.DTO
{
    public class ReturnObjectDTO
    {
        public ReturnObjectDTO()
        {
            isSuccess = true;
            errorMessage = "";
        }
        public bool isSuccess { get; set; }
        public string successMessage { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
}

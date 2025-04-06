namespace IntraNet.Models
{
    public class EmployeeQuery
    {
        public string SearchPhrase { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}

namespace IntraNet.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int FirstItemNumber { get; set; }
        public int LastItemNumber { get; set; }
        public int ItemsCount { get; set; }
        public PagedResult(List<T> items,int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            ItemsCount = totalCount;
            FirstItemNumber = pageSize * (pageNumber - 1)+1;
            LastItemNumber = FirstItemNumber + pageSize - 1;
            TotalPages = (int)Math.Ceiling(totalCount/(double)pageSize);
        }
    }
}

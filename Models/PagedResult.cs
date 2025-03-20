namespace IntraNet.Models
{
    public class PagedResult<T>
    {
        public List<T> Results { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalPages { get; set; }
        public int TotalResultsCount { get; set; }

        public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
        {
            Results = items;
            TotalResultsCount = totalCount;
            ItemsFrom = pageSize*(pageNumber-1)+1;
            ItemsTo = ItemsFrom + pageSize-1;
            TotalPages =(int)Math.Ceiling(totalCount/(double)pageSize);
            
        }
    }
}

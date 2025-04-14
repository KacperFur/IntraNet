namespace IntraNet.Extensions
{
    public static class IQueryableExtentions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> value, int pageNumber,  int pageSize)
        {
            return value.Skip(pageNumber-1).Take(pageSize);
        }
    }
}

namespace Application.Common
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalItems { get; set; }         // Total de registros sin paginar
        public int PageNumber { get; set; }         // Página actual
        public int PageSize { get; set; }           // Cantidad de ítems por página
        public int TotalPages =>
            (int)Math.Ceiling((double)TotalItems / PageSize);  // Total de páginas

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;

        public PagedResponse(List<T> data, int totalItems, int pageNumber, int pageSize)
        {
            Data = data;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}

namespace BookStore.Filters
{
    public class SortViewModel
    {
        public SortState LastNameSort { get; private set; }
        public SortState OrderSort { get; private set; }
        public SortState Current { get; private set; }
 
        public SortViewModel(SortState sortOrder)
        {
            LastNameSort = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
            OrderSort = sortOrder == SortState.OrderAsc ? SortState.OrderDesc : SortState.OrderAsc;
            Current = sortOrder;
        }
    }
}
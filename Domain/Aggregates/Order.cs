namespace Domain.Aggregates
{
    public class Order : BaseEntity, IAggregateRoot
    {
        private List<OrderSelectedItem> orderSelectedItems;
        public IReadOnlyCollection<OrderSelectedItem> OrderSelectedItems => orderSelectedItems.AsReadOnly();

        private Order() { orderSelectedItems = new List<OrderSelectedItem>(); }
        internal Order(string username, List<UserFavoritedItem> userFavoritedItems)
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            CreatedBy = username;
            orderSelectedItems = userFavoritedItems.Select(i => OrderSelectedItem.Create(i.ItemId, Id)).ToList();
        }

        public static Order Create(string username, List<UserFavoritedItem> userFavoritedItems)
        {
            return new Order(username, userFavoritedItems);
        }
    }
}
 
namespace Domain.Aggregates
{
    public class OrderSelectedItem : BaseEntity
    {
        public Guid SelectedItemId { get; private set; }
        public Guid OrderId { get; private set; }
        private OrderSelectedItem() { }
        private OrderSelectedItem(Guid selectedItemId, Guid orderId) 
        {
            Id = Guid.NewGuid();
            SelectedItemId = selectedItemId;
            OrderId = orderId;
        }
        public static OrderSelectedItem Create(Guid selectedItemId, Guid orderId)
        {
            return new OrderSelectedItem(selectedItemId, orderId);
        }
    }
}

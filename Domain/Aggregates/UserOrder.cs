namespace Domain.Aggregates
{
    public class UserOrder : BaseEntity
    {
        public Guid OrderId { get; private set; }
        public string UserId { get; private set; }
        private UserOrder() { }
        private UserOrder(Guid orderId, string userId) 
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            UserId = userId;
        }
        public static UserOrder Create(Guid orderId, string userId)
        {
            return new UserOrder(orderId, userId);
        }
    }
}

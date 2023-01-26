namespace Domain.ValueObjects.Item
{
    public class Comments : ValueObject
    {
        public IEnumerable<string> CommentList { get; private set; }

        internal Comments(IEnumerable<string> commentList)
        {
            CommentList = commentList;
        }

        public static Comments Create(IEnumerable<string> commentList)
        {
            return new Comments(commentList);
        }
    }
}

namespace Bargain.Domain.Model
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; } = 0;
        public int ItemRef { get; set; }
        public Item Item { get; set; }
        public ICollection<UserRatingLike> UserRatingLikes { get; set; }
        public ICollection<UserRatingDislike> UserRatingDislikes { get; set; }
    }
}
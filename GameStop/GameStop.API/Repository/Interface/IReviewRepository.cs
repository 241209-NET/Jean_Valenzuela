using GameStop.API.Model;

namespace GameStop.API.Repository;

public interface IReviewRepository
{
    Review CreateNewReview(Review order);
    IEnumerable<Review> GetReviews(int id);
}
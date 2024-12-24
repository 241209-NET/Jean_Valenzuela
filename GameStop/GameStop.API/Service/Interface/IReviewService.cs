using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IReviewService
{
    Review CreateNewReview(Review order);
    IEnumerable<Review> GetReviews(int gameId);
    Review? GetReviewById(int id);
    Review? UpdateReview(int id, Review order);
    Review? DeleteReviewById(int id);
}
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IReviewService
{
    Review CreateNewReview(Order order);
    IEnumerable<Review> GetReviews();
    Review GetReviewById(int id);
    Review UpdateReview(int id, Order order);
    Review DeleteReviewById(int id);
}
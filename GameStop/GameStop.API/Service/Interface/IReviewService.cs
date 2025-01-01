using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IReviewService
{
    Review CreateReview(ReviewDTO order, int GameId, int AccountId);
    IEnumerable<Review> GetReviews(int gameId);
    Review? GetReviewById(int id);
    Review? UpdateReview(int id, ReviewDTO order);
    Review? DeleteReviewById(int id);
}
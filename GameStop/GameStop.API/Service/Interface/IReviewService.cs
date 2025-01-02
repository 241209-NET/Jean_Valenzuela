using GameStop.API.DTO;
using GameStop.API.Model;

namespace GameStop.API.Service;

public interface IReviewService
{
    ReviewDTO CreateReview(ReviewDTO order, int GameId, int AccountId);
    IEnumerable<ResponseReviewDTO> GetReviews(int gameId);
}
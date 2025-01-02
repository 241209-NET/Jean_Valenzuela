using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository) => _reviewRepository = reviewRepository;
    
    public ReviewDTO CreateReview(ReviewDTO _review, int GameId, int AccountId)
    {
        Review review = new(){
            AccountId = AccountId,
            GameId = GameId,
            Account = null,
            Game = null
        };
        DTOToEntityRequest<ReviewDTO, Review>.ToEntity(_review, review);

        var review_res = _reviewRepository.CreateNewReview(review);

        ReviewDTO res = new();

        EntityToDTORequest<Review,ReviewDTO>.ToDTO(review_res, res);

        return res;
    }

    public IEnumerable<ResponseReviewDTO> GetReviews(int id)
    {
        var reviews = _reviewRepository.GetReviews(id);

        List<ResponseReviewDTO> res = [];

        foreach (Review review in reviews)
        {
            ResponseReviewDTO dto = new()
            {
                Account = new()
            };

            EntityToDTORequest<Review, ResponseReviewDTO>.ToDTO(review, dto);

            EntityToDTORequest<Account, AccountDTO>.ToDTO(review.Account!, dto.Account);

            res.Add(dto);
        }

        return res;
    }
}

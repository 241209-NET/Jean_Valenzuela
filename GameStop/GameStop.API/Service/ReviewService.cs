using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository) => _reviewRepository = reviewRepository;
    
    public Review CreateReview(ReviewDTO _review, int GameId, int AccountId)
    {
        Review review = new(){
            AccountId = AccountId,
            GameId = GameId,
            Account = null,
            Game = null
        };

        DTOToEntityRequest<ReviewDTO, Review>.ToEntity(_review, review);

        return _reviewRepository.CreateNewReview(review);
    }

    public Review? DeleteReviewById(int id)
    {
        var review = GetReviewById(id);

        if ( review is not null ) _reviewRepository.DeleteReviewById(id);

        return review;
    }

    public Review? GetReviewById(int id)
    {
        if ( id < 1 ) return null;

        return _reviewRepository.GetReviewById(id);
    }

    public IEnumerable<Review> GetReviews(int id)
    {
        return _reviewRepository.GetReviews(id);
    }

    public Review? UpdateReview(int id, ReviewDTO _review)
    {
        var review = GetReviewById(id);

        DTOToEntityRequest<ReviewDTO, Review>.ToEntity(_review, review!);

        if ( review is not null) _reviewRepository.UpdateReview(id, review);

        return review;
    }
}

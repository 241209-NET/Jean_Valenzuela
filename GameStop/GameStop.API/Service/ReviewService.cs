using GameStop.API.Model;
using GameStop.API.Repository;

namespace GameStop.API.Service;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository) => _reviewRepository = reviewRepository;
    
    public Review CreateNewReview(Order order)
    {
        throw new NotImplementedException();
    }

    public Review DeleteReviewById(int id)
    {
        throw new NotImplementedException();
    }

    public Review GetReviewById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Review> GetReviews()
    {
        throw new NotImplementedException();
    }

    public Review UpdateReview(int id, Order order)
    {
        throw new NotImplementedException();
    }
}

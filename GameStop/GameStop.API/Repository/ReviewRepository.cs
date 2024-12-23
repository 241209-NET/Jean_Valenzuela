using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly GameStopContext _gameStopContext;
    public ReviewRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
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

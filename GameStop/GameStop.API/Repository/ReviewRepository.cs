using GameStop.API.Data;
using GameStop.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GameStop.API.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly GameStopContext _gameStopContext;
    public ReviewRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
    public Review CreateNewReview(Review review)
    {
        _gameStopContext.Review.Add(review);
        _gameStopContext.SaveChanges();
        return review;
    }

    public IEnumerable<Review> GetReviews(int id)
    {
        return _gameStopContext.Review.Where(review => review.Game!.GameId == id)
            .Include(a => a.Account)
            .ToList();
    }
}

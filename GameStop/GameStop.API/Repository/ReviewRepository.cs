using GameStop.API.Data;
using GameStop.API.Model;

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

    public void DeleteReviewById(int id)
    {
        var review = GetReviewById(id);

        _gameStopContext.Review.Remove(review!);
        _gameStopContext.SaveChanges();
    }

    public Review? GetReviewById(int id)
    {
        return _gameStopContext.Review.Find(id);
    }

    public IEnumerable<Review> GetReviews(int id)
    {
        return _gameStopContext.Review.Where(review => review.Game.GameId == id).ToList();
    }

    public void UpdateReview(int id, Review _review)
    {
        var review = GetReviewById(id)!;

        review.Description = _review.Description;
        review.Date = _review.Date;
        review.Rating = _review.Rating;

        _gameStopContext.SaveChanges();
    }
}

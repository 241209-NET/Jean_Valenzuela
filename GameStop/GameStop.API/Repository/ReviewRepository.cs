using GameStop.API.Data;
using GameStop.API.Model;

namespace GameStop.API.Repository;

public class ReviewRepository : IReviewRepository
{
    private readonly GameStopContext _gameStopContext;
    public ReviewRepository(GameStopContext gameStopContext) => _gameStopContext = gameStopContext;
    
    public Review CreateNewReview(Review review)
    {
        _gameStopContext.Reviews.Add(review);
        _gameStopContext.SaveChanges();
        return review;
    }

    public void DeleteReviewById(int id)
    {
        var review = GetReviewById(id);

        _gameStopContext.Reviews.Remove(review!);
        _gameStopContext.SaveChanges();
    }

    public Review? GetReviewById(int id)
    {
        return _gameStopContext.Reviews.Find(id);
    }

    public IEnumerable<Review> GetReviews()
    {
        return _gameStopContext.Reviews.ToList();
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

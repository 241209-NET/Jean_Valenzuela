using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Service;
using Moq;
using Newtonsoft.Json;

namespace GameStop.TEST.Service;

public class ReviewServiceTest
{
    [Fact]
    public void GetReviewsTest()
    {
        Mock<IReviewRepository> mockRepository = new();
        ReviewService reviewService = new ReviewService(mockRepository.Object);

        List<Review> reviews = [
            new Review{
                ReviewId = 1,
                Description = "string",
                Account = new Account{
                    AccountId = 1,
                    FirstName = "string",
                },
                Game = new Game{
                    GameId = 1,
                    Version = 1234523
                }
            }
        ];

        List<ResponseReviewDTO> dto = [
            new ResponseReviewDTO{
                ReviewId = 1,
                Description = "string",
                Account = new AccountDTO{
                    FirstName = "string"
                }
            }
        ];

        mockRepository.Setup(x => x.GetReviews(1)).Returns(reviews);

        var result = reviewService.GetReviews(1);

        Assert.Equal(JsonConvert.SerializeObject(dto), JsonConvert.SerializeObject(result));
    }

    [Fact]
    public void CreateReviewTest(){
        Mock<IReviewRepository> mockRepository = new();
        ReviewService reviewService = new ReviewService(mockRepository.Object);

        ReviewDTO review = new (){ Description = "String"};

        Review input = new() { Description = "String", Account = new(), Game = new()};

        mockRepository.Setup(x => x.CreateNewReview(It.IsAny<Review>())).Returns(input);

        var result = reviewService.CreateReview(review, 1, 1);

        Assert.Equal(JsonConvert.SerializeObject(review), JsonConvert.SerializeObject(result));
    }
}
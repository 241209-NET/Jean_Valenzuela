using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Service;
using Moq;
using Newtonsoft.Json;

namespace GameStop.TEST.Service;

public class AccountServiceTest
{
    [Fact]
    public void GetAllAccountsTest()
    {
        Mock<IAccountRepository> mockAccountRepository = new();
        AccountService accountService = new(mockAccountRepository.Object);

        List<Account> accounts = [
            new Account{AccountId= 1,
            FirstName= "Jean",
            LastName= "Sanchez",
            Email= "test@email.com",
            Password= "password",
            Age= 0,
            ZipCode= 0,
            Street= "This Street",
            City= "This city",
            State= "This State",
            Orders= [new Order
            {
                OrderId= 1,
                Status= "Complete",
                Total= 149.99,
                PaymentMethod= "Card",
                ShippingZipCode= "48197",
                ShippingStreetAddress= "This Address",
                ShippingCity= "This City",
                ShippingState= "This State",
                AccountId= 1,
                Games= null,
                Account= null
            }
            ],
            Reviews= [ new Review
            {
                ReviewId= 2,
                Description= "Really Good Game!!!!",
                Date= DateOnly.MaxValue,
                Rating= 4,
                AccountId= 1,
                GameId= 3,
                Account= null,
                Game= null
            }
            ]},
            ];

            List<ResponseAccountDTO> dto = [
            new ResponseAccountDTO{
            FirstName= "Jean",
            LastName= "Sanchez",
            Email= "test@email.com",
            Password= "password",
            Age= 0,
            ZipCode= 0,
            Street= "This Street",
            City= "This city",
            State= "This State",
            Orders= [new AccountOrders
            {
                Status= "Complete",
                Total= 149.99,
                PaymentMethod= "Card",
                ShippingZipCode= "48197",
                ShippingStreetAddress= "This Address",
                ShippingCity= "This City",
                ShippingState= "This State",
            }
            ],
            Reviews= [ new ReviewDTO
            {
                Description= "Really Good Game!!!!",
                Date= DateOnly.MaxValue,
                Rating= 4,
            }
            ]},
            ];

        mockAccountRepository.Setup(x => x.GetAccounts()).Returns(accounts);

        var result = accountService.GetAccounts();

        Assert.Equal(JsonConvert.SerializeObject(dto), JsonConvert.SerializeObject(result));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void GetAccountByIdTest(int accountId)
    {
        Mock<IAccountRepository> mockAccountRepository = new();
        AccountService accountService = new(mockAccountRepository.Object);

        Account account = new()
        {
            AccountId = 1,
            Age = 23,
            ZipCode = 13432
        };

        mockAccountRepository.Setup(x => x.GetAccountById(accountId)).Returns(account);

        var result = accountService.GetAccountById(accountId);

        if (accountId == 0)
        {
            Assert.Null(result);
        }
        else
        {
            Assert.Equal(JsonConvert.SerializeObject(account), JsonConvert.SerializeObject(result));
        }
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    public void DeleteAccountByIdTest(int AccountId)
    {
        Mock<IAccountRepository> mockAccountRepository = new();
        AccountService accountService = new(mockAccountRepository.Object);

        List<Account> accounts = [
            new Account{AccountId = 0, Age = 23, ZipCode = 13432},
            new Account{AccountId = 1, Age = 24, ZipCode = 34566},
            new Account{AccountId = 2, Age = 25, ZipCode = 56788},
            new Account{AccountId = 3, Age = 26, ZipCode = 34565},
            new Account{AccountId = 4, Age = 27, ZipCode = 84563}
        ];

        mockAccountRepository.Setup(x => x.GetAccountById(AccountId)).Returns(accounts.First(a => a.AccountId == AccountId));

        accountService.DeleteAccountById(AccountId);

        mockAccountRepository.Verify(x => x.DeleteAccountById(AccountId), Times.Once());
    }

    [Fact]
    public void CreateAccountTest()
    {
        Mock<IAccountRepository> mockAccountRepository = new();
        AccountService accountService = new(mockAccountRepository.Object);

        AccountDTO account = new() { Age = 23, ZipCode = 13432 };

        accountService.CreateNewAccount(account);

        mockAccountRepository.Verify(x => x.CreateNewAccount(It.IsAny<Account>()), Times.Once());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void UpdateAccountTest(int accountId)
    {
        Mock<IAccountRepository> mockAccountRepository = new();
        AccountService accountService = new(mockAccountRepository.Object);

        List<Account> accounts = [
            new Account{AccountId = 0, Age = 23, ZipCode = 13432},
            new Account{AccountId = 1, Age = 24, ZipCode = 34566},
            new Account{AccountId = 2, Age = 25, ZipCode = 56788},
            new Account{AccountId = 3, Age = 26, ZipCode = 34565},
            new Account{AccountId = 4, Age = 27, ZipCode = 84563}
        ];

        AccountDTO account = new() { Age = 23, ZipCode = 13432 };

        mockAccountRepository.Setup(x => x.GetAccountById(accountId)).Returns(accounts.First(x => x.AccountId == accountId));

        accountService.UpdateAccount(accountId, account);

        mockAccountRepository.Verify(x => x.UpdateAccount(accountId, It.IsAny<Account>()), Times.Once());
    }
}
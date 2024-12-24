using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Utils;
using Newtonsoft.Json;

namespace GameStop.TEST.DTO;

public class DTOTest
{
    [Fact]
    public void ToDTOTest()
    {
        Account account = new Account(){
            FirstName = "Jean",
            LastName = "Valenzuela",
            AccountId = 0,
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        AccountDTO expected = new(){
            FirstName = "Jean",
            LastName = "Valenzuela",
            AccountId = 0,
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        AccountDTO actual = new AccountDTO();

        EntityToDTO<Account, AccountDTO>.ToDTO(account, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));


    }
}
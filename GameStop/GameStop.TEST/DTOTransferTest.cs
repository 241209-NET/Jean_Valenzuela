using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Utils;
using Newtonsoft.Json;

namespace GameStop.TEST.DTO;

public class DTOTransferTest
{
    [Fact]
    public void ToDTONullExceptionTest()
    {
        Account? account = null;

        AccountDTO? actual = null;

        Assert.Throws<ArgumentException>(() => EntityToDTORequest<Account, AccountDTO>.ToDTO(account!, actual!));
    }

    [Fact]
    public void ToEntityNullExceptionTest()
    {

        AccountDTO? dto = null;
        Account? actual = null;

        Assert.Throws<ArgumentException>(() => DTOToEntityRequest<AccountDTO, Account>.ToEntity(dto!, actual!));

    }

    [Fact]
    public void AccountToDTOTest()
    {
        Account account = new Account()
        {
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

        AccountDTO expected = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        AccountDTO actual = new();

        EntityToDTORequest<Account, AccountDTO>.ToDTO(account, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
    }

    [Fact]
    public void AccountDTOToEntityTest()
    {

        AccountDTO dto = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        Account expected = new()
        {
            FirstName = "Jean",
            LastName = "Valenzuela",
            Email = "test@email.com",
            Password = "password",
            Age = 23,
            ZipCode = 48197,
            Street = "This Street",
            City = "This city",
            State = "This state"
        };

        Account actual = new();

        DTOToEntityRequest<AccountDTO, Account>.ToEntity(dto, actual);

        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

    }

}
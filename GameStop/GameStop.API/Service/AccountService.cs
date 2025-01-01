using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Repository;
using GameStop.API.Utils;

namespace GameStop.API.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository) => _accountRepository = accountRepository;

    public AccountDTO CreateNewAccount(AccountDTO _account)
    {
        Account account = new();
        DTOToEntityRequest<AccountDTO, Account>.ToEntity(_account, account);

        var account_res = _accountRepository.CreateNewAccount(account);

        AccountDTO res = new();

        EntityToDTORequest<Account, AccountDTO>.ToDTO(account_res, res);

        return res;
    }

    public ResponseAccountDTO? DeleteAccountById(int id)
    {
        var account = GetAccountById(id);

        if (account is not null) _accountRepository.DeleteAccountById(id);

        return account;
    }

    public ResponseAccountDTO? GetAccountById(int id)
    {
        if (id < 1) return null;

        var account = _accountRepository.GetAccountById(id);

        ResponseAccountDTO res = new()
        {
            Orders = [],
            Reviews = []
        };

        EntityToDTORequest<Account, ResponseAccountDTO>.ToDTO(account!, res);

        foreach (Order order in account!.Orders!)
        {
            AccountOrders accountOrders = new();
            EntityToDTORequest<Order, AccountOrders>.ToDTO(order, accountOrders);
            res.Orders!.Add(accountOrders);
        }

        foreach (Review review in account.Reviews!)
        {
            ReviewDTO orderReview = new();
            EntityToDTORequest<Review, ReviewDTO>.ToDTO(review, orderReview);
            res.Reviews!.Add(orderReview);
        }

        return res;
    }

    public IEnumerable<ResponseAccountDTO> GetAccounts()
    {
        var accounts = _accountRepository.GetAccounts();

        List<ResponseAccountDTO> res = [];

        foreach (Account a in accounts)
        {
            ResponseAccountDTO dto = new()
            {
                Orders = [],
                Reviews = []
            };

            EntityToDTORequest<Account, ResponseAccountDTO>.ToDTO(a, dto);

            foreach (Order order in a.Orders!)
            {
                AccountOrders accountOrders = new();
                EntityToDTORequest<Order, AccountOrders>.ToDTO(order, accountOrders);
                dto.Orders!.Add(accountOrders);
            }

            foreach (Review review in a.Reviews!)
            {
                ReviewDTO orderReview = new();
                EntityToDTORequest<Review, ReviewDTO>.ToDTO(review, orderReview);
                dto.Reviews!.Add(orderReview);
            }

            res.Add(dto);
        }

        return res;
    }

    public AccountDTO? UpdateAccount(int id, AccountDTO _account)
    {
        var account = _accountRepository.GetAccountById(id);

        DTOToEntityRequest<AccountDTO, Account>.ToEntity(_account, account!);

        if (account is not null) _accountRepository.UpdateAccount(id, account);

        AccountDTO res = new();

        EntityToDTORequest<Account, AccountDTO>.ToDTO(account!, res);

        return res;
    }
}
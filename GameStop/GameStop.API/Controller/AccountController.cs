using GameStop.API.DTO;
using GameStop.API.Model;
using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) => _accountService = accountService;

    [HttpGet]
    public IActionResult GetAccounts()
    {
        var accounts = _accountService.GetAccounts();

        return Ok(accounts);
    }

    [HttpPost]
    public IActionResult CreateAccount(AccountDTO account)
    {
        var newAccount = _accountService.CreateNewAccount(account);

        return Ok(newAccount);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAccount(int id, AccountDTO _account)
    {
        var account = _accountService.UpdateAccount(id, _account);

        return Ok(account);
    }

    [HttpGet("{id}")]
    public IActionResult GetAccountById(int id)
    {
        var account = _accountService.GetAccountById(id);

        if (account is null) return NotFound();

        return Ok(account);
    }

    [HttpDelete]
    public IActionResult DeleteAccountById(int id)
    {
        var account = _accountService.GetAccountById(id);

        if (account is null) return NotFound();

        return Ok(account);
    }
}
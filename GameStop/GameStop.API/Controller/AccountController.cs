using GameStop.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStop.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) => _accountService = accountService;


}
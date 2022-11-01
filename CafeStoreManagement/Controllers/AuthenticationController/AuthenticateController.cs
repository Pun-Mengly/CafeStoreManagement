

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    //private readonly UserManager<IdentityUserRole<Guid>> _userRoleManager;

    #region Contractor

    public AuthenticateController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration/* UserManager<IdentityUserRole<Guid>> userRoleManager*/)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        //_userRoleManager = userRoleManager;
    }
    #endregion

    #region Login
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }
    #endregion

    #region Register Admin
    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        }
        if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }
        return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
    }

    #endregion

    #region Register No Role
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
    }
    #endregion

    #region Register User
    [HttpPost]
    [Route("register-user")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User already exists!" });

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new ResponseModel { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));


        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }
        return Ok(new ResponseModel { Status = "Success", Message = "User created successfully!" });
    }
    #endregion

    #region Create Role
    [Route("create-role")]
    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
    {
        IdentityRole role = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = model.Name,
            NormalizedName = model.Name.ToUpper(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
        };
        await _roleManager.CreateAsync(role);
        return Ok(new ResponseModel { Status = "Success", Message = "Role created successfully!" });
    }
    #endregion

    #region Create UserRole
    [Route("create-user-role")]
    [HttpPost]
    public async Task<IActionResult> CreateUserRole([FromBody] UserRoleModel model)
    {

        IdentityUser hasUser = _userManager.Users.Where(e => e.Id == model.UserId.ToString()).FirstOrDefault()!;
        var roles = new List<IdentityRole>();
        foreach (var item in model.RoleIds!)
        {
            var hasUserRoleName = _roleManager.Roles.Where(e => e.Id == item.RoleId.ToString()).FirstOrDefault();
            if (hasUserRoleName != null) roles.Add(hasUserRoleName!);

        }
        foreach (var roleId in roles)
        {
            await _userManager.AddToRoleAsync(hasUser, roleId.Name);

        }
        return Ok(new ResponseModel { Status = "Success", Message = "User's role created successfully!" });
    }
    #endregion

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(50),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        return token;
    }
}



using Microsoft.EntityFrameworkCore;
using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;

namespace CSVParserVentionTask.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UsersDbContext _dbContext;

    public UsersController(UsersDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("upload")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UploadUsers(IFormFile file)
    {
        //Parse CSV file
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            if (file == null)
            {
                return BadRequest();
            }
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var users = csv.GetRecords<User>();
                foreach (var user in users)
                {
                    var userExist =
                        await _dbContext.Users.FirstOrDefaultAsync(u => u.useridentifier == user.useridentifier);
                    if (userExist != null)
                    {
                        userExist.username = user.username;
                        userExist.age = user.age;
                        userExist.city = user.city;
                        userExist.phonenumber = user.phonenumber;
                        userExist.email = user.email;
                    }
                    else
                    {
                        await _dbContext.Users.AddAsync(user);
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
        }

        return Ok();
    }

    [HttpGet("getUsers")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers(string sortDirection, string sortBy = "username",
        int? limit = 1)
    {
        //Get Users From Mysql database

        var query = _dbContext.Users.AsQueryable();

        if (!string.IsNullOrEmpty(sortDirection))
        {
            if (sortDirection.Equals("asc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(u => u.username);
            }

            if (sortDirection.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(u => u.username);
            }
            else
            {
                return BadRequest("Недопустимый параметр сортировки.");
            }
        }

        if (limit.HasValue)
        {
            query = query.Take(limit.Value);
        }

        var users = query.ToList();

        return Ok(users);
    }
}
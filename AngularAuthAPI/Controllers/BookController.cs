﻿using AngularAuthAPI.Context;
using AngularAuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AngularAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase // Hereda de ControllerBase
    {
        private readonly AppDbContext _authContext;

        public BookController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetAllBooks() 
        {
            var books = await _authContext.Books.ToListAsync();
            return Ok(books); 
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> RegisterUser([FromBody] Books bookObj)
        {
            if (bookObj == null)
                return BadRequest();

            //CHECK USERNAME
            if (await ChekBookExistAsync(bookObj.Title))
                return BadRequest(new { Message = "Book already Exist" });

            //CHECK EMAIL
           
            await _authContext.Books.AddAsync(bookObj);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Book Registered!"
            });
            
        }
        private Task<bool> ChekBookExistAsync(string Title)
            => _authContext.Books.AnyAsync(x => x.Title == Title);
    }
}

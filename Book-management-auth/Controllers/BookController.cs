using Book_management_auth.Authentication;
using Book_management_auth.Models;
using Book_management_auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_management_auth.Controllers
{
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookBL _bookBL;
        public BookController(BookBL bookBL)
        {
            _bookBL = bookBL;

        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            try
            {
                return Ok(await _bookBL.GetBooks());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reterving data");
            }
        }
        
        [HttpPost("Add")]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            try
            {
                return Ok(await _bookBL.AddBook(book));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in adding data");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                return await _bookBL.GetBook(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reterving data");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            try
            {
                if (id != book.Id)
                {
                    return BadRequest("Id Mismatch");
                }
                var bookUpdate = await _bookBL.GetBook(id);
                if (bookUpdate == null)
                {
                    return NotFound("{book not found id={Id}");
                }
                return await _bookBL.UpdateBook(id, book);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in reterving data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                var bookDelete = await _bookBL.GetBook(id);
                if (bookDelete == null)
                {
                    return BadRequest($"not found id {id}");
                }
                return await _bookBL.DeleteBook(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in deleting data");
            }
        }

    }
}

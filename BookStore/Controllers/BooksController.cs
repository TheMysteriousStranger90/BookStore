using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    //[Route("api/[Controller]")]
    //[ApiController]
    [Produces("application/json")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookRepository repository, ILogger<BooksController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Index()
        {
            try
            {
                var books = _repository.GetAllBooks();
                return View(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get books: {ex}");
                return BadRequest("Failed to get books");
            }
        }
        
        
        
        
        
        
        public async Task<IActionResult> Edit(int id)
        {
            Book book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            
            EditBookViewModel model = new EditBookViewModel
                { Id = book.Id, Title = book.Title, Year = book.Year, Isbn = book.Isbn, Publisher = book.Publisher, Language = book.Language, Genre = book.Genre, Price = book.Price};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                Book book = await _repository.GetByIdAsync(model.Id);
                if (book != null)
                {
                    book.Title = model.Title;
                    book.Year = model.Year;
                    book.Isbn = model.Isbn;
                    book.Publisher = model.Publisher;
                    book.Language = model.Language;
                    book.Genre = model.Genre;
                    book.Price = model.Price;

                    _repository.Update(book);
      
                    if (_repository.SaveAll())
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return BadRequest($"Failed!!!");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book != null)
            {
                _repository.Remove(book);
            }
            return RedirectToAction("Index");
        }
    }
}
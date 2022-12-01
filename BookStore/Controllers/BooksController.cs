using System;
using System.Collections.Generic;
using BookStore.Interfaces;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
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
    }
}
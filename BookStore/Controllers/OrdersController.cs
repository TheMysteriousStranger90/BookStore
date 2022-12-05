using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Interfaces;
using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public OrdersController(IBookRepository bookRepository, IOrderRepository orderRepository,
            ILogger<OrdersController> logger,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _orderRepository.GetOrderById(User.Identity.Name, id);
                if (order != null) return Ok(_mapper.Map<OrderViewModel>(order));
                else return NotFound(); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to return orders: {ex}");
                return BadRequest($"Failed to return orders");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> AddItem(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                OrderItem _orderItem = new OrderItem()
                {
                    Book = book,
                    BookId = book.Id,
                    Quantity = 1,
                    UnitPrice = book.Price
                };
                
                var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                Order _order = new Order()
                {
                    Items = new List<OrderItem>() { _orderItem }, OrderDate = DateTime.Now,
                    OrderNumber = new Random().Next(1000, 9999).ToString(), User = currentUser, UserId = currentUser.Id
                };
                _orderRepository.CreateAsync(_order);
                _orderRepository.SaveAll();
            }
            return RedirectToAction("Index", "Orders");
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
﻿using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _orderService.GetAll();

            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id) 
        {
            var result = _orderService.GetById(id);

            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getorderdetails")]
        public IActionResult GetOrderDetails()
        {
            var result = _orderService.GetAllOrderDetails();

            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);

            if (result.IsSuccess) 
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Order order) 
        {
            var result = _orderService.Update(order);

            if (result.IsSuccess) 
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Order order) 
        {
            var result = _orderService.Delete(order);

            if (result.IsSuccess) 
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

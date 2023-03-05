﻿using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Dto;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IUnitOfWork unitOfWork, ILogger<BlogController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted {0}", DateTime.Now);
            var blogGetAll = await _unitOfWork.blogRepository.GetAll().Include(x => x.Posts).ToListAsync();
            _logger.LogWarning("Request Successfuly completed at {0}", DateTime.Now);
            return Ok(blogGetAll);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogDto blogDto)
        {
            Bloog blog = new()
            {
                Name = blogDto.Name,
                Description = blogDto.Description,
                PostsCount = blogDto.PostCount
            };
            await _unitOfWork.blogRepository.Add(blog);
            await _unitOfWork.Commit();
            return Ok(blog);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] BlogDto blogDto)
        {
            try
            {
                _logger.LogInformation($"{id} obtained from base date");
                var blogUpdate = await _unitOfWork.blogRepository.GetFirst(b => b.Id == id);
                blogUpdate.Name = blogDto.Name;
                blogUpdate.Description = blogDto.Description;
                await _unitOfWork.blogRepository.Update(blogUpdate);
                await _unitOfWork.Commit();
                return Ok(blogUpdate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when looking up id in database id not found {id}");
                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"{id} obtained from base date");

                var blogUpdate = await _unitOfWork.blogRepository.GetFirst(b => b.Id == id);
                await _unitOfWork.blogRepository.Delete(blogUpdate);
                await _unitOfWork.Commit();
                return Ok(_unitOfWork);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when looking up id in database id not found {id}");
                throw;
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetId(int id)
        {
            var blogGetId = await _unitOfWork.blogRepository.Find(id);
            return Ok(blogGetId);
        }
    }
}

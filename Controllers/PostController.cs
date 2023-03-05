using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Data.Entity;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Dto;
using Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.HomeTask.EF.Repository.UnitofWork_04._03._2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PostController> _logger;
        public PostController(IUnitOfWork unitOfWork, ILogger<PostController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted {0}", DateTime.Now);
            var postGetAll = await _unitOfWork.postRepository.GetAll().ToListAsync();
            _logger.LogWarning("Request Successfuly completed at {0}", DateTime.Now);
            return Ok(postGetAll);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto postDto)
        {
            Post post = new()
            {
                Title = postDto.Title,
                Content = postDto.Content,
                Desc = postDto.Description,
                Subtitle = postDto.Subtitle,
                BlogId = postDto.BlogId
            };

            await _unitOfWork.postRepository.Add(post);
            await _unitOfWork.Commit();
            return Ok(post);
        }
        [HttpPut]

        public async Task<IActionResult> Update(int id, PostDto post)
        {
            try
            {
                _logger.LogInformation($"This post is in the data base {id}");
                var postUpdate = await _unitOfWork.postRepository.GetFirst(b => b.Id == id);
                postUpdate.Subtitle = post.Subtitle;
                postUpdate.Title = post.Title;
                postUpdate.Content = post.Content;
                postUpdate.Desc = post.Description;
                postUpdate.BlogId = post.BlogId;
                await _unitOfWork.postRepository.Update(postUpdate);
                await _unitOfWork.Commit();
                return Ok(postUpdate);
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
                var postDelete = await _unitOfWork.postRepository.GetFirst(b => b.Id == id);
                await _unitOfWork.postRepository.Delete(postDelete);
                await _unitOfWork.Commit();
                return Ok(postDelete);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error when looking up id in database id not found {id}");
                throw;
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetId(int id)
        {
            var postGetId = await _unitOfWork.postRepository.Find(id);
            return Ok(postGetId);
        }
    }
}

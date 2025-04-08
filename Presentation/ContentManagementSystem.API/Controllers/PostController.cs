using System.Net;
using ContentManagementSystem.Application.Abstraction;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Application.ViewModels.Post;
using ContentManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostReadRepository _postReadRepository;
        private readonly IPostWriteRepository _postWriteRepository;

        public PostController(IPostReadRepository postReadRepository, IPostWriteRepository postWriteRepository)
        {
            _postReadRepository = postReadRepository;
            _postWriteRepository = postWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = _postReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Title,
                p.Content,
                p.AuthorId,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Post model)
        {
            if (ModelState.IsValid)
            {
                await _postWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,
                    Content = model.Content,
                    AuthorId = model.AuthorId,
                    Slug = model.Slug,
                    CurrentStatus = (Post.Status)Enum.Parse(typeof(Post.Status), model.CurrentStatus),
                    ViewCount = model.ViewCount,
                    PostPicturePath = model.PostPicturePath,
                    Tags = model.Tags.Select(t => new Tag { Name = t }).ToList(),
                    Categories = model.Categories.Select(c => new Category { Name = c }).ToList()
                });
                await _postWriteRepository.SaveAsync();
                return Created("", model);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Post model)
        {
            Domain.Entities.Post post = await _postReadRepository.GetByIdAsync(model.Id);
            if (post == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(model.Title))
            {
                post.Title = model.Title;
            }
            if (!string.IsNullOrEmpty(model.Content))
            {
                post.Content = model.Content;
            }
            if (!string.IsNullOrEmpty(model.CurrentStatus))
            {
                post.CurrentStatus = (Post.Status)Enum.Parse(typeof(Post.Status), model.CurrentStatus);
            }
            if (!string.IsNullOrEmpty(model.ViewCount))
            {
                post.ViewCount = int.Parse(model.ViewCount);
            }
            if (!string.IsNullOrEmpty(model.PostPicturePath))
            {
                post.PostPicturePath = model.PostPicturePath;
            }
            await _postWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.OK);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _postWriteRepository.RemoveAsync(id);
            await _postWriteRepository.SaveAsync();
            return Ok();
        }
    }
}

using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Application.ViewModels.Tag;
using ContentManagementSystem.Domain.Entities;
using ContentManagementSystem.Persistance.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagReadRepository _tagReadRepository;
        private readonly ITagWriteRepository _tagWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public TagController(ITagReadRepository tagReadRepository, ITagWriteRepository tagWriteRepository, IPostReadRepository postReadRepository)
        {
            _tagReadRepository = tagReadRepository;
            _tagWriteRepository = tagWriteRepository;
            _postReadRepository = postReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = _tagReadRepository.GetAll(false).Select(t => new
            {
                t.Id,
                t.Name,
                t.Slug,
                t.Posts
            }).ToList();
            return Ok(tags);
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Tag model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posts = await _postReadRepository
                .GetWhere(p => model.PostIds.Contains(p.Id))
                .ToListAsync();

            await _tagWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Slug = model.Slug,
                Posts = posts
            });
            await _tagWriteRepository.SaveAsync();
            return Created("", model);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Tag model)
        {
            var tag = await _tagReadRepository.GetByIdAsync(model.Id);
            if (tag == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                tag.Name = model.Name;
            }
            if (!string.IsNullOrEmpty(model.Slug))
            {
                tag.Slug = model.Slug;
            }
            if (model.PostIds != null)
            {
                var postGuids = model.PostIds.Select(id => Guid.Parse(id)).ToList();
                var posts = await _postReadRepository.GetWhere(p => postGuids.Contains(p.Id)).ToListAsync();
                if (posts.Count != model.PostIds.Count)
                {
                    return BadRequest("Bazı Post Id'leri geçersiz.");
                }
                tag.Posts = posts;
            }
            await _tagWriteRepository.SaveAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tag = await _tagReadRepository.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            _tagWriteRepository.Remove(tag);
            await _tagWriteRepository.SaveAsync();
            return NoContent();
        }
    }
}

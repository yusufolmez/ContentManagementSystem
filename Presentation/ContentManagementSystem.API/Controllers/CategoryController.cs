using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Application.Repositories.Category;
using ContentManagementSystem.Application.ViewModels.Category;
using ContentManagementSystem.Persistance.Repositories.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IPostReadRepository _postReadRepository;

        public CategoryController(ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IPostReadRepository postReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _postReadRepository = postReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = _categoryReadRepository.GetAll(false).Select(c => new
            {
                c.Id,
                c.Name,
                c.Description,
                c.Slug,
                c.ParentCategory,
                c.Posts
            }).ToList();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Category model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var posts = await _postReadRepository
                .GetWhere(p => model.PostIds.Contains(p.Id))
                .ToListAsync();
            await _categoryWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Slug = model.Slug,
                ParentCategoryId = model.ParentCategoryId,
                Posts = posts
            });
            await _categoryWriteRepository.SaveAsync();
            return Created("", model);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Category model)
        {
            var category = await _categoryReadRepository.GetByIdAsync(model.Id);
            if (category == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(model.Name))
            {
                category.Name = model.Name;
            }
            if (!string.IsNullOrEmpty(model.Description))
            {
                category.Description = model.Description;
            }
            if (!string.IsNullOrEmpty(model.Slug))
            {
                category.Slug = model.Slug;
            }
            if (model.ParentCategoryId != null)
            {
                category.ParentCategoryId = model.ParentCategoryId;
            }
            if (model.PostIds != null)
            {
                var postGuids = model.PostIds.Select(id => Guid.Parse(id)).ToList();
                var posts = await _postReadRepository.GetWhere(p => postGuids.Contains(p.Id)).ToListAsync();
                if (posts.Count != model.PostIds.Count)
                {
                    return BadRequest("Bazı Post Id'leri geçersiz.");
                }
                category.Posts = posts;
            }
            await _categoryWriteRepository.SaveAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryReadRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var isParentOfAnother = await _categoryReadRepository
                .GetWhere(c => c.ParentCategory.Id == category.Id)
                .AnyAsync();

            if (isParentOfAnother)
            {
                return BadRequest("Bu kategori, başka bir kategorinin üst kategorisi olduğu için silinemez.");
            }

            _categoryWriteRepository.Remove(category);
            await _categoryWriteRepository.SaveAsync();
            return NoContent();
        }
    }
}
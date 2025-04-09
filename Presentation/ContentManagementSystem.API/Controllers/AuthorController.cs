using System.Net;
using ContentManagementSystem.Application.Repositories;
using ContentManagementSystem.Application.ViewModels.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        private readonly IAuthorWriteRepository _authorWriteRepository;

        public AuthorController(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get() {
            var authors = _authorReadRepository.GetAll(false).Select(a => new
            {
                a.Id,
                a.Name,
                a.Bio,
                a.Posts
            }).ToList();
            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Author model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _authorWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Bio = model.Bio,
                Email = model.Email,
                Name = model.Name,
                PasswordHash = model.Password,
                ProfilePicPath = model.ProfilePicPath,
                CurrentRole = (Domain.Entities.Author.Role)Enum.Parse(typeof(Domain.Entities.Author.Role), model.CurrentRole),
                Posts = model.Posts
            });
            await _authorWriteRepository.SaveAsync();
            return Created("", model);
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Author model)
        {
            Domain.Entities.Author author = await _authorReadRepository.GetByIdAsync(model.Id);
            
            if (author == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                author.Name = model.Name;
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                author.Email = model.Email;
            }
            if (!string.IsNullOrEmpty(model.Bio))
            {
                author.Bio = model.Bio;
            }
            if (!string.IsNullOrEmpty(model.ProfilePicPath))
            {
                author.ProfilePicPath = model.ProfilePicPath;
            }

            await _authorWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.OK);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _authorWriteRepository.RemoveAsync(id);
            await _authorWriteRepository.SaveAsync();
            return Ok();
        }

    }
}

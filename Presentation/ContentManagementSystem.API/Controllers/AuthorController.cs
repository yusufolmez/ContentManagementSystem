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
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Author model)
        {
            if (ModelState.IsValid)
            {

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

    }
}

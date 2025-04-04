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
    }
}

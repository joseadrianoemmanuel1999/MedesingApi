using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedesingApi.Service.PostService;
using MedesingApi.Shared;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MedesingApi.Model;

namespace MedesingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPost _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PostController(IPost service,IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor=httpContextAccessor;
        }
         [HttpPost("AddPost"),Authorize(Roles ="user")]
        public async Task<ActionResult> AddPost (PostDto  request)
         
        {
            var id = _service.Readclaim();
           await _service.AddPost(request,id);
           return Ok("sucess"); 
           
        }
          [HttpPut("Edit"),Authorize(Roles ="user")]
        public async Task<ActionResult> EditPost (EditpostDto  request)
         
        {
           await _service.EditPost(request);
           return Ok("sucess"); 
           
        }


        [HttpGet]
        
        public async Task<ActionResult<List<Post>>> GetAllListPost()
        {

             
            return await _service.ListPost();
           
        }
    }
}
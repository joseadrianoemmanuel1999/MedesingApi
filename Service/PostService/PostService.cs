using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MedesingApi.Db;
using MedesingApi.Model;
using MedesingApi.Shared;
using Microsoft.EntityFrameworkCore;
using MedesingApi.Service.UserService;

namespace MedesingApi.Service.PostService
{
    public class PostService : IPost
    {
        private readonly Appcontext _appContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUser _userservice;
        public PostService(Appcontext appContext, IMapper mapper, IHttpContextAccessor httpContextAccessor,IUser userservice)
        {
            _appContext = appContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userservice= userservice;

        }
        public async Task AddPost(PostDto request, string email)
        {
            var userId = _appContext.Users.FirstOrDefault(c => c.email == email);


            var addpost = new Post
            {
                Title = request.Title,
                Text = request.Text,
                CreatedTimestamp = request.CreatedTimestamp,
                UserId = userId.id
            };
            _appContext.Posts.Add(addpost);
            await _appContext.SaveChangesAsync();

        }
        private void GetIdPost()
        {
            var email = Readclaim();
            var userId = _appContext.Users.FirstOrDefault(c => c.email == email);


        }

        public async Task EditPost(EditpostDto request)
        {
            var email = Readclaim();
            var userId = _appContext.Users.FirstOrDefault(c => c.email == email);
               var Postentity = _appContext.Posts.FirstOrDefault(c =>c.id==request.id && c.UserId==userId.id);
                if(Postentity is null)
                throw new Exception($"Post id not found");
               
                 _mapper.Map(request,Postentity);
           //     _appContext.Posts.Update(Editpost);
            await _appContext.SaveChangesAsync();

        }

        public string Readclaim()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        public async Task<List<Post>> ListPost()
        {
            var postlist = _appContext.Posts.ToList();
            return postlist;

        }

        public async Task DeletePost(Guid request)
        {
            var email = Readclaim();
            var userid = _appContext.Users.FirstOrDefault(c => c.email == email);
            var Postid = _appContext.Posts.FirstOrDefault(c => c.UserId == userid.id && c.id==request);
            if(Postid is null)
            {
                throw new Exception("This post is not exist");
            }
            
                _appContext.Posts.Where(c=>c.id==request).ExecuteDelete();
            await _appContext.SaveChangesAsync();
            

        }

    }
}
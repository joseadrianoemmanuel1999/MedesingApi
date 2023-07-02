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

namespace MedesingApi.Service.PostService
{
    public class PostService : IPost
    {
        private readonly Appcontext _appContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PostService(Appcontext appContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _appContext = appContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

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
            var Postid = _appContext.Posts.FirstOrDefault(c => c.UserId == userId.id);

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

        public async Task<List<Post>> DeletePost(Guid request)
        {
            var email = Readclaim();
            var userid = _appContext.Users.FirstOrDefault(c => c.email == email);
            var Postid = _appContext.Posts.FirstOrDefault(c => c.UserId == userid.id);
            var post= _appContext.Posts.Where(c => c.id == request && c.UserId == userid.id).ExecuteDelete();
            await _appContext.SaveChangesAsync();
            return _appContext.Posts.ToList();

        }
        private void Verification (string request,Guid id)
        {
            
            
        }

    }
}
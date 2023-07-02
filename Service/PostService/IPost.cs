using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedesingApi.Model;
using MedesingApi.Shared;

namespace MedesingApi.Service.PostService
{
    public interface IPost
    {
        Task AddPost(PostDto request,string email);
       string Readclaim();
       Task EditPost(EditpostDto request);
       Task<List<Post>>ListPost();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFGetPostsCommand : BaseEFCommand, IGetPostsCommand
    {
        public EFGetPostsCommand(PostContext context) : base(context)
        {
        }

        public IEnumerable<PostDto> Execute(PostSearch request)
        {
            var query = Context.Posts.AsQueryable();
            if (request.Name != null) {
                var keword = request.Name.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(keword));
            }
            if (request.CategoryId != null)
            {
                query = query.Where(p => p.CategoryPostId == request.CategoryId);
            }

            if (request.searchString != null) {
                var search = request.searchString.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(search));
            }
            return query.Include(p => p.CategoryPost).Include(p=>p.Pictures).Include(p=>p.User).Select(p=> new PostDto {

                Id=p.Id,
                Name=p.Name,
                Text=p.Text,
                PictureDtos=p.Pictures.Select(od=> new PictureDto {
                    Id=od.Id,
                    Name=od.Name
                }).ToList(),
                CategoryName=p.CategoryPost.NameCat,
                UserId=p.User.Username

            }


                ).ToList();
        }
    }
}

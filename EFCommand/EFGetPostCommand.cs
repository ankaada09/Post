using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Responses;
using Aplication.Search;
using DataAcess;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFGetPostCommand : BaseEFCommand, IGetPost
    {
        public EFGetPostCommand(PostContext context) : base(context)
        {
        }

        public PagedResponses<PostDto> Execute(PostSearch request)
        { var query = Context.Posts.AsQueryable();

            if (request.Name != null) {
                var name = request.Name.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(name));
            }
            if (request.CategoryId != null) {
                query = query.Where(p => p.CategoryPostId == request.CategoryId);
            }
            var totalCount = query.Count();

            query = query
                .Include(p => p.CategoryPost).Include(p=>p.Pictures).Include(p=>p.User)
                .Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponses<PostDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new PostDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    PictureDtos = p.Pictures.Select(od => new PictureDto
                    { Id=od.Id,
                       
                        Name = od.Name
                    }).ToList(),
                    Text = p.Text,
                    CategoryName = p.CategoryPost.NameCat,
                    UserId=p.User.Username
                    
                }).ToList()
            };

            return response;

            //return query.Include(p => p.CategoryPost).Select(p => new PostDto
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Pictute = p.Picture,
            //    Text = p.Text,
            //    CategoryName = p.CategoryPost.NameCat
            //});

        }
    }
}

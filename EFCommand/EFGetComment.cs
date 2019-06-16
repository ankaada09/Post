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
    public class EFGetComment : BaseEFCommand, IGetComment
    {
        public EFGetComment(PostContext context) : base(context)
        {
        }

        public PagedResponses<CommentDto> Execute(CommentSearch request)
        {
            var query = Context.Comments.AsQueryable();
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponses<CommentDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new CommentDto
                {
                    Id = p.Id,
                   Comment=p.Comments


                })




            };
            return response;
        }
    }
}

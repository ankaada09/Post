using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Responses;
using Aplication.Search;
using DataAcess;

namespace EFCommand
{
    public class EFGetCtegoryApi : BaseEFCommand, IGetCateroryApi
    {
        public EFGetCtegoryApi(PostContext context) : base(context)
        {
        }

        public PagedResponses<CategoryPostDto> Execute(CategorySearch request)
        {
            var query = Context.Posts.AsQueryable();
            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage).Take(request.PerPage);

            var pagesCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedResponses<CategoryPostDto>
            {
                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PagesCount = pagesCount,
                Data = query.Select(p => new CategoryPostDto
                {
                    Id = p.Id,
                    Name = p.Name


                })




            };
            return response;
        }
    }
}
      

        
    


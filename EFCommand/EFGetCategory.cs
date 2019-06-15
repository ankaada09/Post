using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommand
{
    public class EFGetCategory : BaseEFCommand, IGetCategory
    {
        public EFGetCategory(PostContext context) : base(context)
        {
        }

        public IEnumerable<CategoryPostDto> Execute(CategorySearch request)
        {

            var query = Context.CategoryPosts.AsQueryable();

            if (request.Keyword != null) {
                query = query.Where(c => c.NameCat.ToLower().Contains(request.Keyword.ToLower()));

            }
            return query.Select(c => new CategoryPostDto
            {     Id=c.Id,
                  Name=c.NameCat

            });

        }
    }
}

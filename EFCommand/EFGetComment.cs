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
    public class EFGetComment : BaseEFCommand, IGetComment
    {
        public EFGetComment(PostContext context) : base(context)
        {
        }

        public IEnumerable<CommentDto> Execute(CommentSearch request)
        {
            var query = Context.Comments.AsQueryable();

            if (request.Comment != null) {
                query = query.Where(c => c.Comments.ToLower().Contains(request.Comment.ToLower()));
            }

            return query.Select(c => new CommentDto
            {
               Id=c.Id,
               Comment=c.Comments,
            });
        }
    }
}

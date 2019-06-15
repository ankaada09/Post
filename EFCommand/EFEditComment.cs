using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFEditComment : BaseEFCommand,IEditComment
    {
        public EFEditComment(PostContext context) : base(context)
        {
        }

        public void Execute(CommentDto request)
        {
            var comment = Context.Comments.Find(request.Id);
            if (comment == null) {
                throw new EntityNoFound();
            }

            if (comment.Comments != request.Comment) {

                comment.Comments = request.Comment;
            }

            Context.SaveChanges();
        }
    }
}

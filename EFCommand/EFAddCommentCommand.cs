using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFAddCommentCommand : BaseEFCommand, IAddCommentCommand
    {
        public EFAddCommentCommand(PostContext context) : base(context)
        {
        }

        public void Execute(CommentInsertDto request)
        {
            Context.Comments.Add(new Domen.Comment
            {
                Comments=request.Comment,
                PostId=request.PostId,
                UserId=request.UserId


            });

            Context.SaveChanges();
        }
    }
}

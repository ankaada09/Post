using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Interface;
using DataAcess;

namespace EFCommand
{
    public class EFGetOneComment : BaseEFCommand, IGetOneComment
    {
        public EFGetOneComment(PostContext context) : base(context)
        {
        }

        public CommentDto Execute(int request)
        {
            var co = Context.Comments.Find(request);
            if (co == null)
            {
                throw new EntityNoFound();
            }

            return new CommentDto
            {
                Id=co.Id,
                Comment=co.Comments

            };
        }
    }
}

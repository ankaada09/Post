using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFEditPostCommand : BaseEFCommand, IEditPostCommand
    {
        public EFEditPostCommand(PostContext context) : base(context)
        {
        }

        public void Execute(UpdatePostDto request)
        {

            var type = Context.Posts.Find(request.Id);
            if (type == null)
            {
                throw new EntityNoFound();
            }

            var id = type.Id;

            var slike = new Domen.Picture
            {  Id=request.Id,
                Name = request.Pictures,
                PostId=id
                

            };

          
                type.Pictures.Add(slike);

            type.Id = request.Id;
            type.Name = request.Name;
            type.Text = request.Text;

            Context.SaveChanges();
           
        }
    }
}

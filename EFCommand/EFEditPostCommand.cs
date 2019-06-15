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



            var slike = request.Pictures.Select(s => new Domen.Picture
            {
                Name = s
            });

           foreach(var s in slike)
            {
                type.Pictures.Add(s);
            }

            type.Name = request.Name;
            type.Text = request.Text;

            Context.SaveChanges();
           
        }
    }
}

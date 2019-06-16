using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;
using Domen;

namespace EFCommand
{
    public class EFAddPost : BaseEFCommand, IGetAddPost
    {
        public EFAddPost(PostContext context) : base(context)
        {
        }



        public void Execute(InsertPostDto request)
        {
            if (Context.Posts.Any(m => m.Name == request.Name))
            {
                throw new EntityAlreadyExists();
            }
            //if (!Context.Posts.Any(p=>p.UserId == request.UserId)) {

            //    throw new EntityNoFound();
            //}
            if (!Context.Posts.Any(p => p.CategoryPostId == request.CategoryId)) {
                throw new EntityNoFound();
            }


            var post = new Domen.Post {

                Name=request.Name,
                Text= request.Text,
                CategoryPostId=request.CategoryId,
                UserId=request.UserId
                
            };

            //var pic = new Domen.Picture();
            //pic.Name = request.FileName;
                

            Context.Add(post);
            Context.SaveChanges();



            // int LastPostId = post.Id;

            Domen.Picture pic = new Domen.Picture
            {
                Name = request.FileName,
                PostId = post.Id
            };
            Context.Add(pic);
            Context.SaveChanges();
        }
    }
}

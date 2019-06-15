using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;
using Domen;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFGetOnePost : BaseEFCommand, IGetOnePostCommand
    {
        public EFGetOnePost(PostContext context) : base(context)
        {
        }

        public OnePostDto Execute(int request)
        {
            var post = Context.Posts.Find(request);
            if (post == null) {
                throw new EntityNoFound();
            }

            List<Comment> comm = Context.Comments.ToList();
            List<Picture> pic = Context.Pictures.ToList();
           
            return new  OnePostDto
            {
                Id=post.Id,
                Name=post.Name,
               CommentDtos=post.Comments.Select(od=> new CommentDto {
                   Id=od.Id,
                   Comment=od.Comments
               }).ToList(),
               PictureDtos=post.Pictures.Select(pk=> new PictureDto {
                   Id=pk.Id,
                   Name=pk.Name
               }).ToList(),
                Text=post.Text,
              // CategoryName=post.CategoryPost.NameCat
                

            };
        }
    }
}


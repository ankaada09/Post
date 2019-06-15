using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeletePost : BaseEFCommand,IDeletePost
    {
        public EFDeletePost(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Posts.Find(request);
            if (category == null)
            {
                throw new EntityNoFound();
            }

            if (category.IsDeleted)
            {

                category.IsDeleted = true;


                throw new EntityDeleted();
            }




            Context.Posts.Remove(category);

            Context.SaveChanges();
        }
    }
}

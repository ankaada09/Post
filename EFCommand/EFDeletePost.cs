using System;
using System.Collections.Generic;
using System.Linq;
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



            var db = Context.Pictures.Where(p => p.PostId == category.Id);

            Context.Pictures.RemoveRange(db);


            Context.Posts.Remove(category);
            Context.SaveChanges();
        }
    }
}

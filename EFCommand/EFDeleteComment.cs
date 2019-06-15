using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeleteComment : BaseEFCommand, IDeleteComment
    {
        public EFDeleteComment(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var menu = Context.Comments.Find(request);
            if (menu == null)
            {
                throw new EntityNoFound();
            }


            if (menu.IsDeleted)
            {

                menu.IsDeleted = true;


                throw new EntityDeleted();
            }

            Context.Comments.Remove(menu);

            Context.SaveChanges();
        }
    }
}

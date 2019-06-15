using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeletePicture : BaseEFCommand,IDeletePicture
    {
        public EFDeletePicture(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.Pictures.Find(request);
            if (category == null)
            {
                throw new EntityNoFound();
            }

            if (category.IsDeleted)
            {

                category.IsDeleted = true;


                throw new EntityDeleted();
            }




            Context.Pictures.Remove(category);

            Context.SaveChanges();
        }
    }
}

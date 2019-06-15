using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
  public  class EFDeleteCategoryCommand : BaseEFCommand, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var category = Context.CategoryPosts.Find(request);
            if (category == null) {
                throw new EntityNoFound();
            }

            if (category.IsDeleted)
            {

                category.IsDeleted = true;


                throw new EntityDeleted();
            }
            

            

            Context.CategoryPosts.Remove(category);

            Context.SaveChanges();


        }
    }
}

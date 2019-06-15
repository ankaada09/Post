using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFEditCategory : BaseEFCommand,IEditCategoryCommand
    {
        public EFEditCategory(PostContext context) : base(context)
        {
        }

        public void Execute(CategoryPostDto request)
        {
            var category = Context.CategoryPosts.Find(request.Id);
            if (category == null) {
                throw new EntityNoFound();
            }
            

            if (category.NameCat != request.Name)
            {
                if (Context.CategoryPosts.Any(c => c.NameCat == request.Name))
                {
                    throw new EntityAlreadyExists();
                }

                category.NameCat = request.Name;

                Context.SaveChanges();
            }
        }
    }
}

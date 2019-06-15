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
    public class EFAddCategoryCommand : BaseEFCommand, IAddCategoryCommand
    {
        public EFAddCategoryCommand(PostContext context) : base(context)
        {
        }

        public void Execute(CategoryPostDto request)
        {
            if (Context.CategoryPosts.Any(c=>c.NameCat == request.Name))
            {
                throw new EntityAlreadyExists();
            }

            Context.CategoryPosts.Add(new Domen.CategoryPost { 
                NameCat=request.Name

            });
            Context.SaveChanges();
        }
    }
}

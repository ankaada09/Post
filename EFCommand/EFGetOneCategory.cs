using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Interface;
using DataAcess;

namespace EFCommand
{
    public class EFGetOneCategory : BaseEFCommand, IGetOneCategory
    {
        public EFGetOneCategory(PostContext context) : base(context)
        {
        }


        public CategoryPostDto Execute(int request)
        {
            var category = Context.CategoryPosts.Find(request);
            if (category == null)
            {
                throw new EntityNoFound();
            }

            return new CategoryPostDto
            {
                Id = category.Id,
                Name = category.NameCat


            };
        }
    }
}

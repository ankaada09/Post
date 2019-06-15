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
    public class EFAddMenu : BaseEFCommand,IAddMenuCommand
    {
        public EFAddMenu(PostContext context) : base(context)
        {
        }

        public void Execute(MenuDto request)
        {
            if (Context.Menus.Any(m => m.MenuName == request.MenuName)) {
                throw new EntityAlreadyExists();
            }
            Context.Menus.Add(new Domen.Menu
            {
                MenuName=request.MenuName,
                Link=request.Link

            });
            Context.SaveChanges();
        }
    }
}

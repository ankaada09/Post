using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeleteMenu : BaseEFCommand, IDeleteMenu
    {
        public EFDeleteMenu(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var menu = Context.Menus.Find(request);
            if (menu == null)
            {
                throw new EntityNoFound();
            }


            if (menu.IsDeleted)
            {

                menu.IsDeleted = true;


                throw new EntityDeleted();
            }

            Context.Menus.Remove(menu);

            Context.SaveChanges();
        }
    }
}

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
    public class EFGetOneMenu : BaseEFCommand, IGetOneMenuCommand
    {
        public EFGetOneMenu(PostContext context) : base(context)
        {
        }

        public MenuDto Execute(int request)
        {
            var user = Context.Menus.Find(request);
            if (user == null)
            {
                throw new EntityNoFound();
            }

            return new MenuDto
            {
                Id = user.Id,
                MenuName = user.MenuName,
                Link = user.Link


            };
        }
    }
}
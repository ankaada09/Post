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
    public class EFEditMenu : BaseEFCommand, IEditMenuCommand
    {
        public EFEditMenu(PostContext context) : base(context)
        {
        }

        public void Execute(MenuDto request)
        {
            var menu = Context.Menus.Find(request.Id);
            if (menu == null) {
                throw new EntityNoFound();
            }

            if (menu.MenuName != request.MenuName)
            {
                if (Context.Menus.Any(c => c.MenuName == request.MenuName))
                {
                    throw new EntityAlreadyExists();
                }
                menu.MenuName = request.MenuName;

            }

                if (menu.Link != request.Link) {
                    if (Context.Menus.Any(c => c.Link == request.Link)) {
                        throw new EntityAlreadyExists();
                    }
                menu.Link = request.Link;
            }
           
        
            Context.SaveChanges();
            }
        }
    }


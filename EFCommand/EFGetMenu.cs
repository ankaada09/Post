using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.ICommand;
using Aplication.Search;
using DataAcess;

namespace EFCommand
{
    public class EFGetMenu : BaseEFCommand, IGetMenuCommand
    {
        public EFGetMenu(PostContext context) : base(context)
        {
        }

        public IEnumerable<MenuDto> Execute(MenuSearch request)
        {
            var query = Context.Menus.AsQueryable();

            if (request.MenuName != null)
            {
                query = query.Where(c => c.MenuName.ToLower().Contains(request.MenuName.ToLower()));
            }
                return query.Select(m => new MenuDto
                {
                    Id=m.Id,
                    MenuName=m.MenuName,
                    Link=m.MenuName

                });
            }
        }
    }


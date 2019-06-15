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
    public class EFGEtType : BaseEFCommand, IGEtTypeCommand
    {
        public EFGEtType(PostContext context) : base(context)
        {
        }

        public IEnumerable<TypeDto> Execute(TypeSearch request)
        {
            var query = Context.UserTypes.AsQueryable();
            if (request.Name != null) {

                query = query.Where(t => t.Type.ToLower().Contains(request.Name.ToLower()));

            }

            return query.Select(t => new TypeDto
            { Id=t.Id,
               Name=t.Type


            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFGetOneType : BaseEFCommand,IGetOneType
    {
        public EFGetOneType(PostContext context) : base(context)
        {
        }

        public TypeDto Execute(int request)
        {
            var type = Context.UserTypes.Find(request);
            if (type == null) {
                throw new EntityNoFound();
            }

            return new TypeDto
            {
                Id=type.Id,
                Name=type.Type

            };
        }
    }
}

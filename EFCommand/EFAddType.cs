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
    public class EFAddType : BaseEFCommand, IAddType
    {
        public EFAddType(PostContext context) : base(context)
        {
        }

        public void Execute(TypeDto request)
        {
            if (Context.UserTypes.Any(m => m.Type == request.Name))
            {
                throw new EntityAlreadyExists();
            }
            Context.UserTypes.Add(new Domen.UserType
            {
               Type=request.Name

            });
            Context.SaveChanges();
        }
    }
}

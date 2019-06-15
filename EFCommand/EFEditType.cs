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
    public class EFEditType : BaseEFCommand, IEditType
    {
        public EFEditType(PostContext context) : base(context)
        {
        }

        public void Execute(TypeDto request)
        {
            var type = Context.UserTypes.Find(request.Id);
            if (type == null)
            {
                throw new EntityNoFound();
            }


            if (type.Type != request.Name)
            {
                if (Context.UserTypes.Any(c => c.Type == request.Name))
                {
                    throw new EntityAlreadyExists();
                }

                type.Type = request.Name;

                Context.SaveChanges();
            }
        }
    }
}

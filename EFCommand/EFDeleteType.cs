using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeleteType : BaseEFCommand, IDeleteType
    {
        public EFDeleteType(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var type= Context.UserTypes.Find(request);
            if (type == null)
            {
                throw new EntityNoFound();
            }


            if (type.IsDeleted)
            {

                type.IsDeleted = true;


                throw new EntityDeleted();
            }

            Context.UserTypes.Remove(type);

            Context.SaveChanges();
        }
    }
}

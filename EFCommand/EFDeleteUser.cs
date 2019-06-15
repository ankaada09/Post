using System;
using System.Collections.Generic;
using System.Text;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFDeleteUser : BaseEFCommand, IdeleteUser
    {
        public EFDeleteUser(PostContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNoFound();
            }


            if (user.IsDeleted)
            {

                user.IsDeleted = true;


                throw new EntityDeleted();
            }

            Context.Users.Remove(user);

            Context.SaveChanges();
        }
    }
}

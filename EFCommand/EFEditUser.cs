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
    public class EFEditUser : BaseEFCommand, IEditUser
    {
        public EFEditUser(PostContext context) : base(context)
        {
        }

        public void Execute(UpdateUserDto request)
        {
            var user = Context.Users.Find(request.Id);
            if (user.Username != request.UserName)
            {
                if (Context.Users.Any(c => c.Username == request.UserName))
                {
                    throw new EntityAlreadyExists();
                }
                user.Username = request.UserName;

            }
            if (user.Email != request.Email)
            {
                if (Context.Users.Any(c => c.Email == request.Email))
                {
                    throw new EntityAlreadyExists();
                }
                user.Email = request.Email;

            }

            if (user.Password != request.Password)
            {
                if (Context.Users.Any(c => c.Password == request.Password))
                {
                    throw new EntityAlreadyExists();
                }
                user.Password = request.Password;

            }

            Context.SaveChanges();
        }
    }
}

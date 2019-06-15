using System;
using System.Collections.Generic;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using DataAcess;

namespace EFCommand
{
    public class EFGetOneUser : BaseEFCommand,IGetOneUser
    {
        public EFGetOneUser(PostContext context) : base(context)
        {
        }

        public UserDto Execute(int request)
        {
            var user = Context.Users.Find(request);
            if (user == null)
            {
                throw new EntityNoFound();
            }

            
            return new UserDto
            {
                Id=user.Id,
                UserName=user.Username,
                Password=user.Password,
                Email=user.Email
               

            };
        }
    }
}

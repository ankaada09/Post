using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aplication.DTO;
using Aplication.Exeption;
using Aplication.ICommand;
using Aplication.Interface;
using DataAcess;
using Microsoft.EntityFrameworkCore;

namespace EFCommand
{
    public class EFAuthCommand : BaseEFCommand,IAuthCommand
    {
        public EFAuthCommand(PostContext context) : base(context)
        {
        }

       

        AuthDto ICommand<AuthDto, AuthDto>.Execute(AuthDto request)
        {
            var user = Context.Users.Include(u => u.UserType)
                                    .Where(u => u.Username == request.Username)
                                    .Where(u => u.Password == request.Password)
                                    .FirstOrDefault();


            if (user == null)
            {
                throw new EntityNoFound();
            }

            return new AuthDto
            {
                Role = user.UserType.Type,
                Password = user.Password,
                Username = user.Username

            };
        }
    }
}

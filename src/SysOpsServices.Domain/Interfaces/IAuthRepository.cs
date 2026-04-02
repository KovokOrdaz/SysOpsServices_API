using SysOpsServices.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysOpsServices.Domain.Interfaces;

public interface IAuthRepository
{
    Task<User?> Login(string Username, string Password);
}

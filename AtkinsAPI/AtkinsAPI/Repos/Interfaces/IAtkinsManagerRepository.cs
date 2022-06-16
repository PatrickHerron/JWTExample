using AtkinsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtkinsAPI.Repository
{
    public interface IAtkinsManagerRepository
    {
        Tokens Authenticate(Users users);
    }

}
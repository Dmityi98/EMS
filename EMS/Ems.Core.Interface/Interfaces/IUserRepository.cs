﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ems.Core.Interface.Interfaces
{
    public interface IUserRepository
    {
        public void ViewEmployeeNotes(string name, string password);

        public void ChangeStatusProgress(int id);
    }
}

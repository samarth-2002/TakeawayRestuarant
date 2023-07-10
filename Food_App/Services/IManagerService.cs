using Food_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_App.Services
{
    public interface IManagerService
    {
        Task<List<ManagerInfo>> GetManagerList();
    }
}

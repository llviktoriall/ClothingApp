using ClothingApp.Data.Common.Entities;
using ClothingApp.Data.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingApp.Data.Common.Repositories
{
    public class AdminRepository : BaseRepository<Style>, IAdminRepository
    {
        public AdminRepository(DataContext context) : base(context)
        {
           
        }

    }
}

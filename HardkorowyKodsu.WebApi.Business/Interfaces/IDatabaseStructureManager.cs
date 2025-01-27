using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardkorowyKodsu.WebApi.CommonModel.Structures;

namespace HardkorowyKodsu.WebApi.Business.Interfaces
{
    public interface IDatabaseStructureManager
    {
        Task<DatabaseStructure> GetDatabaseStructureAsync();
        Task<TableStructure> GetTableStructureAsync(string tableName);
    }
}

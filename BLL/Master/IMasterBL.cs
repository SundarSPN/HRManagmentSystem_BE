using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IMasterBL
    {
        HRMResponse<Master> GetMasterData(int listId);
    }
}

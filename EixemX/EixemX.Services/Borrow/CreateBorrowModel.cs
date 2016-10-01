using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EixemX.Services.Account;
using EixemX.Services.Base;

namespace EixemX.Services.Borrow
{
    public class CreateBorrowModel : BaseModel
    {
        public CreateBorrowModel(string amount, UserDetailModel user)
        {
            Amount = Convert.ToInt32(amount);
            User = user;
        }

        public int Amount { get; set; }
        public UserDetailModel User { get; set; }
    }
}

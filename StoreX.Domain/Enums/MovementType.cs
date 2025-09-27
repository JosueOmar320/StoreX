using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Enums
{
    public enum MovementType : byte
    {
        Purchase = 1,
        Sale = 2,
        Adjustment = 3,
        Transfer = 4
    }
}

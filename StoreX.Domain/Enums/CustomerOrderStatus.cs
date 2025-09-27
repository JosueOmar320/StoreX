using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Enums
{
    public enum CustomerOrderStatus
    {
        Pending,      // Recibida, pero aún no procesada
        Confirmed,    // Confirmada para preparar
        Processing,   // En preparación
        Shipped,      // Enviada al cliente
        Delivered,    // Entregada al cliente
        Cancelled
    }
}

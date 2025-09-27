using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreX.Domain.Enums
{
    public enum PurchaseOrderStatus
    {
        Draft,        // Borrador, aún no enviada
        Submitted,    // Enviada al proveedor
        Approved,     // Aprobada internamente
        InProgress,   // En proceso de entrega
        Received,     // Productos recibidos
        Closed,       // Cerrada (facturada / completada)
        Cancelled     // Cancelada
    }
}

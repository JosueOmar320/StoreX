using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreX.Domain.Entities
{
    public class RolePermission
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        [JsonIgnore]
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }

        [JsonIgnore]
        [ForeignKey("PermissionId")]
        public Permission? Permission { get; set; }
    }
}

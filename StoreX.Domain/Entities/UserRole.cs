using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreX.Domain.Entities
{
    public class UserRole
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        [JsonIgnore]
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [JsonIgnore]
        [ForeignKey("RoleId")]
        public Role? Role { get; set; }
    }
}

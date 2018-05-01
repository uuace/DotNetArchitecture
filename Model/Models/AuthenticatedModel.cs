using Solution.Model.Enums;
using System.Collections.Generic;

namespace Solution.Model.Models
{
    public class AuthenticatedModel
    {
        public IEnumerable<Roles> Roles { get; set; } = new List<Roles>();

        public long UserId { get; set; }
    }
}
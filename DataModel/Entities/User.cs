using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model.Entities
{
    public partial class User
    {
        public User()
        {
            Tokens = new HashSet<Token>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PasswordHash { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
namespace Model.Entities
{
    public partial class Token
    {
        public int TokenId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string AuthToken { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual User User { get; set; }
    }
}

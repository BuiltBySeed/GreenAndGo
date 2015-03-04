using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GreenAndGo.Models.Data
{
    public class User : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                base.Id = value;
            }
        }

        public Contact Contact { get; set; }
    }

    public partial class GuidRole : IdentityRole<Guid, UserRole>
    {
        public GuidRole()
        {
            Id = Guid.NewGuid();
            this.AccountRoles = new HashSet<UserRole>();
        }
        public GuidRole(string name) : this() { Name = name; }

        protected virtual ICollection<UserRole> AccountRoles { get; set; }
    }
    public partial class UserRole : IdentityUserRole<Guid> {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
        public virtual GuidRole GuidRole { get; set; }
    }
    public partial class UserClaim : IdentityUserClaim<Guid> {
    
    }
    public partial class UserLogin : IdentityUserLogin<Guid> {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }

    public class UserStore : UserStore<User, GuidRole, Guid, UserLogin, UserRole, UserClaim>
    {
        public UserStore(DbContext context)
            : base(context)
        {
        }
    }
    public class GuidRoleStore : RoleStore<GuidRole, Guid, UserRole>
    {
        public GuidRoleStore(DbContext context)
            : base(context)
        {
        }
    }

}
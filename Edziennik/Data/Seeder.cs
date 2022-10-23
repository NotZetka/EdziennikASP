using Edziennik.Utility;
using Microsoft.AspNetCore.Identity;

namespace Edziennik.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<IdentityRole> roleManager;

        public Seeder(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = dbContext;
            this.roleManager = roleManager;
        }
        public void seedRoles()
        {
            if(!roleManager.RoleExistsAsync(SD.Role_Admin).Result){
                roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
            }
            if(!roleManager.RoleExistsAsync(SD.Role_Teacher).Result){
                roleManager.CreateAsync(new IdentityRole(SD.Role_Teacher)).GetAwaiter().GetResult();
            }
            if(!roleManager.RoleExistsAsync(SD.Role_Student).Result){
                roleManager.CreateAsync(new IdentityRole(SD.Role_Student)).GetAwaiter().GetResult();
            }
        }
    }
}

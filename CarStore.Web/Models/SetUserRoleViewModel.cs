namespace CarStore.Web.Models
{
    public class SetUserRoleViewModel
    {
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Users { get; set; } = new List<string>();
    }
}
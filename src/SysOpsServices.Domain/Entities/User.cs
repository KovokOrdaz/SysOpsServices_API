namespace SysOpsServices.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Role { get; set; }
    public int Employee_id { get; set; }
    public int Department_id { get; set; }
}

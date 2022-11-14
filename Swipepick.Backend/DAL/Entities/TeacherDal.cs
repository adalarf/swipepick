using DAL.AppDBContext;

namespace DAL.Entities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomTableNameAttribute : Attribute
    {
        public string Name { get; }

        public CustomTableNameAttribute(string name)
        {
            Name = name;
        }
    };

    [CustomTableName("Teachers")]
    public class TeacherDal : BaseSqlModelDal<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int studentid { get; set; }
    }
}

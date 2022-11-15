using DAL.AppDBContext.SQL;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [CustomTableName("public.Students")]
    public class StudentDal : BaseSqlModelDal<int>
    {
        public string Name { get; set; }

        public string Lastname { get; set; }
    }
}

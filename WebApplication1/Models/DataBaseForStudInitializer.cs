using System.Web;
using System.Data.Entity;

namespace StudentCard.Models
{
    public class DataBaseForStudInitializer : DropCreateDatabaseAlways<DataBaseForStudContext>
    {
        protected override void Seed(DataBaseForStudContext context)
        {
            base.Seed(context);
        }
    }
}
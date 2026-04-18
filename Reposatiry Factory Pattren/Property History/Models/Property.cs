using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_History
{
    public class Property:BaseEntity
    {
        public string PropertyName { get; set; }
        public string Location { get; set; }
        public string TypeOfLand { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}

// model1_lab5.cs

using Lab4_23.Models.Base;
using System.Collections.Generic;

namespace Lab4_23.Models.One_to_Many
{
    public class Model1_lab5 : BaseEntity
    {
        public string? Name { get; set; }

        // Relație One to Many: Un Model1 poate avea mai multe Model2
        public ICollection<Model2_lab5>? Models2 { get; set; }
    }
}

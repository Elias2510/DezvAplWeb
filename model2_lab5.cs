// model2_lab5.cs

using Lab4_23.Models.Base;

namespace Lab4_23.Models.One_to_Many
{
    public class Model2_lab5 : BaseEntity
    {
        public string Name { get; set; }

        // Relație Many-to-One: Un Model2 aparține unui singur Model1
        public Model1_lab5 Model1 { get; set; }

        public Guid Model1Id { get; set; }
    }
}

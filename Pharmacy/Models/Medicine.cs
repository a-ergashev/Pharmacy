using System.Text.Json.Serialization;

namespace Pharmacy.Models
{
    public class Medicine
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        public void Show()
        {
            Console.WriteLine("+-----+--------------------+---------------+\n" +
                $"|{this.ID,-5}|{this.Name,-20}|{this.Price,-15}|" +
                "\n+-----+--------------------+---------------+");
        }
    }
}

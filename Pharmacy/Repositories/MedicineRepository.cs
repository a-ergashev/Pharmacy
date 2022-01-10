 using Pharmacy.Models;
using System.Text.Json;
using Pharmacy.IRepositories;

namespace Pharmacy.Database
{
    public class MedicineRepository : IMedicineRepository
    {
        List<Medicine> medicines = new List<Medicine>();
        public void AddMedicine(Medicine medicine)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);
            medicine.ID = medicines[medicines.Count - 1].ID + 1;
            medicines.Add(medicine);

            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);
        }
        public void DeleteMedicine(int id)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);

            Medicine? res = medicines.Find(pill => pill.ID == id);
            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);
        }
        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            updatedMedicine.ID = id;
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);
            
            int index = medicines.FindIndex(p => p.ID == id);
            medicines[index] = updatedMedicine;
            
            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);
        }
        public Medicine? Find(string keyword)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);

            return medicines.Find(medicine => medicine.ID.ToString() == keyword 
            || medicine.Name.ToLower() == keyword || medicine.Price.ToString() == keyword);
        }
        public List<Medicine> GetAllMedicines()
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            return JsonSerializer.Deserialize<List<Medicine>>(jsonString);
        }
    }
}

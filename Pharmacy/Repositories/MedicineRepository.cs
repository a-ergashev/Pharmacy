 using Pharmacy.Models;
using System.Text.Json;
using Pharmacy.IRepositories;

namespace Pharmacy.Database
{
    public class MedicineRepository : IMedicineRepository
    {
        public void AddMedicine(Medicine med)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            List<Medicine> medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);
            med.ID = medicines[medicines.Count - 1].ID + 1;
            medicines.Add(med);

            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);
            Console.WriteLine("Element got added!");
            //File.AppendAllText(Constants.Constants.MedicineDBPath, med.Show() + '\n');
        }
        public void DeleteMedicine(int id)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            List<Medicine> medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);

            Medicine? res = medicines.Find(pill => pill.ID == id);
            if(res != null)
            {
                medicines.Remove(res);
                Console.WriteLine("Element deleted!");
            }
            else
                Console.WriteLine("No such element!");
            
            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);
            #region for txt-based DB
            //string[] lines = File.ReadAllLines(Constants.Constants.MedicineDBPath);

            //File.WriteAllText(Constants.Constants.MedicineDBPath, string.Empty);
            //for (int i = 0; i < lines.Length - 1; ++i)
            //    if (lines[i] != med.Show())
            //        File.AppendAllText(Constants.Constants.MedicineDBPath, lines[i] + '\n');
            #endregion
        }
        public void UpdateMedicine(int id, Medicine updatedMedicine)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            List<Medicine> medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);
            
            int index = medicines.FindIndex(p => p.ID == id);
            if (index != -1)
            {
                updatedMedicine.ID = id;
                medicines[index] = updatedMedicine;
                Console.WriteLine("Element got updated!");
            }
            else
                Console.WriteLine("\nThere is no element with given ID!");
            jsonString = JsonSerializer.Serialize(medicines);
            File.WriteAllText(Constants.Constants.MedicineDBPath, jsonString);

            #region txt-based database
            //string[] lines = File.ReadAllLines(Constants.Constants.MedicineDBPath);

            //File.WriteAllText(Constants.Constants.MedicineDBPath, string.Empty);
            //for (int i = 0; i < lines.Length; ++i)
            //    if (lines[i] != oldMed.Show())
            //        File.AppendAllText(Constants.Constants.MedicineDBPath, lines[i] + '\n');
            //    else
            //        File.AppendAllText(Constants.Constants.MedicineDBPath, newMed.Show() + '\n');
            #endregion
        }
        public void ShowAll()
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            List<Medicine> medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);


            Console.WriteLine("+-----+--------------------+---------------+\n" +
                $"|{"ID", -5}|{"Name", -20}|{"Price", -15}|\n" + 
                "+-----+--------------------+---------------+");
            foreach (Medicine medicine in medicines)
                Console.WriteLine($"|{medicine.ID, -5}|{medicine.Name, -20}|{medicine.Price, -15}|"
                    + "\n+-----+--------------------+---------------+");

        }
        public Medicine? Find(string keyword)
        {
            string jsonString = File.ReadAllText(Constants.Constants.MedicineDBPath);
            List<Medicine> medicines = JsonSerializer.Deserialize<List<Medicine>>(jsonString);

            return medicines.Find(medicine => medicine.ID.ToString() == keyword 
            || medicine.Name.ToLower() == keyword || medicine.Price.ToString() == keyword);

            #region txt-based database
            //string[] lines = File.ReadAllLines(Constants.Constants.MedicineDBPath);
            //foreach (string line in lines)
            //{
            //    string[] lineData = line.Split();
            //    if (lineData[0] == keyword || lineData[1] == keyword || lineData[2] == keyword)
            //        return new Medicine() { ID = int.Parse(lineData[0]), Name = lineData[1], Price = decimal.Parse(lineData[2]) };
            //}
            //return null;
            #endregion
        }
    }
}

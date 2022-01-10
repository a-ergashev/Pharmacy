using Pharmacy.Models;

namespace Pharmacy.IRepositories
{
    internal interface IMedicineRepository
    {
        public void AddMedicine(Medicine medicine);
        public void DeleteMedicine(int id);
        public void UpdateMedicine(int id, Medicine updatedMedicine);
        public List<Medicine> GetAllMedicines();
        public Medicine? Find(string keyword);
    }
}

using Microsoft.EntityFrameworkCore;
using pharmacy.DAL.Entities;
using pharmacy.DAL.Repository;
using pharmacy.DAL.Rrposatory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy.BLL.Services
{
    public class MedicineServices
    {
        private readonly MedicineDL _medicineBL = new MedicineDL();

        public List<MedicineEntityDto> GetMedicines()
        {
            var medicines = _medicineBL.GetMedicines();
            var medicinesDto = medicines.Select(m => new MedicineEntityDto
            {
                Id = m.Id,
                Name = m.Name,
                Price = m.Price,
                Quantity = m.Quantity,
                Type = m.Type,
                OrderMedicines = m.OrderMedicines
            }).ToList();

            return medicinesDto;
        }

        public MedicineEntity GetMedicineById(int Id)
        {
            var medicine = _medicineBL.GetMedicineById(Id);
            var medicineDto = new MedicineEntity
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Price = medicine.Price,
                Quantity = medicine.Quantity,
                Type = medicine.Type,
                OrderMedicines = medicine.OrderMedicines
            };

            return medicineDto;
        }

        public void UpdateMedicine(MedicineEntity medicine)
        {
            _medicineBL.UpdateMedicine(medicine);
        }

        public void DeleteMedicine(int id)
        {
            _medicineBL.DeleteMedicine(id);
        }

        public void AddMedicine(MedicineEntity newMedicine)
        {
            _medicineBL.AddMedicineAsync(newMedicine);
        }
    }
}

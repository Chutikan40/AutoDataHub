namespace AutoDataHub.Models
{
    public class CarsViewModel
    {
        // ข้อมูลทั่วไปของรถยนต์
        public int CarId { get; set; }          // 1. id รถ
        public string CarType { get; set; }      // 2. ประเภทรถ
        public string Brand { get; set; }        // 3. ยี่ห้อรถ
        public string Model { get; set; }        // 4. รุ่น
        public string Color { get; set; }        // 5. สี
        public string LicensePlate { get; set; } // 6. เลขทะเบียน

        // ฟิลด์เพิ่มเติมตามคำขอ
        public string EngineNumber { get; set; }       // 1.11 หมายเลขเครื่อง
        public string ChassisNumber { get; set; }      // 1.12 หมายเลขตัวถัง
        public int CylinderCount { get; set; }         // 1.13 จำนวนสูบ
        public int CC { get; set; }                    // 1.14 จำนวนซีซี
        public int Horsepower { get; set; }            // 1.15 แรงม้า
        public decimal SalePrice { get; set; }         // 1.16 ราคาขาย

        // วันที่ต่าง ๆ
        public DateTime RegistrationDate { get; set; }    // 1.17 วันที่จดทะเบียน
        public DateTime RegistrationExpireDate { get; set; } // 1.18 วันที่ทะเบียนหมดอายุ
        public DateTime PrbDate { get; set; }             // 1.19 วันที่ทำ พ.ร.บ.
        public DateTime PrbExpireDate { get; set; }       // 1.20 วันที่ พ.ร.บ. หมดอายุ
        public DateTime InsuranceDate { get; set; }       // 1.21 วันที่ทำประกัน
        public DateTime InsuranceExpireDate { get; set; } // 1.22 วันที่ประกันหมดอายุ

        // ข้อมูลผู้ประกอบการ
        public string Operator { get; set; }           // 1.23 ผู้ประกอบการ
        public string OperatorType { get; set; }       // 1.24 ประเภทประกอบการ
        public string LicenseNumber { get; set; }      // 1.25 เลขที่ใบอนุญาต
        public DateTime LicenseExpireDate { get; set; } // 1.26 วันที่ใบอนุญาตหมดอายุ

        // ข้อมูลประกัน
        public string InsurancePolicy { get; set; }    // 1.27 กรมธรรม์ พ.ร.บ.
        public string InsuranceCompany { get; set; }   // 1.28 บริษัทประกัน
        public string InsuranceType { get; set; }      // 1.29 ประเภทรถที่ทำประกัน
        public string CarUsageType { get; set; }       // 1.32 ลักษณะการใช้รถ
    }
}

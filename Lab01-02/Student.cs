using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    public class Student
    {
        // Thuộc tính
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string Khoa { get; set; }
        public double DiemTrungBinh { get; set; }

        // Constructor
        public Student(string maSo, string hoTen, string khoa, double diemTrungBinh)
        {
            MaSo = maSo;
            HoTen = hoTen;
            Khoa = khoa;
            DiemTrungBinh = diemTrungBinh;
        }

        // Phương thức xuất thông tin sinh viên
        public void XuatThongTin()
        {
            Console.WriteLine($"Mã số: {MaSo}, Họ tên: {HoTen}, Khoa: {Khoa}, Điểm trung bình: {DiemTrungBinh}");
        }
    }
}

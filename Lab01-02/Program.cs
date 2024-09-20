using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    class Program
    {
        static List<Student> danhSachSinhVien = new List<Student>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int luaChon;

            do
            {
                Console.WriteLine("\nChương trình quản lý sinh viên:");
                Console.WriteLine("1 – Thêm sinh viên");
                Console.WriteLine("2 – Xuất danh sách sinh viên");
                Console.WriteLine("3 – Xuất thông tin sinh viên thuộc khoa CNTT");
                Console.WriteLine("4 – Xuất thông tin sinh viên có điểm TB >= 5");
                Console.WriteLine("5 – Sắp xếp danh sách theo điểm TB tăng dần");
                Console.WriteLine("6 – Xuất thông tin sinh viên có điểm TB >= 5 và thuộc khoa CNTT");
                Console.WriteLine("7 – Xuất thông tin sinh viên có điểm TB cao nhất và thuộc khoa CNTT");
                Console.WriteLine("8 – Thống kê xếp loại sinh viên");
                Console.WriteLine("0 – Thoát");
                Console.Write("Nhập lựa chọn: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        ThemSinhVien();
                        break;
                    case 2:
                        XuatDanhSachSinhVien();
                        break;
                    case 3:
                        XuatSVKhoaCNTT();
                        break;
                    case 4:
                        XuatSVDiemLonHon5();
                        break;
                    case 5:
                        SapXepSinhVienTheoDiem();
                        break;
                    case 6:
                        XuatSVDiemLonHon5KhoaCNTT();
                        break;
                    case 7:
                        XuatSVDiemCaoNhatKhoaCNTT();
                        break;
                    case 8:
                        ThongKeXepLoai();
                        break;
                    case 0:
                        Console.WriteLine("Chương trình kết thúc.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (luaChon != 0);
        }

        // Thêm sinh viên
        static void ThemSinhVien()
        {
            Console.Write("Nhập mã số sinh viên: ");
            string maSo = Console.ReadLine();

            Console.Write("Nhập họ tên sinh viên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhập khoa: ");
            string khoa = Console.ReadLine();

            Console.Write("Nhập điểm trung bình: ");
            double diemTrungBinh = double.Parse(Console.ReadLine());

            Student sv = new Student(maSo, hoTen, khoa, diemTrungBinh);
            danhSachSinhVien.Add(sv);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        // Xuất danh sách sinh viên
        static void XuatDanhSachSinhVien()
        {
            if (danhSachSinhVien.Count == 0)
            {
                Console.WriteLine("Danh sách sinh viên rỗng.");
                return;
            }

            foreach (var sv in danhSachSinhVien)
            {
                sv.XuatThongTin();
            }
        }

        // Xuất sinh viên thuộc khoa CNTT
        static void XuatSVKhoaCNTT()
        {
            var sinhVienCNTT = danhSachSinhVien.Where(sv => sv.Khoa == "CNTT");

            foreach (var sv in sinhVienCNTT)
            {
                sv.XuatThongTin();
            }
        }

        // Xuất sinh viên có điểm TB >= 5
        static void XuatSVDiemLonHon5()
        {
            var sinhVienDiemLonHon5 = danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= 5);

            foreach (var sv in sinhVienDiemLonHon5)
            {
                sv.XuatThongTin();
            }
        }

        // Sắp xếp sinh viên theo điểm TB tăng dần
        static void SapXepSinhVienTheoDiem()
        {
            var danhSachSapXep = danhSachSinhVien.OrderBy(sv => sv.DiemTrungBinh).ToList();

            foreach (var sv in danhSachSapXep)
            {
                sv.XuatThongTin();
            }
        }

        // Xuất sinh viên có điểm TB >= 5 và thuộc khoa CNTT
        static void XuatSVDiemLonHon5KhoaCNTT()
        {
            var sinhVien = danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= 5 && sv.Khoa == "CNTT");

            foreach (var sv in sinhVien)
            {
                sv.XuatThongTin();
            }
        }

        // Xuất sinh viên có điểm TB cao nhất và thuộc khoa CNTT
        static void XuatSVDiemCaoNhatKhoaCNTT()
        {
            var sinhVienCNTT = danhSachSinhVien.Where(sv => sv.Khoa == "CNTT");
            var svDiemCaoNhat = sinhVienCNTT.OrderByDescending(sv => sv.DiemTrungBinh).FirstOrDefault();

            if (svDiemCaoNhat != null)
            {
                svDiemCaoNhat.XuatThongTin();
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa CNTT.");
            }
        }

        // Thống kê xếp loại sinh viên
        static void ThongKeXepLoai()
        {
            int xuatSac = 0, gioi = 0, kha = 0, trungBinh = 0, yeu = 0, kem = 0;

            foreach (var sv in danhSachSinhVien)
            {
                if (sv.DiemTrungBinh >= 9) xuatSac++;
                else if (sv.DiemTrungBinh >= 8) gioi++;
                else if (sv.DiemTrungBinh >= 7) kha++;
                else if (sv.DiemTrungBinh >= 5) trungBinh++;
                else if (sv.DiemTrungBinh >= 4) yeu++;
                else kem++;
            }

            Console.WriteLine($"Xuất sắc: {xuatSac}");
            Console.WriteLine($"Giỏi: {gioi}");
            Console.WriteLine($"Khá: {kha}");
            Console.WriteLine($"Trung bình: {trungBinh}");
            Console.WriteLine($"Yếu: {yeu}");
            Console.WriteLine($"Kém: {kem}");
        }

    }
}

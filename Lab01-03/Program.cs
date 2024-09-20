using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int choice;
            do
            {
                Console.WriteLine("Chương trình quản lý sinh viên và giáo viên:");
                Console.WriteLine("1- Thêm sinh viên");
                Console.WriteLine("2- Thêm giáo viên");
                Console.WriteLine("3- Xuất danh sách sinh viên");
                Console.WriteLine("4- Xuất danh sách giáo viên");
                Console.WriteLine("5- Số lượng từng danh sách");
                Console.WriteLine("6- Xuất danh sách sinh viên thuộc khoa 'CNTT'");
                Console.WriteLine("7- Xuất danh sách giáo viên có địa chỉ chứa 'Quận 9'");
                Console.WriteLine("8- Xuất danh sách sinh viên có điểm TB cao nhất và thuộc khoa 'CNTT'");
                Console.WriteLine("9- Thống kê xếp loại sinh viên");
                Console.WriteLine("0- Thoát");
                Console.Write("Nhập lựa chọn: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        AddTeacher();
                        break;
                    case 3:
                        DisplayStudents();
                        break;
                    case 4:
                        DisplayTeachers();
                        break;
                    case 5:
                        DisplayCounts();
                        break;
                    case 6:
                        DisplayStudentsByFaculty("CNTT");
                        break;
                    case 7:
                        DisplayTeachersByAddress("Quận 9");
                        break;
                    case 8:
                        DisplayTopStudentInFaculty("CNTT");
                        break;
                    case 9:
                        DisplayStudentRanks();
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }
            } while (choice != 0);
        }

        static void AddStudent()
        {
            Console.Write("Nhập mã sinh viên: ");
            string id = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập khoa: ");
            string faculty = Console.ReadLine();
            Console.Write("Nhập điểm trung bình: ");
            double gpa = double.Parse(Console.ReadLine());

            students.Add(new Student(id, name, faculty, gpa));
        }

        static void AddTeacher()
        {
            Console.Write("Nhập mã giáo viên: ");
            string id = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            string name = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            string address = Console.ReadLine();

            teachers.Add(new Teacher(id, name, address));
        }

        static void DisplayStudents()
        {
            Console.WriteLine("Danh sách sinh viên:");
            foreach (var student in students)
            {
                Console.WriteLine($"Mã: {student.Id}, Tên: {student.Name}, Khoa: {student.Faculty}, Điểm TB: {student.GPA}");
            }
        }

        static void DisplayTeachers()
        {
            Console.WriteLine("Danh sách giáo viên:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Mã: {teacher.Id}, Tên: {teacher.Name}, Địa chỉ: {teacher.Address}");
            }
        }

        static void DisplayCounts()
        {
            Console.WriteLine($"Tổng số sinh viên: {students.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teachers.Count}");
        }

        static void DisplayStudentsByFaculty(string faculty)
        {
            var result = students.Where(s => s.Faculty == faculty).ToList();
            if (result.Any())
            {
                Console.WriteLine($"Danh sách sinh viên thuộc khoa {faculty}:");
                foreach (var student in result)
                {
                    Console.WriteLine($"Mã: {student.Id}, Tên: {student.Name}, Điểm TB: {student.GPA}");
                }
            }
            else
            {
                Console.WriteLine($"Không có sinh viên thuộc khoa {faculty}");
            }
        }

        static void DisplayTeachersByAddress(string address)
        {
            var result = teachers.Where(t => t.Address.Contains(address)).ToList();
            if (result.Any())
            {
                Console.WriteLine($"Danh sách giáo viên có địa chỉ chứa '{address}':");
                foreach (var teacher in result)
                {
                    Console.WriteLine($"Mã: {teacher.Id}, Tên: {teacher.Name}, Địa chỉ: {teacher.Address}");
                }
            }
            else
            {
                Console.WriteLine($"Không có giáo viên có địa chỉ chứa '{address}'");
            }
        }

        static void DisplayTopStudentInFaculty(string faculty)
        {
            var topStudent = students.Where(s => s.Faculty == faculty).OrderByDescending(s => s.GPA).FirstOrDefault();
            if (topStudent != null)
            {
                Console.WriteLine($"Sinh viên có điểm TB cao nhất thuộc khoa {faculty}:");
                Console.WriteLine($"Mã: {topStudent.Id}, Tên: {topStudent.Name}, Điểm TB: {topStudent.GPA}");
            }
            else
            {
                Console.WriteLine($"Không có sinh viên thuộc khoa {faculty}");
            }
        }

        static void DisplayStudentRanks()
        {
            var ranks = new Dictionary<string, int>
            {
                { "Xuất sắc", students.Count(s => s.GPA >= 9) },
                { "Giỏi", students.Count(s => s.GPA >= 8 && s.GPA < 9) },
                { "Khá", students.Count(s => s.GPA >= 7 && s.GPA < 8) },
                { "Trung bình", students.Count(s => s.GPA >= 5 && s.GPA < 7) },
                { "Yếu", students.Count(s => s.GPA >= 4 && s.GPA < 5) },
                { "Kém", students.Count(s => s.GPA < 4) }
            };

            foreach (var rank in ranks)
            {
                Console.WriteLine($"{rank.Key}: {rank.Value}");
            }
        }
    }
}

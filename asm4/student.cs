using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM4.asm4
{

    public class Student
    {
        static List<Student> list = new List<Student>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age
        {
            get; set;
        }
        public double Math { get; set; }
        public double Physics { get; set; }
        public double Chemistry { get; set; }
        public double DTB => (Math + Physics + Chemistry) / 3;
        public string Academiccapacity
        {
            get
            {
                if (DTB >= 8)
                    return "Gioi";
                else if (DTB >= 6.5)

                    return "Kha";
                else if (DTB >= 5)

                    return "Trung Binh";
                else return "Yếu";
            }

        }

        //Main
        class Program
        {
            static List<Student> students = new List<Student>();

            static void Main(string[] args)
            {
                while (true)
                {
                    Console.WriteLine("===== MENU =====");
                    Console.WriteLine("1. Thêm sinh viên.");
                    Console.WriteLine("2. Cập nhật thông tin sinh viên bởi ID.");
                    Console.WriteLine("3. Xóa sinh viên bởi ID.");
                    Console.WriteLine("4. Tìm kiếm sinh viên theo tên.");
                    Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
                    Console.WriteLine("6. Sắp xếp sinh viên theo tên.");
                    Console.WriteLine("7. Sắp xếp sinh viên theo ID.");
                    Console.WriteLine("8. Hiển thị danh sách sinh viên.");
                    Console.WriteLine("9. Thoát.");
                    Console.Write("Nhập lựa chọn: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddStudent();
                            break;
                        case 2:
                            UpdateStudent();
                            break;
                        case 3:
                            RemoveStudent();
                            break;
                        case 4:
                            SearchStudentByName();
                            break;
                        case 5:
                            SortByGPA();
                            break;
                        case 6:
                            SortByName();
                            break;
                        case 7:
                            SortById();
                            break;
                        case 8:
                            DisplayStudent();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                            break;
                    }
                }
            }
            //ADD
            static void AddStudent()
            {
                Console.WriteLine("Nhập thông tin sinh viên: ");
                Student st = new Student();
                Console.WriteLine("Nhập ID sinh viên: ");
                st.Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhập tên : ");
                st.Name = Console.ReadLine();
                Console.WriteLine("Gioi tính : ");
                st.Gender = Console.ReadLine();
                Console.WriteLine("Tuổi : ");
                st.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Điểm toán: ");
                st.Math = double.Parse(Console.ReadLine());
                Console.WriteLine("Điểm lý: ");
                st.Physics = double.Parse(Console.ReadLine());
                Console.WriteLine("Điểm hóa: ");
                st.Chemistry = double.Parse(Console.ReadLine());
                list.Add(st);
                Console.WriteLine("Thêm sinh viên thành công!");

            }
            //Update
            static void UpdateStudent()
            {
                Console.WriteLine("Nhập ID sinh viên cần cập nhật : ");
                int id = int.Parse(Console.ReadLine());
                Student stUpdate = list.Find(s => s.Id == id);
                if (stUpdate != null)
                {
                    Console.WriteLine("Nhập thông tin cập nhật cho sinh viên:");
                    Console.Write("Tên: ");
                    stUpdate.Name = Console.ReadLine();
                    Console.Write("Giới tính: ");
                    stUpdate.Gender = Console.ReadLine();
                    Console.Write("Tuổi: ");
                    stUpdate.Age = int.Parse(Console.ReadLine());
                    Console.Write("Điểm Toán: ");
                    stUpdate.Math = double.Parse(Console.ReadLine());
                    Console.Write("Điểm Lý: ");
                    stUpdate.Physics = double.Parse(Console.ReadLine());
                    Console.Write("Điểm Hóa: ");
                    stUpdate.Chemistry = double.Parse(Console.ReadLine());

                    Console.WriteLine("Cập nhật thông tin sinh viên thành công.");
                }
                else { Console.WriteLine("Erro!"); }

            }
            //Remove
            static void RemoveStudent()
            {
                Console.WriteLine("Nhập ID sinh viên cần xóa: ");
                int id = int.Parse(Console.ReadLine());

                Student studentToRemove = list.Find(s => s.Id == id);
                if (studentToRemove != null)
                {
                    list.Remove(studentToRemove);
                    Console.WriteLine("Xóa sinh viên thành công.");
                }
                else
                {
                    Console.WriteLine("Erro.");
                }
            }

            //SearchByName
            static void SearchStudentByName()
            {
                Console.Write("Nhập tên sinh viên cần tìm: ");
                string name = Console.ReadLine();

                List<Student> searchResults = list.FindAll(s => s.Name.Contains(name));
                if (searchResults.Count > 0)
                {
                    Console.WriteLine("Kết quả tìm kiếm:");
                    foreach (var student in searchResults)
                    {
                        Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Tuổi: {student.Age}, Học lực: {student.Academiccapacity}");
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy kết quả.");
                }
            }

            static void SortByGPA()
            {
                list.Sort((s1, s2) => s2.DTB.CompareTo(s1.DTB));
                Console.WriteLine("Sắp xếp thành công");


            }
            static void SortByName()
            {
                list.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("Sắp xếp thành công");
            }
            static void SortById()
            {
                list.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));
                Console.WriteLine("Sắp xếp thành công");
            }

            static void DisplayStudent()
            {
                if (list.Count > 0)
                {
                    Console.WriteLine("Danh sách sinh viên: ");
                    foreach (var student in list)
                    {
                        Console.WriteLine($"ID: {student.Id}, Tên: {student.Name}, Tuổi: {student.Age}, Điểm Trung bình: {student.DTB}, Học lực: {student.Academiccapacity}");
                    }
                }
                else
                {
                    Console.WriteLine("Danh sách sinh viên trống");
                }
            }

        }




    }
}

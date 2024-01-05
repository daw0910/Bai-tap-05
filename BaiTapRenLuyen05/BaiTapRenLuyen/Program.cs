using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapRenLuyen
{
    public class CD
    {
        private int maCD;
        private string chuoiKT;
        private string caSi;
        private int soBH;
        private int giaThanh;
        public CD()
        { 

        }
        public CD(int maCD)
        {
            this.maCD = maCD;
        }
        public CD(int maCD, string chuoiKT, string caSi, int soBH, int giaThanh)
        {
            this.maCD = maCD;
            this.chuoiKT = chuoiKT;
            this.caSi = caSi;
            this.soBH = soBH;
            this.giaThanh= giaThanh;
        }
        public int MaCD
        {
           set { this.maCD = value; }
           get { return maCD; }
        }
        public string ChuoiKT
        {
            set { this.chuoiKT = value; }
            get { return chuoiKT; }
        }
        public string Casi
        {
            set { this.caSi = value; }
            get { return caSi; }
        }
        public int SoBH
        {
            set { this.soBH = value; }
            get { return soBH; }
        }
        public int GiaThanh
        {
            set { this.giaThanh = value; }
            get { return giaThanh; }
        }
        public string ToString()
        {
            return string.Format("{0,10} {1,30} {2,30){3,10} {4,15:#,##0}", maCD, chuoiKT, caSi, soBH, giaThanh);
        }
    }
    class QuanLiCD
    {
        private CD[] ds;
        private int n;
        public QuanLiCD()
        {
            ds = new CD[100];
            n = 0;
        }
        public QuanLiCD(int sophantu)
        {
            ds = new CD[sophantu];
            n = 0;
        }
        public void ThemCD(CD cd)
        {
            if (n >= ds.Length)
            {
                Console.WriteLine("Danh sach da day!");
            }
            else
            {
                if (!kiemTraTrungCD(cd.MaCD))
                    ds[n++] = cd;
                else
                {
                    Console.WriteLine("Da Trung Ma CD");
                }
            }
        }
        private bool kiemTraTrungCD(int maCD)
        {
            for (int i = 0; i < n; i++)
            {
                if (ds[i].MaCD == maCD)
                {
                    return true;
                }
            }
            return false;
        }
        public double tinhGiaTB()
        {
            int tonggia = 0;
            for (int i = 0; i < n; i++)
            {
                tonggia += ds[i].GiaThanh;
            }
            return (double)tonggia / n;
        }
        public void Xuat()
        {
            Console.WriteLine("{0,10} {1,30} {2,30){3,10} {4,15}", "MaCD", "TuaCD", "CaSi", "SoBaiHat", "GiaThanh");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(ds[i].ToString());
            }
        }
        public void SapXepGiamTheoGiaThanh()
        {
            CD tam;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (ds[i].GiaThanh < ds[j].GiaThanh)
                    {
                        //HoanVi
                        tam = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tam;
                    }
            }
        }
        public void SapXepTangDanTheoTuaCD()
        {
            CD tam;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                    if (ds[i].ChuoiKT.CompareTo(ds[j].ChuoiKT) > 0)
                    {
                        //HoanVi
                        tam = ds[i];
                        ds[i] = ds[j];
                        ds[j] = tam;
                    }
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            menu();
            //Console.ReadLine();
        }
        static void menu()
        {
            QuanLiCD quanLiCD = new QuanLiCD();
            int chon = 0;
            do
            {
                Console.WriteLine("---------------Chương trình quản lí Album CD-----------------");
                Console.WriteLine("1. Thêm CD");
                Console.WriteLine("2. Tính giá thành trung bình");
                Console.WriteLine("3. Sắp xếp CD giảm dần theo giá thành ");
                Console.WriteLine("4. Sắp xếp CD tăng dần theo giá thành ");
                Console.WriteLine("5. Xuất toàn bộ CD");
                Console.WriteLine("0. Thoát Chương Trình.");
                Console.WriteLine("______________________________________________________________");
                Console.Write("Bạn chọn");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        CD cD = new CD();
                        Console.Write("Nhập mã cd:");
                        cD.MaCD = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tựa CD:");
                        cD.ChuoiKT = Console.ReadLine();
                        Console.Write("Nhập ca sĩ:");
                        cD.ChuoiKT = Console.ReadLine();
                        Console.Write("Nhập số bài hát: ");
                        cD.SoBH = int.Parse(Console.ReadLine());
                        Console.Write("Nhập giá thành:");
                        cD.GiaThanh = int.Parse(Console.ReadLine());
                        quanLiCD.ThemCD(cD);
                        break;
                    case 2:
                        double kq = quanLiCD.tinhGiaTB();
                        Console.WriteLine("Giá thành trung bình: {0:#,##0.00}", kq);
                        break;
                    case 3:
                        quanLiCD.SapXepGiamTheoGiaThanh();
                        Console.WriteLine("Đã sắp xếp theo giá thành giảm dần");
                        break;
                    case 4:
                        quanLiCD.SapXepTangDanTheoTuaCD();
                        Console.WriteLine("Đã sắp xếp theo tựa CD tăng dần");
                        break;
                    case 5:
                        quanLiCD.Xuat();
                        break;
                    case 0:
                        Console.WriteLine("Hẹn gặp lại bạn!");
                        Console.ReadLine();
                        break;
                }
            } while (chon != 0);
            
        }
    }
}

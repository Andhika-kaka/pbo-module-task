using System;
using System.Collections.Generic;
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja sebagai Karyawan.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama : {Nama}");
        Console.WriteLine($"Gaji : Rp {Gaji:N0}");
    }
}

class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Karyawan Tetap.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Tunjangan  : Rp {Tunjangan:N0}");
        Console.WriteLine($"Gaji Total : Rp {HitungGajiTotal():N0}");
    }
}

class Kontrak : Karyawan
{
    public int Durasi { get; set; } // dalam bulan

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"{Nama} memiliki kontrak selama {Durasi} bulan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Karyawan Kontrak selama {Durasi} bulan.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Durasi Kontrak : {Durasi} bulan");
    }
}

class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin rapat tim.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Manager, mengawasi dan memimpin tim.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("[ Manager ]");
        base.InfoKaryawan();
    }
}
class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} sedang mengerjakan tugas harian.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Staff, menyelesaikan tugas operasional.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("[ Staff ]");
        base.InfoKaryawan();
    }
}

class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang belajar dan mengikuti program magang.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Magang, belajar sambil berkontribusi.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("[ Magang ]");
        base.InfoKaryawan();
    }
}

class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} sedang mengambil proyek baru sebagai Freelancer.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Freelancer, mengerjakan proyek secara mandiri.");
    }

    public override void InfoKaryawan()
    {
        Console.WriteLine("[ Freelancer ]");
        base.InfoKaryawan();
    }
}
class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"{karyawan.Nama} berhasil ditambahkan ke perusahaan.");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\nDaftar Karyawan Perusahaan");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
            Console.WriteLine();
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager manager = new Manager("Budi Santoso", 10000000, 3000000);
        Staff staff = new Staff("Ani Rahayu", 5000000, 1000000);
        Magang magang = new Magang("Citra Dewi", 1500000, 3);
        Freelancer freelancer = new Freelancer("Doni Prasetyo", 4000000, 6);

        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelancer);

        perusahaan.DaftarKaryawan();

        Console.WriteLine("\nSoal 1 - Method Kerja()");
        manager.Kerja();
        freelancer.Kerja();

        Console.WriteLine("\nSoal 2 - Method Memimpin()");
        manager.Memimpin();

        Console.WriteLine("\nSoal 3 - Info Lengkap Manager");
        manager.InfoKaryawan();

        Console.WriteLine("\nSoal 4 - Method Belajar()");
        magang.Belajar();

        Console.WriteLine("\nSoal 5 - Polymorphism");
        Karyawan karyawan = staff;
        karyawan.Kerja();

        Console.ReadKey();
    }

}
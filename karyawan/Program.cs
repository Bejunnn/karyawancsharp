using System;
using System.Collections.Generic;

// ================= ABSTRACT BASE CLASS =================
abstract class Karyawan
{
    public string Nama;
    public string Jabatan;

    public Karyawan(string nama, string jabatan)
    {
        Nama = nama;
        Jabatan = jabatan;
    }

    // Method abstrak -> wajib di-override tiap turunan (polimorfisme)
    public abstract void Kerja();
}

// ================= DERIVED CLASS 1 =================
class KaryawanTetap : Karyawan
{
    public double GajiPokok;

    public KaryawanTetap(string nama, double gajiPokok)
        : base(nama, "Karyawan Tetap")
    {
        GajiPokok = gajiPokok;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja penuh waktu di kantor.");
        Console.WriteLine($"Gaji pokok bulanan: Rp{GajiPokok:N0}");
    }
}

// ================= DERIVED CLASS 2 =================
class KaryawanKontrak : Karyawan
{
    public int DurasiBulan;

    public KaryawanKontrak(string nama, int durasiBulan)
        : base(nama, "Karyawan Kontrak")
    {
        DurasiBulan = durasiBulan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja berdasarkan kontrak kerja.");
        Console.WriteLine($"Sisa durasi kontrak: {DurasiBulan} bulan.");
    }
}

// ================= DERIVED CLASS 3 =================
class Freelancer : Karyawan
{
    public string Keahlian;

    public Freelancer(string nama, string keahlian)
        : base(nama, "Freelancer")
    {
        Keahlian = keahlian;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} mengerjakan proyek lepas (freelance).");
        Console.WriteLine($"Bidang keahlian: {Keahlian}.");
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main(string[] args)
    {
        List<Karyawan> daftarKaryawan = new List<Karyawan>
        {
            new KaryawanTetap("Arjun ", 8000000),
            new KaryawanKontrak("Heri", 6),
            new Freelancer("Yanto", "Informatika")
        };

        Console.WriteLine("=== POLIMORFISME RUNTIME (KARYAWAN) - RESOLUSI HEAP ===\n");

        foreach (Karyawan k in daftarKaryawan)
        {
            Console.WriteLine($"[Jabatan: {k.Jabatan}] Nama: {k.Nama}");
            k.Kerja(); // dispatch method ditentukan saat runtime, sesuai objek asli di heap
            Console.WriteLine(new string('-', 45));
        }
    }
}
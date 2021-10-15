using System;
using System.Collections.Generic;
using System.Text;

namespace PulsaOOP
{
    class PaketData : Pulsa
    {
        public static int totalHargaPaket;
        public static void TransaksiBeli()
        {
            jumlahBeli = Harga / 2000;
            totalHargaPaket += Harga;

            transaksi.Add($"Provider : {Provider} || Kuota : {jumlahBeli} (GB) || Harga Kuota : Rp. {Harga} || Ke Nomer : {Nomor}");

            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("--------------TRANSAKSI BERHASIL----------------");
            Console.WriteLine("------------------------------------------------");

            Console.Write("Apakah ada transaksi lain ? (Y|N)");
            string konfirmasi = Console.ReadLine();
            if ((konfirmasi == "Y") || (konfirmasi == "y"))
            {
                Program.Menu();
            }
            else if ((konfirmasi == "N") || (konfirmasi == "n"))
            {
                Program.HitungTransaksi();
            }
        }
        public static void UbahTransaksi()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.Write("Silahkan Masukkan Nomor HP : ");
            PaketData.Nomor = Console.ReadLine();
            Console.WriteLine("Silahkan Masukkan nama Provider : ");
            foreach (string a in Program.jenisOperator)
            {
                Console.WriteLine(a);
            }
            Console.Write("Input : ");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    PaketData.Provider = "Indosat";
                    break;
                case 2:
                    PaketData.Provider = "Telkomsel";
                    break;
                case 3:
                    PaketData.Provider = "XL";
                    break;
                case 4:
                    PaketData.Provider = "Axis";
                    break;
            }
            Console.Write("Silahkan masukkan jumlah Kuota yang akan di Beli (GB) :  ");
            PaketData.Harga = (int.Parse(Console.ReadLine())) * 2000;
            jumlahBeli = Harga / 2000;
            totalHargaPaket= Harga;

            transaksi[(idUbah - 1)] = ($"Provider : {Provider} || Kuota : {jumlahBeli} || Harga Kuota : Rp. {Harga} || Ke Nomer : {Nomor}");

            Console.Clear();
            Console.WriteLine("========== EDIT DATA Berhasil ==========");
            Console.WriteLine("Tekan ENTER untuk Kembali");
            string con = Console.ReadLine();
            Program.UbahHapus();
        }
    }
}

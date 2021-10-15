using System;
using System.Collections.Generic;
using System.Text;

namespace PulsaOOP
{
    class Pulsa
    {
        public static string Nomor { get; set; }
        public static string Provider { get; set; }
        public static int Harga { get; set; }

        public static int jumlahBeli, totalHargaPulsa, idUbah;

        public static List<string> transaksi = new List<string>();

        public static List<int> test = new List<int>();
        public static void TransaksiBeli()
        {
            jumlahBeli = Harga-2000;
            totalHargaPulsa += Harga;
            transaksi.Add($"Provider : {Provider} || Pulsa : {jumlahBeli} || Harga Pulsa : Rp. {Harga} || Ke Nomer : {Nomor}");

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
        public static void HapusTransaksi()
        {
            try
            {
                int id;
                Console.Write("Masukkan ID Transaksi yang akan di Hapus : ");
                id = int.Parse(Console.ReadLine());
                Console.Write($"Apakah ada ingin menghapus ID Transaksi {id} ? (Y|N)");
                string konfirmasi = Console.ReadLine();

                if ((konfirmasi == "Y") || (konfirmasi == "y"))
                {
                    transaksi.RemoveAt((id - 1));
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine("--------------TRANSAKSI BERHASIL----------------");
                    Console.WriteLine("------------------------------------------------");
                    string kon = Console.ReadLine();
                    Program.UbahHapus();

                }
                else if ((konfirmasi == "N") || (konfirmasi == "n"))
                {
                    Program.UbahHapus();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                Program.UbahHapus();
            }
            
        }
        public static void UbahTransaksi()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.Write("Silahkan Masukkan Nomor HP : ");
            Nomor = Console.ReadLine();
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
                    Pulsa.Provider = "Indosat";
                    break;
                case 2:
                    Pulsa.Provider = "Telkomsel";
                    break;
                case 3:
                    Pulsa.Provider = "XL";
                    break;
                case 4:
                    Pulsa.Provider = "Axis";
                    break;
            }
            Console.Write("Silahkan masukkan jumlah pulsa yang akan di beli :  ");
            Harga = (int.Parse(Console.ReadLine())) + 2000;
            jumlahBeli = Harga - 2000;
            totalHargaPulsa = Harga;

            transaksi[(idUbah-1)] = ($"Provider : {Provider} || Pulsa : {jumlahBeli} || Harga Pulsa : Rp. {Harga} || Ke Nomer : {Nomor}");

            Console.Clear();
            Console.WriteLine("========== EDIT DATA Berhasil ==========");
            Console.WriteLine("Tekan ENTER untuk Kembali");
            string con = Console.ReadLine();
            Program.UbahHapus();
        }
    }
}

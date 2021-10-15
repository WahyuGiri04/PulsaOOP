using System;

namespace PulsaOOP
{
    class Program
    {
        public static string[] jenisOperator = { "1. Indosat", "2. Telkomsel", "3. XL", "4. Axis" };
        public static int input, inputUang, kembalian, total;
        public static string konfirmasi;
        
        static void Main(string[] args)
        {
            Console.WriteLine("||============================================||");
            Console.WriteLine("||                                            ||");
            Console.WriteLine("||        SELAMAT DATANG DI KIOS PULSA        ||");
            Console.WriteLine("||                HEMAT FULL                  ||");
            Console.WriteLine("||                                            ||");
            Console.WriteLine("||============================================||");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Tekan Enter untuk Masuk ke Menu :");
            Console.ReadLine();
            Menu();
        }
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Pilih Pulsa atau Paket Data");
            Console.WriteLine("1. PULSA");
            Console.WriteLine("2. PAKET DATA");
            Console.WriteLine("3. HISTORY TRANSAKSI");
            Console.WriteLine("4. UBAH / HAPUS TRANSAKSI");
            Console.WriteLine("5. PEMBAYARAN");
            Console.Write("Masukkan Angka Pilihan : ");
            Console.Write("");
            try
            {
                int jenis = int.Parse(Console.ReadLine());
                switch (jenis)
                {
                    case 1:
                        BeliPulsa();
                        break;
                    case 2:
                        BeliPaketData();
                        break;
                    case 3:
                        HistoriTransaksi();
                        break;
                    case 4:
                        UbahHapus();
                        break;
                    case 5:
                        HitungTransaksi();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                Menu();
            }
        }
        public static void BeliPulsa()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------");
                Console.Write("Silahkan Masukkan Nomor HP : ");
                Pulsa.Nomor = Console.ReadLine();
                Console.WriteLine("Silahkan Masukkan nama Provider : ");
                foreach (string a in jenisOperator)
                {
                    Console.WriteLine(a);
                }
                Console.Write("Input : ");
                input = int.Parse(Console.ReadLine());
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
                Pulsa.Harga = (int.Parse(Console.ReadLine())) + 2000;
                Pulsa.TransaksiBeli();
            }
            catch(Exception)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                Menu();
            }                     
        }
        public static void BeliPaketData()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------");
                Console.Write("Silahkan Masukkan Nomor HP : ");
                PaketData.Nomor = Console.ReadLine();
                Console.WriteLine("Silahkan Masukkan nama Provider : ");
                foreach (string a in jenisOperator)
                {
                    Console.WriteLine(a);
                }
                Console.Write("Input : ");
                input = int.Parse(Console.ReadLine());
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
                PaketData.TransaksiBeli();
            }
            catch(Exception)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                Menu();
            }
        }
        public static void HistoriTransaksi()
        {
            try
            {
                Console.Clear();
                if (Pulsa.transaksi.Count == 0)
                {
                    Console.WriteLine("==================== BELUM ADA TRANSAKSI ====================");
                    Console.Write("Tekan ENTER untuk Kembali");
                    konfirmasi = Console.ReadLine();
                    Menu();
                }
                else
                {
                    Console.WriteLine("==================== TRANSAKSI ====================");
                    Console.WriteLine("");
                    int i = 1;
                    foreach (string item in Pulsa.transaksi)
                    {
                        Console.WriteLine($"{i} . {item}");
                        i++;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("===================================================");
                    Console.Write("Tekan ENTER Untuk Kembali");
                    konfirmasi = Console.ReadLine();
                    Menu();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                HistoriTransaksi();
            }
            
        }
        public static void HitungTransaksi()
        {           
            try
            {
                Console.Clear();
                if (Pulsa.transaksi.Count == 0)
                {
                    Console.WriteLine("==================== BELUM ADA TRANSAKSI ====================");
                    Console.Write("Tekan ENTER untuk Kembali");
                    konfirmasi = Console.ReadLine();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("==================== TRANSAKSI ====================");
                    Console.WriteLine("");
                    int i = 1;
                    foreach (string item in Pulsa.transaksi)
                    {
                        Console.WriteLine($"{i} . {item}");
                        i++;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("===================================================");
                    Console.WriteLine($"TOTAL HARGA                     : Rp. {Pulsa.totalHargaPulsa + PaketData.totalHargaPaket}");
                    Console.WriteLine("");
                    Console.Write("Jumlah Uang yang di bayarkan     : ");
                    inputUang = int.Parse(Console.ReadLine());
                    total = Pulsa.totalHargaPulsa + PaketData.totalHargaPaket;
                    kembalian = inputUang - total;
                    if (kembalian < 0)
                    {
                        Console.WriteLine("Uang Kurang !!!!");
                        konfirmasi = Console.ReadLine();
                        HitungTransaksi();
                    }
                    else
                    {
                        Console.WriteLine("===============================================");
                        Console.WriteLine($"Uang Kembalian               : Rp. {kembalian}");
                        Console.WriteLine("===============================================");
                        Console.WriteLine("================== Terimakasih ================");
                    }
                }                
            }
            catch(Exception)
            {
                Console.WriteLine("FORMAT INPUT ERROR !!!");
                string confrm = Console.ReadLine();
                HitungTransaksi();
            }
        }
        public static void UbahHapus()
        {
            try
            {
                Console.Clear();
                if (Pulsa.transaksi.Count == 0)
                {
                    Console.WriteLine("==================== BELUM ADA TRANSAKSI ====================");
                    Console.Write("Tekan ENTER untuk Kembali");
                    konfirmasi = Console.ReadLine();
                    Menu();
                }
                else
                {
                    Console.WriteLine("==================== TRANSAKSI ====================");
                    Console.WriteLine("");
                    int i = 1;
                    foreach (string item in Pulsa.transaksi)
                    {
                        Console.WriteLine($"{i} . {item}");
                        i++;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Hapus Transaksi");
                Console.WriteLine("2. Edit Transaksi");
                Console.WriteLine("3. Kembali");
                Console.Write("Input : ");
                input = int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        Pulsa.HapusTransaksi();
                        break;
                    case 2:
                        Console.WriteLine("============================================");
                        Console.Write("Masukkan ID Transaksi : ");
                        input = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Ubah Transaksi ID {input} ke :");
                        Console.WriteLine("1.PULSA");
                        Console.WriteLine("2.PAKET DATA");
                        Console.WriteLine("3. Cancel");
                        Console.Write("Input : ");
                        int inputUbah = int.Parse(Console.ReadLine());
                        switch(inputUbah)
                        {
                            case 1:
                                Pulsa.idUbah = input;
                                Pulsa.UbahTransaksi();
                                break;
                            case 2:
                                PaketData.idUbah = input;
                                PaketData.UbahTransaksi();
                                break;
                            case 3:
                                UbahHapus();
                                break;
                        }
                        break;
                    case 3:
                        Menu();
                        break;
                }
            }
            catch(Exception E)
            {
                Console.WriteLine("FORMAT INPUT ERROR KONTOL !!!");
                Console.WriteLine(E);
                string confrm = Console.ReadLine();
                UbahHapus();
            }
        }
    }
}

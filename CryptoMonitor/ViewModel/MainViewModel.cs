using System;
using System.IO;
using System.Net;
using CryptoMonitor.Model;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Collections.ObjectModel;

namespace CryptoMonitor.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables

        public double TotalWatt { get; set; }

        private string totalWattShow;
        public string TotalWattShow
        {
            get { return totalWattShow; }
            set { totalWattShow = value; RaisePropertyChanged();  }
        }

        private int gpuwatt = 200;
        public int Gpuwatt
        {
            get { return gpuwatt; }
            set { gpuwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private int cpuwatt = 10;
        public int Cpuwatt
        {
            get { return cpuwatt; }
            set { cpuwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private int festplattenwatt = 1;
        public int Festplattenwatt
        {
            get { return festplattenwatt; }
            set { festplattenwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private int ramwatt = 4;
        public int Ramwatt
        {
            get { return ramwatt; }
            set { ramwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private int luefterwatt = 5;
        public int Luefterwatt
        {
            get { return luefterwatt; }
            set { luefterwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private int monitorwatt = 45;
        public int Monitorwatt
        {
            get { return monitorwatt; }
            set { monitorwatt = value; RaisePropertyChanged(); GetTotalWatt(); }
        }

        private double stromkosten = 20;
        public double Stromkosten
        {
            get { return stromkosten; }
            set { stromkosten = value; RaisePropertyChanged(); Calculate(); }
        }

        private int poolfee = 1;
        public int Poolfee
        {
            get { return poolfee; }
            set { poolfee = value; RaisePropertyChanged(); Calculate(); }
        }

        private double gpuhash = 12;
        public double Gpuhash
        {
            get { return gpuhash; }
            set { gpuhash = value; RaisePropertyChanged(); Calculate(); }
        }

        internal class Response { public string[] Result { get; set; } }

        private ObservableCollection<Cryptocurrency> listCrypto = new ObservableCollection<Cryptocurrency>();
        public ObservableCollection<Cryptocurrency> ListCrypto
        {
            get { return listCrypto; }
            set { listCrypto = value; }
        }

        private Cryptocurrency selectedCrypto;
        public Cryptocurrency SelectedCrypto
        {
            get { return selectedCrypto; }
            set { selectedCrypto = value; RaisePropertyChanged(); }
        }
        #endregion

        public MainViewModel()
        {
            Gpuwatt = GetNvidiaWatt();
            GetTotalWatt();
            GetHashrate();
            //Die Kryptowährungen mit vollen Namen und Abkürzungen werden der Liste hinzugefügt
            ListCrypto.Add(new Cryptocurrency() { Name = "Bitcoin", NameKurz = "BTC" });
            ListCrypto.Add(new Cryptocurrency() { Name = "Ethereum", NameKurz = "ETH" });
            ListCrypto.Add(new Cryptocurrency() { Name = "Litecoin", NameKurz = "LTC" });

            foreach (var crypto in ListCrypto)
            {
                //Über die API von cryptowat.ch wird der Euro Preis von den Kryptowährungen aus der Liste geholt
                crypto.Price = (int)GetInfos("price", "https://api.cryptowat.ch/markets/kraken/" + crypto.NameKurz.ToLower() + "eur/price");
                //Über APIs werden die Netzwerkhashes und die Blocktime geholt
                if (crypto.Name.Equals("Ethereum"))
                {
                    crypto.Networkhash = GetInfos("hash_eth", "https://www.etherchain.org/api/basic_stats");
                    crypto.Blocktime = GetInfos("blocktime", "https://www.etherchain.org/api/basic_stats");
                    crypto.Blockreward = 6;
                }
                if (crypto.Name.Equals("Bitcoin"))
                {
                    crypto.Networkhash = GetInfos("hash_btc", "https://chain.so/api/v2/get_info/" + crypto.NameKurz.ToLower());
                    crypto.Blocktime = 600;
                    crypto.Blockreward = 12.5;
                }
                if (crypto.Name.Equals("Litecoin"))
                {
                    crypto.Networkhash = GetInfos("hash_ltc", "https://chain.so/api/v2/get_info/" + crypto.NameKurz.ToLower());
                    crypto.Blocktime = 150;
                    crypto.Blockreward = 25;
                }
            }
            Calculate();
            SelectedCrypto = ListCrypto[1];   
        }

        private void Calculate()
        {
            //Für jede Kryptowährung wird der Mining Betrag, die Stromkosten und den Profit den man mit der Grafikkarte
            //am Tag/im Monat/im Jahr erwirtschaftet ausgerechnet
            foreach (var crypto in ListCrypto)
            {
                //Gemined = (Zeit für ein Tag / Zeit für ein Block in s) * Belohnung * (Leistung der GPU in MH/s * Umrechnung in H/s / Netzwerkhash)
                crypto.MinedPerDay = (60 * 60 * 24 / crypto.Blocktime) * crypto.Blockreward * (Gpuhash * 1000000 / crypto.Networkhash);
                crypto.MinedPerMonth = crypto.MinedPerDay * 60;
                crypto.MinedPerYear = crypto.MinedPerDay * 365;
                crypto.MinedPerDayShow = crypto.MinedPerDay.ToString("N8");
                crypto.MinedPerMonthShow = crypto.MinedPerMonth.ToString("N8");
                crypto.MinedPerYearShow = crypto.MinedPerYear.ToString("N8");
                //GesamtStromkosten = Gesamtwatt in Watt / Umrechnung in KW) * (Stromkosten in cent / Umrechnung in Euro) * für ein Tag
                crypto.PowerCostPerDay = Math.Round((TotalWatt / 1000) * (Stromkosten / 100) * 24, 2);
                crypto.PowerCostPerMonth = Math.Round(crypto.PowerCostPerDay * 30, 2);
                crypto.PowerCostPerYear = Math.Round(crypto.PowerCostPerDay * 365, 2);
                crypto.PowerCostPerDayShow = crypto.PowerCostPerDay + " €";
                crypto.PowerCostPerMonthShow = crypto.PowerCostPerMonth + " €";
                crypto.PowerCostPerYearShow = crypto.PowerCostPerYear + " €";
                //Profit = (gemined * Preis der Kryptowährung - GesamtStromkosten) * Poolfee
                crypto.ProfitPerDay = Math.Round((crypto.MinedPerDay * crypto.Price - crypto.PowerCostPerDay) * (100 - Poolfee) / 100, 2);
                crypto.ProfitPerMonth = Math.Round(crypto.ProfitPerDay * 30, 2);
                crypto.ProfitPerYear = Math.Round(crypto.ProfitPerDay * 365, 2);
                crypto.ProfitPerDayShow = crypto.ProfitPerDay + "€";
                crypto.ProfitPerMonthShow = crypto.ProfitPerMonth + "€";
                crypto.ProfitPerYearShow = crypto.ProfitPerYear + "€";
            }
        }

        private double GetInfos(string x, string url)
        {
            try
            {
                //API Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    //API Antwort auslesen
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    //Das ausgelesene in ein Json Object umwandeln
                    dynamic json = JObject.Parse(reader.ReadToEnd());
                    switch (x)
                    {
                        //Die gewählten Wert zurückgeben
                        case "price": return (json.result.price);
                        case "hash_btc": return (json.data.hashrate);
                        case "hash_eth": return (json.currentStats.hashrate);
                        case "hash_ltc": return (json.data.hashrate);
                        case "blocktime": return (json.currentStats.block_time);
                        default: return 0;
                    }
                }
            }
            catch (Exception) { return 0; }
        }

        private int GetNvidiaWatt()
        {
            try
            {
                //Prozess starten, cmd.exe wird im Hintergrund ausgeführt mit dem angegeben Argument um den GPU Stromverbrauch in Watt auszulesen
                Process pProcess = new Process();
                pProcess.StartInfo.FileName = "cmd.exe";
                pProcess.StartInfo.Arguments = @"/C cd C:\Program Files\NVIDIA Corporation\NVSMI\&nvidia-smi -i 0 --format=csv --query-gpu=power.limit";
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.CreateNoWindow = true;
                pProcess.Start();
                string cmdOutput = pProcess.StandardOutput.ReadToEnd();
                return int.Parse(cmdOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.None)[1].Split('.')[0]);
            }
            catch (Exception) { return Gpuwatt; }
        }

        private void GetTotalWatt()
        {
            TotalWatt = Gpuwatt + Cpuwatt + Festplattenwatt + Ramwatt + Luefterwatt + Monitorwatt;
            TotalWattShow = TotalWatt + " Watt";
        }

        private void GetHashrate()
        {
            try
            {
                //Hashrate der GPU wird ausgelesen
                var res = JsonConvert.DeserializeObject<Response>(SendCommand("{\"id\":0,\"jsonrpc\":\"2.0\",\"method\":\"miner_getstat1\"}"));
                if (!res.Equals("0"))
                    Gpuhash = Int32.Parse(res.Result[2].Split(';')[0])/1000;
            }
            catch (Exception) { }
        }

        private static string SendCommand(string command)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();

                int port = 0;
                Int32.TryParse("3333", out port);

                tcpclnt.Connect("127.0.0.1", port);
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(command);
                stm.Write(ba, 0, ba.Length);
                byte[] bb = new byte[1000];
                int k = stm.Read(bb, 0, 1000);

                StringBuilder Response = new StringBuilder();

                for (int i = 0; i < k; i++)
                    Response.Append(Convert.ToChar(bb[i]));

                tcpclnt.Close();

                return Response.ToString();
            }
            catch (Exception) { return "0"; }
        }
    }
}
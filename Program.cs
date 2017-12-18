using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravellingSalesmanCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problem = new TravellingSalesmanProblem(new List<Location>()
            {
                new Location("Headquarters/Levent", "Talatpaşa Cd. No:5, Esentepe Mahallesi, 34394 Şişli / İstanbul"),
                new Location("Ahmet/Beylikdüzü", "Hoşseda Sokağı, Barış Mahallesi, 34520 Beylikdüzü Osb/ Beylikdüzü / İstanbul"),
                new Location("Safa/Esenyurt", "Doğan Araslı Blv.No:120, İnönü Mahallesi, 34510 Beylikdüzü Osb/ Esenyurt / İstanbul"),
                new Location("Orhan/Güngören", "Nadide Sokağı No: 116, Mehmet Nesih Özmen Mahallesi, 34173 Güngören / İstanbul"),
                new Location("Barış/Zeytinburnu", "Prof.Dr.Turan Güneş Cd.No:84, Sümer Mahallesi, 34025 Zeytinburnu / İstanbul"),
                new Location("Özgür/Maslak", "13.Sk.No:31, Maslak Mahallesi, 34398 Şişli / İstanbul"),
                new Location("Pınar/İstinye", "İstinye Cd. 76 - 78, İstinye Mahallesi, 34460 Sarıyer / İstanbul"),
                new Location("İmren/Sarıyer", "Araba Yolu Cd.No:201, Kireçburnu Mahallesi, 34457 Sarıyer / İstanbul"),
                new Location("Damra/Ünalan", "Cumhur Sokağı No: 3, Ünalan Mahallesi, 34700 Üsküdar / İstanbul"),
                new Location("Mustafa/Ataşehir", "Fırat Cd. 9e, Ataşehir Atatürk Mahallesi, 34758 Dudullu Osb/ Ataşehir / İstanbul"),
                new Location("Tahsin/Gaziosmanpaşa", "41.0853032, 28.9088058"),
            });
            var route = problem.Solve();

            Console.ReadKey();
        }
    }
    
}

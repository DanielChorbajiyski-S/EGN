using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex
{
    public class EGN : IEGNValidator
    {

        private Dictionary<string, int[]> regionInterval = new Dictionary<string, int[]>
        {
            {"Благоевград", new int[]{0, 43} },
            {"Бургас", new int[]{44,93}},
            {"Варна", new int[]{94, 139}},
            {"Велико Търново", new int[]{140, 169}},
            {"Видин", new int[]{170, 183}},
            {"Враца",new int[]{184, 217}},
            {"Габрово",new int[]{218, 233}},
            {"Кърджали",new int[]{234, 281}},
            {"Кюстендил",new int[]{282, 301}},
            {"Ловеч",new int[]{302, 319}},
            {"Монтана",new int[]{320, 341}},
            {"Пазарджик",new int[]{342, 377}},
            {"Перник",new int[]{378, 395}},
            {"Плевен",new int[]{396, 435}},
            {"Пловдив",new int[]{436, 501}},
            {"Разград",new int[]{501, 527}},
            {"Русе",new int[]{528, 555}},
            {"Силистра",new int[]{556, 575}},
            {"Сливен",new int[]{576, 601}},
            {"Смолян",new int[]{602, 623}},
            {"София-град",new int[]{624, 721}},
            {"София-окръг",new int[]{722, 751}},
            {"Стара Загора",new int[]{752, 789}},
            {"Добрич",new int[]{790, 821}},
            {"Търговище",new int[]{822, 843}},
            {"Хасково",new int[]{844, 871}},
            {"Шумен",new int[]{872, 903}},
            {"Ямбол",new int[]{904, 925}},
            {"Друг",new int[]{926, 999}}
        };
        public string[] Generate(DateTime birthDate, string city, bool isMale)
        {
            List<string> allEgn = new();
            int year = birthDate.Year;
            int month = birthDate.Month;
            int day = birthDate.Day;
            int addToMonth = 0;
            bool even = isMale;
            int[] region = new int[2];

            addToMonth = GetAddition(year);

            string yearString = (year % 100).ToString("D2");
            string monthString = (month+addToMonth).ToString("D2");
            string dayString = day.ToString("D2");

            StringBuilder egn = new();
            egn.Append(yearString);
            egn.Append(monthString);
            egn.Append(dayString);

            region = GetRange(city);

            for (int i = region[0]; i <= region[1]; i++)
            {
                StringBuilder egnFull = new StringBuilder(egn.ToString());
                egnFull.Append(i.ToString("D3"));
                string finalEgn = AppendLastDigit(egnFull);
                allEgn.Add(finalEgn);
            }

            string[] possible = FilterByGender(allEgn, isMale).ToArray();

            return possible;

        }

        
        private int GetAddition(int year)
        {
            if (year < 1900)
            {
                return 20;
            }
            else if (year > 1999)
            {
                return 40;
            }
            else
            {
                return 0;
            }
        }
        private int[] GetRange(string city)
        {
            switch (city)
            {
                case "Благоевград":
                    return regionInterval["Благоевград"];
                    break;
                case "Бургас":
                    return regionInterval["Бургас"];
                    break;
                case "Варна":
                    return regionInterval["Варна"];
                    break;
                case "Велико Търново":
                    return regionInterval["Велико Търново"];
                    break;
                case "Видин":
                    return regionInterval["Видин"];
                    break;
                case "Враца":
                    return regionInterval["Враца"];
                    break;
                case "Габрово":
                    return regionInterval["Габрово"];
                    break;
                case "Кърджали":
                    return regionInterval["Кърджали"];
                    break;
                case "Кюстендил":
                    return regionInterval["Кюстендил"];
                    break;
                case "Ловеч":
                    return regionInterval["Ловеч"];
                    break;
                case "Монтана":
                    return regionInterval["Монтана"];
                    break;
                case "Пазарджик":
                    return regionInterval["Пазарджик"];
                    break;
                case "Перник":
                    return regionInterval["Перник"];
                    break;
                case "Плевен":
                    return regionInterval["Плевен"];
                    break;
                case "Пловдив":
                    return regionInterval["Пловдив"];
                    break;
                case "Разград":
                    return regionInterval["Разград"];
                    break;
                case "Русе":
                    return regionInterval["Русе"];
                    break;
                case "Силистра":
                    return regionInterval["Силистра"];
                    break;
                case "Сливен":
                    return regionInterval["Сливен"];
                    break;
                case "Смолян":
                    return regionInterval["Смолян"];
                    break;
                case "София-град":
                    return regionInterval["София-град"];
                    break;
                case "София-окръг":
                    return regionInterval["София-окръг"];
                    break;
                case "Стара Загора":
                    return regionInterval["Стара Загора"];
                    break;
                case "Добрич":
                    return regionInterval["Добрич"];
                    break;
                case "Търговище":
                    return regionInterval["Търговище"];
                    break;
                case "Хасково":
                    return regionInterval["Хасково"];
                    break;
                case "Шумен":
                    return regionInterval["Шумен"];
                    break;
                case "Ямбол":
                    return regionInterval["Ямбол"];
                    break;
                default:
                    return regionInterval["Друг"];
                    break;
            }
        }
        private string AppendLastDigit(StringBuilder egn)
        {
            int sum = 0;
            for (int i = 0; i < egn.Length; i++)
            {
                int num = int.Parse(egn[i].ToString());
                int multiplier =0;
                switch (i+1)
                {
                    case 1:
                        multiplier = 2;
                        break;
                    case 2:
                        multiplier = 4;
                        break;
                    case 3:
                        multiplier = 8;
                        break;
                    case 4:
                        multiplier = 5;
                        break;
                    case 5:
                        multiplier = 10;
                        break;
                    case 6:
                        multiplier = 9;
                        break;
                    case 7:
                        multiplier = 7;
                        break;
                    case 8:
                        multiplier = 3;
                        break;
                    case 9:
                        multiplier = 6;
                        break;
                }
                sum += num*multiplier;
            }
            int devided = sum % 11;
            if (devided == 10 || devided == 0)
            {
                devided = 0;
            }
            return egn.Append(devided).ToString();
        }

        private List<string> FilterByGender(List<string> allEgn, bool isMale)
        {
            List<string> filteredEgn = new();
            foreach (string egn in allEgn)
            {
                if (isMale && egn[8] % 2 == 0)
                {
                    filteredEgn.Add(egn);
                }
                else if (!isMale && egn[8] % 2 != 0)
                {
                    filteredEgn.Add(egn);
                }
            }
            return filteredEgn;
        }
        public bool Validate(string egn)
        {
            if (egn.Length != 10)
            {
                return false;
            }
            return true;
        }
    }
}

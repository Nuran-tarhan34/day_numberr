using System.Reflection.Metadata;

namespace DayNumberProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
			 Soru:
			> ay numarası
			> bu ayın ait olduğu yılın artık yıl olup olmadığı (e/E/h/H) ve
			> gün numarası
			verilerini kullanıcıdan alan (kullanıcının geçerli bir tarihe ilişkin veri girmesi sağlanmalıdır)
			ve yılbaşından bu tarihe kadar geçen gün sayısını hesaplayıp ekrana yazdıran, daha sonra
			kullanıcıya başka bir tarih girmek isteyip istemediğini soran (e/E/h/H) bir program yazınız.
			
			ay_no_al(): kullanıcıdan, geçerli bir ay numarası alınmasını sağlar ve bu ay numarasını
			döndürür.

			artik_yil_al(): kullanıcıdan, işlem yapılacak yılın artık yıl olup olmadığının (e/E/h/H)
			alınmasını sağlar ve artık yılsa True, değilse False döndürür.

			gun_no_al(ay_no, artik_yil): ay numarası ve bu ayın ait olduğu yılın artık yıl olup olmadığı
			parametreler ile verilen ay için kullanıcıdan, geçerli bir gün numarası alınmasını sağlar ve bu
			gün numarasını döndürür.

			tekrar_al(): kullanıcıdan, başka bir tarih için hesaplama yapmak isteyip istemediğinin
			(e/E/h/H) alınmasını sağlar ve istiyorsa True, istemiyorsa False döndürür

			 */

            bool isContinue = true;
            string isContinueStr;

            while (isContinue)
            {
                int monthNum = GetMonthNum();

                //artik_yil_al():
                bool leapYear = IsLeapYear();

                //gun_no_al(ay_no, artik_yil):
                int dayNum = GetDayNum(monthNum, leapYear);

                int totalDayNum = 0;

                for (int i = 1; i < monthNum; i++)
                {
                    totalDayNum = totalDayNum + GetDayOfMonth(i, leapYear);
                }

                totalDayNum = totalDayNum + dayNum;

                Console.WriteLine("Yılbaşından bu tarihe kadar geçen gün sayısı" + totalDayNum);


                Console.WriteLine("Başka bir tarih için hesaplama yapmak ister misiniz? (e/E/h/H)::");
                isContinueStr = Console.ReadLine();

                if (isContinueStr == "h" || isContinueStr == "H")
                {
                    isContinue = false;
                }
            }

            //ay_no_al():


        }

        public static int GetMonthNum()
        {
            int monthNum;

            Console.WriteLine("İşlem yapmak istediğiniz tarihin ay numarasını giriniz:");
            monthNum = Convert.ToInt32(Console.ReadLine());

            do
            {
                if (monthNum < 1 || monthNum > 12)
                {
                    Console.WriteLine("Hatalı veri, lütfen tekrar giriniz:");
                    monthNum = Convert.ToInt32(Console.ReadLine());
                }
            } while (monthNum < 1 || monthNum > 12);

            /*while(monthNum < 1 || monthNum > 12)
			{
				Console.WriteLine("Hatalı veri, lütfen tekrar giriniz:");
				monthNum = Convert.ToInt32(Console.ReadLine());
			}*/

            return monthNum;
        }

        public static bool IsLeapYear()
        {
            string leapYearStr;

            Console.WriteLine("bu ayın ait olduğu yıl, artık yıl mı? (e/E/h/H)::");
            leapYearStr = Console.ReadLine();

            do
            {
                if (!(leapYearStr == "E" || leapYearStr == "e" || leapYearStr == "H" || leapYearStr == "h"))
                {
                    Console.WriteLine("Hatalı veri, lütfen tekrar giriniz:");
                    leapYearStr = Console.ReadLine();
                }
            } while (!(leapYearStr == "E" || leapYearStr == "e" || leapYearStr == "H" || leapYearStr == "h"));

            if (leapYearStr == "E" || leapYearStr == "e")
            {
                return true;
            }

            return false;
        }

        public static int GetDayNum(int monthNum, bool leapYear)
        {
            int dayNum = 0;

            Console.WriteLine("gün numarasın giriniz::");
            dayNum = Convert.ToInt32(Console.ReadLine());

            int maxDayCount = GetDayOfMonth(monthNum, leapYear);

            do
            {
                if (dayNum < 1 || dayNum > maxDayCount)
                {
                    Console.WriteLine("Hatalı veri, lütfen tekrar giriniz:");
                    dayNum = Convert.ToInt32(Console.ReadLine());
                }
            } while (dayNum < 1 || dayNum > maxDayCount);

            return dayNum;
        }

        public static int GetDayOfMonth(int monthNum, bool leapYear)
        {
            switch (monthNum)
            {
                case 1:
                    return 31;
                case 2:
                    if (leapYear)
                    {
                        return 29;
                    }
                    return 28;
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }
    }

}
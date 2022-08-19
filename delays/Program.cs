using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delays
{
    class Program
    {
        static void Main ( string [] args )
        {
            Work work = new Work ();
            work.Works ();
        }
    }

    class Work
    {
        private DateTime _dateTime = new DateTime (2022, 08, 20);
        private List<Stew> _stews = new List<Stew> ();

        public Work ()
        {
            _stews.Add ( new Stew ( "Сгущенка", "Турция", 2023 ) );
            _stews.Add ( new Stew ( "Тушенка", "Россия", 2025 ) );
            _stews.Add ( new Stew ( "Сгущенка", "Белорусь", 2021 ) );
            _stews.Add ( new Stew ( "Тушенка", "Украина", 2021 ) );
            _stews.Add ( new Stew ( "Тушенка", "Россия", 2015 ) );
            _stews.Add ( new Stew ( "Тушенка", "Украина", 2020 ) );
            _stews.Add ( new Stew ( "Тушенка", "Турция", 2019 ) );
        }

        public void Works ()
        {
            bool isWorks = true;
            string input;

            while ( isWorks == true )
            {
                Console.WriteLine ( _dateTime );
                Console.WriteLine ( "\n1 - Посмотреть весь список." +
                    "\n2 - Посмотреть все просроченные банки." +
                    "\n3 - Exit." );
                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        ShowFoolList ();
                        break;
                    case "2":
                        ShowTheOverdueList ();
                        break;
                    case "3":
                        isWorks = false;
                        break;
                    default:
                        Console.WriteLine ("Что-то пошло не так!");
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void ShowFoolList ()
        {
            Console.WriteLine ("Весь список.\n");
            foreach ( var stew in _stews )
            {
                stew.ShowInfo ();
            }
        }

        private void ShowTheOverdueList ()
        {
            int ThisYear = 2022;
            Console.WriteLine ("Список просроченных банок\n");

            var IsTheBankOverdue = from Stew stew in _stews where stew.ExpirationDate < ThisYear select stew;

            foreach ( var stew in IsTheBankOverdue )
            {
                stew.ShowInfo ();
            }       
        }
    }

    class Stew
    {
        private string _name;
        private string _yearOfProduction;

        public Stew ( string name, string yearOfProduction, int expirationDate )
        {
            _name = name;
            _yearOfProduction = yearOfProduction;
            ExpirationDate = expirationDate;
        }

        public int ExpirationDate { get; private set; }

        public void ShowInfo ()
        {
            Console.WriteLine ($"{_name} \tгород производства {_yearOfProduction} \tсрок годности {ExpirationDate}\n");
        }
    }
}
/*Задача:
Есть набор тушенки. У тушенки есть название, год производства и срок годности.
Написать запрос для получения всех просроченных банок тушенки.
Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.*/
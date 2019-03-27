using System;
using System.Linq;

namespace Malynovskiy03Sharp
{
    public class PersonCreationException : Exception
    {
        public PersonCreationException(string message)
            : base(message)
        {
        }
    }

    public class WrongNameException : PersonCreationException
    {
        public WrongNameException(string message)
            : base(message)
        {
        }
    }

    public class WrongSurnameException : PersonCreationException
    {
        public WrongSurnameException(string message)
            : base(message)
        {
        }
    }

    public class WrongEmailException : PersonCreationException
    {
        public WrongEmailException(string givenEmail)
            : base(string.Format("Email {0} is not valid!", givenEmail))
        {
        }
    }

    public class WrongBirthdayException : PersonCreationException
    {
        public WrongBirthdayException(DateTime birthday)
            : base(string.Format("Birthday {0} is not valid!", birthday.ToShortDateString()))
        {
        }
    }

    public class Person
    {
        internal readonly string Name;
        internal readonly string Surname;
        internal readonly string Email;
        internal readonly DateTime Birthday;

        public Person(string name, string surname, string email, DateTime birthday)
        {
            if (name.Length < 2)
            {
                throw new WrongNameException(string.Format("Name {0} is too small!", name));
            }

            if (surname.Length < 2)
            {
                throw new WrongSurnameException(string.Format("Surname {0} is too small!", surname));
            }

            if (email.Length < 3 || email.Count(f => f == '@') != 1 ||
                (email.IndexOf("@", StringComparison.Ordinal) == email.Length - 1) ||
                (email.IndexOf("@", StringComparison.Ordinal) == 0))
            {
                throw new WrongEmailException(email);
            }

            var yearsDif = DateTime.Today.YearsPassedCnt(birthday);
            if (yearsDif < 0 || yearsDif > 135)
            {
                throw new WrongBirthdayException(birthday);
            }

            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }

        public Person(string name, string surname, string email)
            : this(name, surname, email, DateTime.Today)
        {
        }

        public Person(string name, string surname, DateTime birthday)
            : this(name, surname, "not specified", birthday)
        {
        }

        public bool IsAdult
        {
            get
            {
                if (DateTime.Today.YearsPassedCnt(Birthday) >= 18) return true;
                return false;
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (DateTime.Today.DayOfYear == Birthday.DayOfYear) return true;
                return false;
            }
        }

        public string ChineseSign
        {
            get
            {
                if (ChineseZodiaсs.Length > (Birthday.Year + 8) % 12) return ChineseZodiaсs[(Birthday.Year + 8) % 12];
                return null;
            }
        }

        public string SunSign
        {
            get
            {
                var day = Birthday.Day;
                int westZodiacNum;
                switch (Birthday.Month)
                {
                    case 1: 
                        westZodiacNum = day <= 20 ? 9 : 10;
                        break;
                    case 2: 
                        westZodiacNum = day <= 19 ? 10 : 11;
                        break;
                    case 3: 
                        westZodiacNum = day <= 20 ? 11 : 0;
                        break;
                    case 4: 
                        westZodiacNum = day <= 20 ? 0 : 1;
                        break;
                    case 5: 
                        westZodiacNum = day <= 20 ? 1 : 2;
                        break;
                    case 6: 
                        westZodiacNum = day <= 20 ? 2 : 3;
                        break;
                    case 7: 
                        westZodiacNum = day <= 21 ? 3 : 4;
                        break;
                    case 8: 
                        westZodiacNum = day <= 22 ? 4 : 5;
                        break;
                    case 9: 
                        westZodiacNum = day <= 21 ? 5 : 6;
                        break;
                    case 10: 
                        westZodiacNum = day <= 21 ? 6 : 7;
                        break;
                    case 11: 
                        westZodiacNum = day <= 21 ? 7 : 8;
                        break;
                    case 12: 
                        westZodiacNum = day <= 21 ? 8 : 9;
                        break;
                    default:
                        westZodiacNum = 0;
                        break;
                }

                return WesternZodiaсs[westZodiacNum];
            }
        }

        private static readonly string[] WesternZodiaсs =
        {
            "Ram", "Bull", "Twins", "Crab", "Lion", "Virgin", "Scales", "Scorpion", "Archer", "Mountain Sea-Goat", "Water Bearer", "Fish"
        };

        private static readonly string[] ChineseZodiaсs =
        {
            "Rat", "Ox", "Tiger", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
        };
    }
}


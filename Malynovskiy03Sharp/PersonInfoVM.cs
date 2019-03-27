using System.ComponentModel;
using System.Runtime.CompilerServices;
using Malynovskiy03Sharp.Annotations;

namespace Malynovskiy03Sharp
{
    class PersonInfoVM : INotifyPropertyChanged
    {
        private readonly Person _person;

        public string Name
        {
            get
            {
                return string.Format("Your name:\n{0}", _person.Name);
            }
        }

        public string Surname
        {
            get
            {
                return string.Format("Your surname:\n{0}", _person.Surname);
            }
        }

        public string Email
        {
            get
            {
                return string.Format("Your email:\n{0}", _person.Email);
            }
        }

        public string BirthDate
        {
            get
            {
                return string.Format("Your birthday:\n{0}", _person.Birthday.ToShortDateString());
            }
        }

        public string SunSign
        {
            get
            {
                return string.Format("Your sun sign:\n{0}", _person.SunSign);
            }
        }

        public string ChineseSign
        {
            get
            {
                return string.Format("Your chinese sign:\n{0}", _person.ChineseSign);
            }
        }

        public string IsBirthday
        {
            get
            {
                return string.Format("Today is {0}your birthday", _person.IsBirthday ? "" : "not ");
            }
        }

        public string IsAdult
        {
            get
            {
                return string.Format("You are {0}adult", _person.IsAdult ? "" : "not ");
            }
        }

        public PersonInfoVM(Person person)
        {
            _person = person;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

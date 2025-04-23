namespace E1
{
    public interface IPerson
    {
        string Name { get; }
        bool IsFemale { get; init; }
        int LunchRate { get; }
    }

    public class Student : IPerson
    {
        public string Name {get; private set;}
        public bool IsFemale {get; init;}
        public int LunchRate {get; private set;} = 2000;
        public Student(string _name, bool _isfemale)
        {
            this.IsFemale = _isfemale;
            this.Name = _isfemale? $"خانم {_name}" : $"آقای {_name}";
        }
    }

    public interface IEmployee
    {
        int CalculateSalary(int hours);
    }

    public class Teacher : IEmployee, IPerson
    {
        public string Name {get; private set;}
        public bool IsFemale {get; init;}
        public int LunchRate {get; private set;} = 10000;
        public Teacher (string _name, bool _isfemale)
        {
            this.IsFemale = _isfemale;
            this.Name = $"استاد {_name}";
        }
        public int CalculateSalary(int hours)
        {
            return 20000*hours;
        }
    }
}
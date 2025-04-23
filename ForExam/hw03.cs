using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;
using System;
using System.Collections;

namespace A8;

public interface IPerson
{
    string Firstname {get; set;}
    string Lastname {get; set;}
    
}

public interface IDoctor 
{
    string Field {get; set;}
    long Salary {get; set;}
    string University {get; set;}
    List<Patient> patients {get; set;}
    void Work()
    {
        Console.WriteLine("J");
    }
}

public class GeneralPractitioner : IDoctor, IPerson, IComparable<GeneralPractitioner>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public List<Patient> patients {get; set;}
    public long Salary {get; set;}
    public string University {get; set;}
    public string Field {get; set;}

    public GeneralPractitioner(string firstname, string lastname ,string field, long salary, string university)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.patients = new List<Patient>();
        this.Field = field;
        this.University = university;
        this.Salary = salary;
    }

    public static GeneralPractitioner operator +(GeneralPractitioner doctor, Patient patient)
    {
        var newDoctor = new GeneralPractitioner(doctor.Firstname, doctor.Lastname, doctor.Field, doctor.Salary, doctor.University)
        {
            patients = new List<Patient>(doctor.patients)
        };
        if (patient.Disease == "Cough" || patient.Disease == "Sore Throat" || patient.Disease == "Sneezing") newDoctor.patients.Add(patient);
        return newDoctor;
    }

    public static bool operator <(GeneralPractitioner d1, GeneralPractitioner d2)
    {
        return string.Compare(d1.University.Split()[1], d2.University.Split()[1]) < 0;
    }

    public static bool operator >(GeneralPractitioner d1, GeneralPractitioner d2)
    {
        return string.Compare(d1.University.Split()[1], d2.University.Split()[1]) > 0;
    }

    public string GraduatedFrom()
    {
        string universityName = University.Split(" ")[0];
        return $"{Firstname} {Lastname} is graduated from {universityName}";
    }

    public string Work()
    {
        return $"This General Practitioner works on {Field}";
    }

    public int CompareTo(GeneralPractitioner other)
    {
        if (other == null) return 1;

        double thisRatio = 0;
        if (patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            thisRatio = (double)recoveredCount / patients.Count;
        }

        double otherRatio = 0;
        if (other.patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in other.patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            otherRatio = (double)recoveredCount / other.patients.Count;
        }

        if (thisRatio != otherRatio) return thisRatio.CompareTo(otherRatio);

        string thisFullName = $"{Firstname} {Lastname}";
        string otherFullName = $"{other.Firstname} {other.Lastname}";
        return string.Compare(thisFullName, otherFullName, StringComparison.Ordinal);
    }

}

public class Dentist : IDoctor, IPerson, IComparable<Dentist>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public List<Patient> patients {get; set;}
    public long Salary {get; set;}
    public string University {get; set;}
    public string Field {get; set;}

    public Dentist(string firstname, string lastname ,string field, long salary, string university)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.patients = new List<Patient>();
        this.Field = field;
        this.University = university;
        this.Salary = salary;
    }

public static Dentist operator +(Dentist doctor, Patient patient)
    {
        var newDoctor = new Dentist(doctor.Firstname, doctor.Lastname, doctor.Field, doctor.Salary, doctor.University)
        {
            patients = new List<Patient>(doctor.patients)
        };
        if (patient != null && patient.Disease != null)
        {
            if (patient.Disease.Contains("Toothache") || patient.Disease.Contains("Teeth") || patient.Disease.Contains("Dental"))
            {
                newDoctor.patients.Add(patient);
            }
        }
        return newDoctor;
    }

    public static bool operator <(Dentist d1, Dentist d2)
    {
        return d1.Salary < d2.Salary;
    }

    public static bool operator >(Dentist d1, Dentist d2)
    {
        return d1.Salary > d2.Salary;
    }

    public string GraduatedFrom()
    {
        string universityName = University.Split(" ")[0];
        return $"{Firstname} {Lastname} is graduated from {universityName}";
    }

    public string Work()
    {
        return $"This Dentist works on {Field}";
    }
    public int CompareTo(Dentist other)
    {
        if (other == null) return 1;

        double thisRatio = 0;
        if (patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            thisRatio = (double)recoveredCount / patients.Count;
        }

        double otherRatio = 0;
        if (other.patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in other.patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            otherRatio = (double)recoveredCount / other.patients.Count;
        }

        if (thisRatio != otherRatio) return thisRatio.CompareTo(otherRatio);

        string thisFullName = $"{Firstname} {Lastname}";
        string otherFullName = $"{other.Firstname} {other.Lastname}";
        return string.Compare(thisFullName, otherFullName, StringComparison.Ordinal);
    }
}

public class Surgeon : IDoctor, IPerson, IComparable<Surgeon>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public List<Patient> patients {get; set;}
    public long Salary {get; set;}
    public string University {get; set;}
    public string Field {get; set;}

    public Surgeon(string firstname, string lastname,string field ,long salary, string university)
    {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.patients = new List<Patient>();
        this.Field = field;
        this.University = university;
        this.Salary = salary;
    }

    public static Surgeon operator +(Surgeon doctor, Patient patient)
    {
        var newDoctor = new Surgeon(doctor.Firstname, doctor.Lastname, doctor.Field, doctor.Salary, doctor.University)
        {
            patients = new List<Patient>(doctor.patients)
        };
        if (patient != null && patient.Disease != null)
        {
            if (patient.Disease.Contains("Cancer") || patient.Disease.Contains("Appendix") || patient.Disease.Contains("Kidney"))
            {
                newDoctor.patients.Add(patient);
            }
        }
        return newDoctor;
    }

    public static bool operator <(Surgeon d1, Surgeon d2)
    {
        return d1.patients.Count < d2.patients.Count;
    }

    public static bool operator >(Surgeon d1, Surgeon d2)
    {
        return d1.patients.Count > d2.patients.Count;
    }

    public string GraduatedFrom()
    {
        string universityName = University.Split(" ")[0];
        return $"{Firstname} {Lastname} is graduated from {universityName}";
    }

    public string Work()
    {
        return $"This Surgeon works on {Field}";
    }
    public int CompareTo(Surgeon other)
    {
        if (other == null) return 1;

        double thisRatio = 0;
        if (patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            thisRatio = (double)recoveredCount / patients.Count;
        }

        double otherRatio = 0;
        if (other.patients.Count > 0)
        {
            int recoveredCount = 0;
            foreach (Patient p in other.patients)
            {
                if (p.Recovered) recoveredCount++;
            }
            otherRatio = (double)recoveredCount / other.patients.Count;
        }

        if (thisRatio != otherRatio) return thisRatio.CompareTo(otherRatio);

        string thisFullName = $"{Firstname} {Lastname}";
        string otherFullName = $"{other.Firstname} {other.Lastname}";
        return string.Compare(thisFullName, otherFullName, StringComparison.Ordinal);
    }
    
}

public class Patient : IPerson
{
    public string Firstname{get; set;}
    public string Lastname{get; set;}
    public string Disease{get; set;}
    public bool Recovered{get; set;}

    public Patient(string first_name, string last_name, string disease, bool recovered)
    {
        this.Firstname = first_name;
        this.Lastname = last_name;
        this.Disease = disease;
        this.Recovered = recovered;
    }
}

public class Doctors<T> where T : IDoctor, IPerson
{
    public List<T> DoctorList {get; set;}
    
    public Doctors()
    {
        DoctorList = new List<T>();
    }

    public void AddDoctor(T doctor)
    {
        DoctorList.Add(doctor);
    }

    public List<string> SortDoctors()
    {
        var sortedDoctors = DoctorList.OrderBy(d => d).ToList();
        return sortedDoctors.Select(d => $"{d.Firstname} {d.Lastname}").ToList();
    }
    public List<string> ListOfRecoveredPatients()
    {
        List<string> recoveredPatients = new List<string>();

        foreach (var doctor in DoctorList)
        {
            foreach (var patient in doctor.patients)
            {
                if (patient.Recovered)
                {
                    recoveredPatients.Add($"{patient.Firstname} {patient.Lastname}");
                }
            }
        }
        return recoveredPatients;
    }
    
}

public class MyStack<T> : IEnumerable<T>
{
    public int Size { get; set; }
    public List<T> Values;

    public MyStack()
    {
        Values = new List<T>();
        Size = 0;
    }

    public void Push(T item)
    {
        Values.Add(item);
        Size++;
    }

    public T Pop()
    {
        if (Size == 0) throw new InvalidOperationException("Stack is empty");
        T item = Values[Size - 1];
        Values.RemoveAt(Size - 1);
        Size--;
        return item;
    }

    public string Print()
    {
        StringBuilder result = new StringBuilder();
        MyStack<T> temp = new MyStack<T>();

        while (Size > 0)
        {
            T item = Pop();
            result.Append(item + " ");
            temp.Push(item);
        }

        while (temp.Size > 0)
        {
            Push(temp.Pop());
        }

        return result.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = Size - 1; i >= 0; i--)
        {
            yield return Values[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> GetElementsInOrder()
    {
        for (int i = Size - 1; i >= 0; i--)
        {
            yield return Values[i];
        }
    }

    public MyQueue<T> Convert()
    {
        MyQueue<T> stack = new MyQueue<T>();
        foreach (var item in this.GetElementsInOrder())
        {
            stack.Enqueue(item);
        }
        return stack;
    }
    // MyQueue<T> IConvertable<MyQueue<T>>.Convert()
    // {
    //     MyQueue<T> queue = new MyQueue<T>();
    //     foreach (var item in this.GetElementsInOrder())
    //     {
    //         queue.Enqueue(item);
    //     }
    //     return queue;
    // }

    public static MyStack<T> operator +(MyStack<T> stack, object other)
    {
        if (other is MyQueue<T> s) 
        {
            // MyQueue<T> newqueue = new MyQueue<T>();
            // foreach (var item in s)
            // {
            //     newqueue.Enqueue(s.Dequeue());
            // }

            MyStack<T> q2 = s.Convert(); 
            var queueItems = q2.GetElementsInOrder().Reverse();
            foreach (var item in queueItems)
            {
                stack.Push(item);
            }
        }
        if (other is MyStack<T> st) 
        {
            foreach (var item in st)
            {
                stack.Push(item);
            }
        }
        return stack;
    }
}

// public interface IConvertable<T>
// {
//     T Convert();
// }

public class MyQueue<T> : IEnumerable<T>
{
    public int Size { get; set; }
    public List<T> Values;

    public MyQueue()
    {
        Values = new List<T>();
        Size = 0;
    }

    public void Enqueue(T item)
    {
        Values.Add(item);
        Size++;
    }

    public T Dequeue()
    {
        if (Size == 0) throw new InvalidOperationException("Queue is empty");
        T item = Values[0];
        Values.RemoveAt(0);
        Size--;
        return item;
    }

    public string Print()
    {
        StringBuilder result = new StringBuilder();
        MyQueue<T> temp = new MyQueue<T>();

        while (Size > 0)
        {
            T item = Dequeue();
            result.Append(item + " ");
            temp.Enqueue(item);
        }

        while (temp.Size > 0)
        {
            Enqueue(temp.Dequeue());
        }

        return result.ToString().Trim();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Size; i++) 
        {
            yield return Values[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<T> GetElementsInOrder()
    {
        return Values;
    }

    public MyStack<T> Convert()
    {
        MyStack<T> queue = new MyStack<T>();
        foreach (var item in this.GetElementsInOrder())
        {
            queue.Push(item);
        }
        return queue;
    }

    // MyStack<T> IConvertable<MyStack<T>>.Convert()
    // {
    //     MyStack<T> queue = new MyStack<T>();
    //     foreach (var item in this.GetElementsInOrder())
    //     {
    //         queue.Push(item);
    //     }
    //     return queue;    
    // }

    public static MyQueue<T> operator +(MyQueue<T> queue, object other)
    {
        if (other is MyStack<T> s) 
        {
            MyQueue<T> q2 = s.Convert();
            foreach (var item in q2)
            {
                queue.Enqueue(item);
            }
        }
        if (other is MyQueue<T> q)
        {
            foreach (var item in q)
            {
                queue.Enqueue(item);
            }
        }
        return queue;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

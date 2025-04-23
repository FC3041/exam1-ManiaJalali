namespace Exam1;

public class Q8StringLengthComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x == null && y == null) return 0;
        else if (x == null) return -1;
        else if (y == null) return 1;
        else if (x.Length != y.Length) return x.Length.CompareTo(y.Length);
        return string.Compare(x, y, StringComparison.Ordinal);
    }
}

public class Q8ComparableString : IComparer<Q8ComparableString>
{
    public string? input{get;set;}
    public Q8ComparableString(string? _input)
    {
        this.input = _input;
    }
    public int Compare(Q8ComparableString? x, Q8ComparableString? y)
    {
        if (x.input == null) return -1;
        else if (y.input == null) return 1;
        else if (x.input == null && y.input == null) return 0;
        if (x.input.Length != y.input.Length) return x.input.Length.CompareTo(y.input.Length);
        return string.Compare(x.input, y.input, StringComparison.Ordinal);
    }

    public static bool operator <(Q8ComparableString s1, Q8ComparableString s2)
    {
        bool flag = true;
        int a = (string.Compare(s1.input, s2.input, StringComparison.Ordinal));
        if (a > 0) flag = true;
        else if (a < 0) flag = false;
        if (s1.input == null) flag = true;
        else if (s2.input == null) flag = false;
        if (s1.input != null && s2.input != null) return (s1.input.Length < s2.input.Length) || flag;
        return flag;
    }
    public static bool operator >(Q8ComparableString s1, Q8ComparableString s2)
    {
        bool flag = false;
        int a = (string.Compare(s1.input, s2.input, StringComparison.Ordinal));
        if (a > 0) flag = true;
        else if (a < 0) flag = false;
        if (s2.input == null) flag = true;
        else if (s1.input == null) flag = false;
        if (s1.input != null && s2.input != null) return ((s1.input.Length > s2.input.Length) || flag);   
        return flag; 
    }
    public static bool operator ==(Q8ComparableString s1, Q8ComparableString s2)
    {
        bool flag = false;
        int a = (string.Compare(s1.input, s2.input, StringComparison.Ordinal));
        if (a == 0) flag = true;
        else if(s1.input == null && s2.input == null) flag = true;
        if (s1.input != null && s2.input != null) return ((s1.input.Length == s2.input.Length) && flag);
        return flag;
    }
    public static bool operator !=(Q8ComparableString s1, Q8ComparableString s2)
    {
        bool flag = true;
        int a = (string.Compare(s1.input, s2.input, StringComparison.Ordinal));
        if (a == 0) flag = false;
        else if(s1.input == null && s2.input == null) flag = false;
        if (s1.input != null && s2.input != null) return (!(s1.input.Length == s2.input.Length) || flag);
        return flag;
        
    }
}
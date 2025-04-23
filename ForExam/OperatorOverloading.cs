namespace E1
{
    public class MyString
    {
        #region 
        public string name {get; set;}
        public MyString(string s)
        {
            name = s;
        }
        public static implicit operator string(MyString obj)
        {
            return obj.name;
        }
        public static explicit operator MyString(string obj)
        {
            return new MyString(obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name);
        }
        public static bool operator ==(MyString obj, string str)
        {
            return obj.name == str;
        }

        public static bool operator !=(MyString obj, string str)
        {
            return obj.name != str;
        }
        public override bool Equals(object obj)
        {
            if (obj is string str)
            {
                return name == str;
            }
            if (obj is MyString myStr)
            {
                return name == myStr.name;
            }
            return false;
        }

        public static MyString operator ++(MyString s)
        {
            s.name = s.name.ToUpper();
            return s;
        }

        public static MyString operator --(MyString s)
        {
            s.name = s.name.ToLower();
            return s;
        }

        #endregion
    }
}
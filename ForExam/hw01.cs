using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A6
{
    public enum FutureHusbandType : int
    {
        None = 0,
        HasBigNose = 1,
        IsBald = 2,
        IsShort = 4
    }

    public struct TypeOfSize5
    {
        private byte v5;
        private byte v1;
        private byte v2;
        private byte v3;
        private byte v4;
    }

    public struct TypeOfSize22
    {
        private TypeOfSize5 f1;
        private TypeOfSize5 f2;
        private TypeOfSize5 f3;
        private TypeOfSize5 f4;
        private byte v1;
        private byte v2;
    }
    public struct TypeOfSize125
    {
        private TypeOfSize5 a1;
        private TypeOfSize5 a2;
        private TypeOfSize5 a3;
        private TypeOfSize22 h4;
        private TypeOfSize22 h5;
        private TypeOfSize22 h6;
        private TypeOfSize22 h7;
        private TypeOfSize22 h8;
    }
    public struct TypeOfSize1024
    {
        private TypeOfSize125 f1;
        private TypeOfSize125 f2;
        private TypeOfSize125 f3;
        private TypeOfSize125 f4;
        private TypeOfSize125 f5;
        private TypeOfSize125 f6;
        private TypeOfSize125 f7;
        private TypeOfSize125 f8;
        private TypeOfSize22 f9;
        private short f10;

    }

    public struct TypeOfSize8192
    {
        private TypeOfSize1024 f1;
        private TypeOfSize1024 f2;
        private TypeOfSize1024 f3;
        private TypeOfSize1024 f4;
        private TypeOfSize1024 f5;
        private TypeOfSize1024 f6;
        private TypeOfSize1024 f7;
        private TypeOfSize1024 f8;
    }
    public struct TypeOfSize32768
    {
        private TypeOfSize8192 f1;
        private TypeOfSize8192 f2;
        private TypeOfSize8192 f3;
        private TypeOfSize8192 f4;
    }
    
    public struct TypeForMaxStackOfDepth10
    {
        private TypeOfSize32768 f1;
        private TypeOfSize32768 f2;
        private TypeOfSize32768 f3;
        private TypeOfSize8192 f4;
        private TypeOfSize8192 f5;
    }

    public struct TypeForMaxStackOfDepth100 
    {
        private TypeOfSize1024 f1;
        private TypeOfSize1024 f2;
        private TypeOfSize1024 f3;
        private TypeOfSize1024 f0;
        private TypeOfSize1024 f5;
        private TypeOfSize8192 f4;
    }
    public struct TypeForMaxStackOfDepth1000
    {
        private TypeOfSize1024 f1;
        private TypeOfSize125 f2;
        private TypeOfSize125 f3;
        private TypeOfSize125 f4;
    }
    public struct TypeForMaxStackOfDepth3000
    {       
        private TypeOfSize125 f1;
        private TypeOfSize125 f2;
        private TypeOfSize125 f3;
    }

    public class TypeWithMemoryOnHeap
    {
        private byte[] memory;

        public void Allocate()
        {
            memory = new byte[4000000];
        }

        public void DeAllocate()
        {
            memory = null;
        }
    }


    public struct StructOrClass1
    {
        public int X;
    }

    public class StructOrClass2
    {
        public int X;
    }

    public struct StructOrClass3
    {
        public StructOrClass2 X;
    }

    public class Program
    {
        public static int GetObjectType(object o)
        {
            if (o is string)
                return 0;
            if (o is int[])
                return 1;
            if (o is int)
                return 2;
            return 3;
        }
        public static bool IdealHusband(FutureHusbandType fht)
        {
            int value = (int) fht;
    
            if(value == 1) return false;
            else if(value == 2) return false;
            else if(value == 4) return false;
            else if(value == 3) return true;
            else if(value == 6) return true;
            else if(value == 5) return true;
            else return false;
        }
        static void Main(string[] args)
        {
        }
    }
}
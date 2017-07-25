using System;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("0009\n");
        sb.Append("0010\n");
        sb.Append("0015\n");
        sb.Append("0019\n");
        sb.Append("0025\n");
        sb.Append("0027\n");
        sb.Append("0029\n");
        sb.Append("0031\n");
        sb.Append("0034\n");
        sb.Append("0035\n");
        sb.Append("0039\n");

        string r1 = Program.getDataWStartEndPttrn(sb, "0012", "0028");
        string r2 = Program.getDataWStartEndPttrn(sb, "0012", "0030");
        string r3 = Program.getDataWStartEndPttrn(sb, "0010", "0029");
        string r4 = Program.getDataWStartEndPttrn(sb, "0008", "0020");
        string r5 = Program.getDataWStartEndPttrn(sb, "001", "002");

        Console.WriteLine(r1);
        Console.WriteLine("---------");
        Console.WriteLine(r2);
        Console.WriteLine("---------");
        Console.WriteLine(r3);
        Console.WriteLine("---------");
        Console.WriteLine(r4);
        Console.WriteLine("---------");
        Console.WriteLine(r5);

        Console.ReadLine();

    }

    static internal int getStartIdx(string s, string pttr)
    {
        while (s.IndexOf(pttr) == -1)
        {
            // call increment pattern
            pttr = incrementPattern(pttr);
        }

        return s.IndexOf(pttr);

    }

    static internal int getEndIdx(string s, string pttr)
    {
        while (s.LastIndexOf(pttr) == -1)
        {
            // call decrement pattern
            pttr = decrementPattern(pttr);
        }

        return s.LastIndexOf(pttr);
    }


    static internal string incrementPattern(string pttrn)
    {
        // discard zeros
        var numberOfzeros = pttrn.TakeWhile(c => c == '0' ).Count();

        // TODO :: handle cases when no '0's present

        // get the value
        string subS = pttrn.Substring(numberOfzeros);

        // cast to int
        int subI;
        Int32.TryParse(subS, out subI);

        // increment by 1
        subI += 1;

        // add appropriate amount of zeros
        string finalS = subI.ToString().PadLeft(pttrn.Length, '0');

        return finalS;
    }


    static internal string decrementPattern(string pttrn)
    {
        // discard zeros
        var numberOfzeros = pttrn.TakeWhile(c => c == '0').Count();

        // TODO :: handle cases when no '0's present

        // get the value
        string subS = pttrn.Substring(numberOfzeros);

        // cast to int
        int subI;
        Int32.TryParse(subS, out subI);

        // decrement by 1
        subI -= 1;

        // add appropriate amount of zeros
        string finalS = subI.ToString().PadLeft(pttrn.Length, '0');

        return finalS;
    }


    static internal string getDataWStartEndPttrn(StringBuilder data, string strPttr, string endPttr)
    {
        string s = data.ToString();

        int si = getStartIdx(s, strPttr);
        int se = getEndIdx(s, endPttr);
        
        // get the subpattern by the lastIndexOf() it
        // + endPttr.Length to include the pattern itself
        s = s.Substring(si, se - si + endPttr.Length).TrimEnd('\n');

        return s;
    }

}

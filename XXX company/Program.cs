using System.Linq;

namespace XXX_company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input_s1_04.txt");
            var employees = new Dictionary<string,string>();
            var employers = new Dictionary<string,List<string>>();
            string spec_line=reader.ReadLine();
            while (true)
            {
                if (spec_line == "END") { break; }
                string line1 = spec_line;
                string line2 = reader.ReadLine();
                spec_line = reader.ReadLine();
             //   Console.WriteLine(line1);
             //   Console.WriteLine(line2);
                string boss_number; string slave_number;
                if (line1.Length == 4)
                {
                    boss_number= line1;
                    if (!employees.Keys.Contains(boss_number))
                    {
                        employees.Add(boss_number, "Unknown Name");
                    }
                }
                else
                {
                    boss_number = line1.Split(" ")[0];
                    if (!employees.Keys.Contains(boss_number))
                    {
                        employees.Add(boss_number, line1.Split(" ",2)[1].ToLower());
                    }
                    else
                    {
                        if (employees[boss_number] == "Unknown Name") 
                        {
                            employees[boss_number] = line1.Split(" ", 2)[1].ToLower();
                        }
                    }  
                }
                if (line2.Length == 4)
                {
                    slave_number = line2;
                    if (!employees.Keys.Contains(slave_number))
                    {
                        employees.Add(slave_number, "Unknown Name");
                    }
                }
                else
                {
                    slave_number = line2.Split(" ")[0];
                    if (!employees.Keys.Contains(slave_number))
                    {
                        employees.Add(slave_number, line2.Split(" ",2)[1].ToLower());
                    }
                    else
                    {
                        if (employees[slave_number] == "Unknown Name")
                        {
                            employees[slave_number] = line2.Split(" ", 2)[1].ToLower();
                        }
                    }
                }
                if (employers.Keys.Contains(boss_number))
                {
                    employers[boss_number].Add(slave_number);
                }
                else
                {
                    employers.Add(boss_number, new List<string>());
                    employers[boss_number].Add(slave_number);
                }
            }
     //       Console.WriteLine(employees.Count);
     //       foreach(var a in employees)
      //      {
       //         Console.WriteLine("{0}  {1}",a.Key,a.Value);
        //    }
            string guy=reader.ReadLine().ToLower();

            if (employees.Values.Contains(guy))
            { 
                foreach(var a in employees) 
                {
                    if (a.Value == guy)
                    {
     //                   Console.WriteLine(a.Key);
                        guy=a.Key;
                        break;
                    }
                }
            }


            string dude=guy;
            if (employers[dude].Count==0) 
            {
                Console.WriteLine("None");
                Environment.Exit(0);
            }
            Queue<string> lox_que_pro = new Queue<string>();
            for (int i = 0; i < employers[dude].Count;i++) 
            {
                lox_que_pro.Enqueue(employers[dude][i]);
            }
         
            List<string> lis_list=new List<string>();
            while (lox_que_pro.Count!=0) 
            {
                lis_list.Add(lox_que_pro.Peek());
                if (employers.Keys.Contains(lox_que_pro.Peek()))
                {
                    for (int i = 0; i < employers[lox_que_pro.Peek()].Count; i++)
                    {
                        lox_que_pro.Enqueue(employers[lox_que_pro.Peek()][i]);
                    }
                }
                lox_que_pro.Dequeue();
            }
            lis_list.Sort();
            for(int i = 0; i < lis_list.Count; i++)
            {
                Console.WriteLine("{0} {1}",lis_list[i], employees[lis_list[i]]);
            }

        }
    }
}
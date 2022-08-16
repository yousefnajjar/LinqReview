using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinQ
{
    public partial class join : Form
    {
        public join()
        {
            InitializeComponent();
        }
        Employee[] employees =
            {
                new Employee() {Number=1,Name="Yousef",City="Jordan",Salary=8000,Empchildren=new string[]{"Najd","Jad"} },
                new Employee() {Number=2,Name="Lana",City="USA",Salary=3000 ,Empchildren=new string[]{"Dana","Sally","Yaman"}},
                new Employee() {Number=3,Name="Ahmad",City="USA",Salary=2500 , Empchildren = new string[] { "Wafaa" }},
                new Employee() {Number=4,Name="Nooran",City="Dubai",Salary=4000, Empchildren = new string[] { "Jomana", "Jad" }},
                new Employee() {Number=5,Name="Sara",City="Serya",Salary=1500, Empchildren = new string[] { "Abd Alah" }},
                new Employee() {Number=6,Name="Omar",City="Jordan",Salary=6700},
                new Employee() {Number=7,Name="Khaled",City="UAE",Salary=12000},
                new Employee() {Number=8,Name="Najjd",City="UAE",Salary=5500, Empchildren = new string[] { "Samar", "Salawa","Salama" }}
            };
        Employee[] employees2 =
          {
                new Employee() {Number=1,Name="jack",City="Jordan",Salary=8000,Empchildren=new string[]{"Najd"} },
                new Employee() {Number=2,Name="john",City="USA",Salary=3000 ,Empchildren=new string[]{"Dana","Sally","Yaman"}},
                new Employee() {Number=3,Name="Romio",City="USA",Salary=2500 },
                new Employee() {Number=4,Name="Santos",City="Dubai",Salary=4000},
                new Employee() {Number=5,Name="Loren",City="Serya",Salary=1500, Empchildren = new string[] { "Abd Alah" }},
                new Employee() {Number=6,Name="Sam",City="Jordan",Salary=6700},
                new Employee() {Number=7,Name="Enrique",City="UAE",Salary=12000},
                new Employee() {Number=8,Name="Michell",City="UAE",Salary=5500, Empchildren = new string[] { "Salama" }}
            };
        Position[] positions =
        {
            new Position() {Id = 1 , Name = "Administrative Assistant"},
            new Position() {Id = 2 , Name = "Consultant"},
            new Position() {Id = 2 , Name = "Technical Lead"},
            new Position() {Id = 3 , Name = "CEO"},
            new Position() {Id = 4 , Name = "Accountent"},
            new Position() {Id = 4 , Name = "Supervisor"},
            new Position() {Id = 5 , Name = "PM"},
            new Position() {Id = 5 , Name = "Project Team"},
            new Position() {Id = 5 , Name = "Teaster"}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach(Employee emp in employees)
            //{
            //    LBX.Items.Add(emp.Number +" "+ emp.Name +" "+ emp.City +" "+ emp.Salary);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //var all = from emp in employees
            //          select emp;

            //IEnumerable<Employee> all = from emps in employees
            //                            select emps;


            var all = from emps in employees
                      select emps;

            foreach (var emp in all)
            {
                LBX.Items.Add(emp.Number + " " + emp.Name + " " + emp.City + " " + emp.Salary);
            }


            //للتحديد
            //var all = from emp in employees
            //          select emp.Number + " " +  emp.Name;

            //foreach(var x in all)
            //{
            //    LBX.Items.Add(x);
            //}
        }

        private void Where_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //var inSameCity = from emp in employees
            //                 where emp.City == "UAE"
            //                 select emp;

            //foreach(var city in inSameCity)
            //{
            //    LBX.Items.Add(city.Name + " - " + city.City);
            //}
            /////////////////////////////////////////////////////////////////////////////
            //var range = "Salary From 2000 $ To 6000 $";

            //LBX.Items.Add(range);
            //LBX.Items.Add("----------------------------------------");


            var rangSalary = from emps in employees
                             where emps.Salary > 2000 && emps.Salary < 6000 && emps.City == "USA"
                             select emps;

            foreach (var sel in rangSalary)
            {

                LBX.Items.Add(sel.Name + "  -  " + sel.City);

            }
            //////////////////////////////////////////////////////////////////////////////


            //LBX.Items.Add("----------------------------------------");


            //var rangSalary = from emps in employees
            //                 where emps.Name.Contains("a") && emps.Name.StartsWith("Y")
            //                 select emps;

            //foreach (var sel in rangSalary)
            //{

            //    LBX.Items.Add(sel.Name + "  -  " + sel.City);

            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear(); // Remove duplicates in comboBox
            //OrderBy from A to Z
            var AscNames = from emps in employees
                           orderby emps.Salary ascending //descending
                           select emps;
            foreach(var Asc in AscNames)
            {
                LBX.Items.Add(Asc.Name + " " + Asc.Salary);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            var groupByCity = from emps in employees
                              group emps by emps.City;

            foreach (var grp in groupByCity)
            {
                LBX.Items.Add("City Name : " + grp.Key);
                //Key لتحديد المسطلح الراسي المراد الترتيب على اساسه

                foreach (var grp2 in grp)
                {
                    LBX.Items.Add("         " + grp2.Name + " " + grp2.Salary);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            var allEmpSons = from emps in employees
                             from sons in emps.Empchildren
                             select sons;
            foreach(var emp in allEmpSons)
            {
               
                  LBX.Items.Add(emp);
                
                 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            var empJoinRole = from emps in employees
                              join pos in positions
                              on emps.Number equals pos.Id
                              select pos;
            foreach(var emp in empJoinRole)
            {
                LBX.Items.Add(emp.Id + " " + emp.Name);
            }
        }

        private void btnjoin2_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            var joins = from emps in employees
                        join pos in positions
                        on emps.Number equals pos.Id into emppos
                        select new { emps , emppos };
            foreach(var emp in joins)
            {
                if (emp.emppos.Count() > 0)
                {
                    LBX.Items.Add(emp.emps.Name);
                }
                foreach(var y in emp.emppos)
                {
                    if (y.Name != null)
                    {
                        LBX.Items.Add("     "+y.Name);
                        
                    }
                }
                if(emp.emppos.Count() == 0)
                {
                    
                    LBX.Items.Add("Employee Without Position  :  "+ emp.emps.Name);
                   
                }

            }
                       
        }

        private void btnDistinct_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            var sal = from emp in employees
                      orderby emp.Salary ascending 
                      select emp;
            //Note : var sals = sal.Distinct(); Use for no rebeat
            //Sum
            var sumS = (from s in employees 
                        select s.Salary).Sum();
            //Max
            var MaxS = (from m in employees
                        select m.Salary).Max();
            //Min
            var MinS = (from min in employees
                        select min.Salary).Min();
            //Avg
            var AvgS = (from Avg in employees
                        select Avg.Salary).Average();
            foreach (var emp in sal)
            {
                LBX.Items.Add(emp.Salary);
            }
            lbc.Text = LBX.Items.Count.ToString();

            sumSalary.Text = sumS.ToString() + " $";
            avg.Text = AvgS.ToString() + " $";
            max.Text = MaxS.ToString() + " $";
            min.Text = MinS.ToString() + " $";
        }

        private void dtb_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            DataTable data = new DataTable("DT");
            data.Columns.Add("Number",typeof(int));
            data.Columns.Add("Name");
            data.Columns.Add("City");
            data.Columns.Add("Salary", typeof(int));

            data.Rows.Add(1, "Yousef", "Amman", 1000);
            data.Rows.Add(2, "Ahmad", "Irbid", 900);
            data.Rows.Add(3, "Sammy", "Zarqa", 400);
            data.Rows.Add(4, "Jomana", "Irbid", 300);
            data.Rows.Add(5, "Lara", "Amman", 1200);

            DataSet ds = new DataSet("Com");
            ds.Tables.Add(data);

            var result = from emp in ds.Tables[0].AsEnumerable()
                        // where emp[1].ToString().Contains("a")
                        // orderby emp[3] ascending
                             select new
                         {
                             Id = emp[0],
                             Name = emp[1],
                             City = emp[2],
                             Salary = emp[3]
                         };
            foreach(var x in result)
            {
                LBX.Items.Add(x.Id +" "+ x.Name + " " +x.City + " " +x.Salary);
            }

        }
        /////////////Lambda Expression
        ///
        delegate void Hello();
        delegate void YourName(string name);
        delegate int sum(int x,int y);
        private void btnLambda_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //Hello hello = () => MessageBox.Show("Hello");
            //hello();

            //YourName youname = (name) =>
            //{
            //    MessageBox.Show("Hello " + name);
            //}; 
            //youname("Yousef");

            sum s = (x, y) => (x + y);
            
            int d = s(3, 7);
            MessageBox.Show("Sum :"+ d.ToString());

        }

        private void btnQueryMethod_GETALLDATA_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //var result = employees.Select(emp => emp);
            //foreach(var x in result)
            //{
            //    LBX.Items.Add(x.Name   + "          - " + x.City);
            //}


            //select just Name
            var result2 = employees.Select(emp => emp.Name+" "+emp.City);
            foreach (var x in result2)
            {
                LBX.Items.Add(x);
            }

        }

        private void btn_selctmeny_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //var r = employees.Select(emp => emp.Empchildren);
            ////مشينا في اليكس على كل شي داخل الامبلويي لاكن عشان نمشي على
            ////ليست داخل الاست اللي منتعامل معها لازمنا كمان لووب
            //foreach (var x in r) 
            //{ 
            // foreach(var y in x)
            //    {
            //        LBX.Items.Add(y);
            //    }
            //}

            ////////////////////////////////////Select Many
            ///السيليكت ماني بتغنينا عن انه نستخدم النيستيد لوم لاكثر من مصفوفه
            LBX.Items.Add(" -- Employee Childrens --");
            var result = employees.SelectMany(emp => emp.Empchildren);

            foreach(var x in result)
            {
                LBX.Items.Add(x);
            }
        }

        private void btn_wheremethod_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //Flexibility with using Method Syntax in LINQ // ex/ Where().Select().Orderby()
            //var result2 = employees.OrderBy(emp => emp.Salary).Select(emp => emp).Where(emp => emp.Salary < 5000);
            //OrderByDescending 
            //var result = employees.Where(emp => emp.Salary < 5000).OrderByDescending(emp => emp.Salary).Select(emp => emp);
            var result = employees.Where(emp => emp.Salary < 5000).OrderBy(emp => emp.Salary).Select(emp => emp);
            foreach( var x in result)
            {
                LBX.Items.Add(x.Name);
            }
        }

        private void btn_groupby_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            var result = employees.OrderBy(emp => emp.City).GroupBy(emp => emp.City);
            foreach(var r in result)
            {
                LBX.Items.Add(r.Key);
                foreach(var x in r)
                {
                    LBX.Items.Add("         " +x.Name);
                }
            }
        }

        private void btn_joinMethod_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            var result = employees.Join( positions, emp => emp.Number, po => po.Id, (emp, po) => po);

            foreach( var x in result)
            {
                LBX.Items.Add(x.Name);
            }
        }

        private void join2_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            //return two table resource from join
            var result = employees.Join(
                positions, 
                emp => emp.Number, 
                po => po.Id, 
                (emp, po) => new {emp , po}
                );

            foreach (var x in result)
            {
                LBX.Items.Add(x.emp.Name + "      "+ x.po.Name );
            }
        }

        private void QueryandMethod_btn_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            var result = (from emp in employees
                          select emp).Where(emp => emp.Salary > 2000 && emp.Salary < 10000)
                          .OrderByDescending(emp => emp.Salary);
            foreach( var x in result)
            {
                LBX.Items.Add(x.Name);
            }

        }

        private void btn_union_Click(object sender, EventArgs e)
        {//اتحاد
            LBX.Items.Clear();
            var r = (from emp in employees select emp).Union
                (from emp2 in employees2 select emp2);
            //or
            var r2 = employees.Union(employees2);

            foreach ( var x in r2)
            {
                LBX.Items.Add(x.Name);
            }

        }

        private void btn_arrayUnion_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();

            string[] emp = { "ahmad", "kaled", "sama" ,"sona"};
            string[] emp2 = { "ahmad", "sona", "lona" ,"ahmad"};

            var r = emp.Union(emp2);
            foreach (var item in r)
            {
                LBX.Items.Add(item);
            }
            
        }

        private void intersect_btn_Click(object sender, EventArgs e)
        {
            LBX.Items.Clear();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            int[] ints1 = { 7, 7, 3, 4, 9, 10 };

            var r = ints.Intersect(ints1);
            foreach(var item in r)
            {
                LBX.Items.Add(item);
            }
        }

        private void btn_except_Click(object sender, EventArgs e)
        {
           //الموجودات في الاول و غير موجودات في الثاني
            LBX.Items.Clear();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            int[] ints1 = { 7, 7, 3, 4, 9, 10 };

            var r = ints.Except(ints1);
            foreach (var item in r)
            {
                LBX.Items.Add(item);
            }
        }

        private void btn_datatable_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable("DT");
            data.Columns.Add("Number", typeof(int));
            data.Columns.Add("Name");
            data.Columns.Add("City");
            data.Columns.Add("Salary", typeof(int));

            data.Rows.Add(1, "Yousef", "Amman", 1000);
            data.Rows.Add(2, "Ahmad", "Irbid", 900);
            data.Rows.Add(3, "Sammy", "Zarqa", 400);
            data.Rows.Add(4, "Jomana", "Irbid", 300);
            data.Rows.Add(5, "Lara", "Amman", 1200);

            var r = from emp in data.AsEnumerable()
                    select emp;

           DataTable newTable = r.CopyToDataTable();

           dataGridView1.DataSource = newTable;
        }
    }

}

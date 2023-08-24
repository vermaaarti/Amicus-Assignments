using assig_2.Models;

namespace assig_2.Services;

    public static class EmployDetail
    {

        static List<Employ> Employs { get; }
    static int nextId = 4;
    static EmployDetail()
        {
            Employs = new List<Employ>
            { 
             new Employ { Id = 1, Firstname= "john", Lastname="deck", Age=30, Departmentid=12,
                Basicsalary=30000, Operationtype="abcd" },
            new Employ { Id = 2, Firstname= "johny", Lastname="deck", Age=30, Departmentid=10,
                Basicsalary=40000, Operationtype="abcd" },
            new Employ { Id = 3, Firstname= "johnana", Lastname="deck", Age=30, Departmentid=15,
                Basicsalary=50000, Operationtype="abcd" }
            };
        }


        public static List<Employ> GetAll() => Employs;

        public static Employ? Get(int id) => Employs.FirstOrDefault(p => p.Id == id);

        public static void Add(Employ employ)
        {
            employ.Id = nextId++;
            Employs.Add(employ);
        }

        public static void Delete(int id)
        {
            var employ = Get(id);
            if (employ is null)
                return;

            Employs.Remove(employ);
        }

        public static void Update(Employ employ)
        {
            var index = Employs.FindIndex(p => p.Id == employ.Id);
            if (index == -1)
                return;

            Employs[index] = employ;
        }



        // }
    }



using EMS.Core.Models;
using EMS.Infrastructure.Business.Services;
using EMS.Infrastructure.Data;

namespace EMS
{
    class Program
    {
        private static EMSRepository _repository = new EMSRepository();
        private static Employee _currenUser = new Employee("none", "none", Role.Employee);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Приветствую вас в приложении EMS" +
                    "\nДля входа введите логин и пароль");

                Console.Write("Поле для ввода логина ");
                var loginUser = Console.ReadLine();

                Console.Write("Поле для ввода пароля ");
                var passwordUser = Console.ReadLine();

                var user = _repository.GetEmplyee(loginUser, passwordUser);

                if (user != null)
                {
                    _currenUser = new Employee(loginUser, passwordUser, user.RoleEmployee);
                    _currenUser.Id = user.Id;
                    if (_currenUser.RoleEmployee == Role.Admin)
                    {
                        MenuAdmin();
                    }
                    else
                    {
                        MenuEmployee();
                    }
                }
                else
                {
                    Console.WriteLine("Введен неверный пароль или логин");
                }
            }
            
        }
        private static void MenuAdmin()
        {
            Console.WriteLine("Меню Admin");
            var adminServices = new AdminServices();
            while (true)
            {
                Console.WriteLine("1) Добавления нового сотрудника\n" +
                                  "2) Создать задачу и назначить на сотрудника");

                var choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Console.Write("Поле для ввода логина нового пользователя");
                        var login = Console.ReadLine();

                        Console.Write("Поле для ввода пароля нового пользователя");
                        var password = Console.ReadLine();

                        Console.WriteLine("Введите роль сотрудника\n1)Admin\n2)Employee");
                        Role role;
                        while (true)
                        {
                            if (int.TryParse(Console.ReadLine(), out int roleInput) &&
                                Enum.IsDefined(typeof(Role), roleInput -1))
                            {
                                role = (Role)roleInput -1;
                                var user = _repository.GetEmplyee(login, password);
                                if(user!=null)
                                {
                                    Console.WriteLine("Такой пользователь уже существует");
                                }
                                else
                                {
                                    adminServices.NewEmployee(login, password, role);
                                    Console.WriteLine("Создан новый пользователь");
                                }
                                break;
                            }
                            Console.WriteLine("Ошибка! Введите 1 или 2:");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите текст задачи ");
                        var title = Console.ReadLine();

                        Console.WriteLine("Введите описание задачи ");
                        var desc = Console.ReadLine();

                        var listEmployee = adminServices.GetAllEmployee();

                        foreach (var item in listEmployee)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name}");
                        }

                        Console.WriteLine("Введите номер сотрудника на которого назначаете задачу");
                        var id = int.Parse(Console.ReadLine());
                        adminServices.CreateNewNotes(title, desc, id);

                        break;

                }
            }
        }

        private static void MenuEmployee()
        {
            var employeeServices = new EmployeeServices();
            while (true)
            {
                Console.WriteLine(_currenUser.Id);
                Console.WriteLine("1) Посмотреть свои задачи\n" +
                                  "2) Изменить статус задачи");

                var choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        ViewNotes(employeeServices);
                        break;

                    case 2:
                        ViewNotes(employeeServices);
                        Console.WriteLine("Введите номер задачи которую вы хотите изменить");
                        var idNote = int.Parse(Console.ReadLine());

                        Console.WriteLine("1)IsDone\n2)InProgress\n3)Done");
                        if (int.TryParse(Console.ReadLine(), out var progressInput))
                        {
                            Progress progress = (Progress)progressInput - 1;
                            Console.WriteLine(progress);
                            employeeServices.ChangeStatusProgress(idNote, progress);
                        }
                        else
                        {
                            Console.WriteLine("Неправильный введенный номер");
                        }
                       
                        break;
                }
            }
        }

        private static void ViewNotes(EmployeeServices employeeServices)
        {
            var listNote = employeeServices.ViewEmployeeNotes(_currenUser.Id);
            foreach (var item in listNote)
            {
                Console.WriteLine($"{item.Id}-{item.Title} - {item.Description} - {item.Progress}");
            }
        }
    }
}
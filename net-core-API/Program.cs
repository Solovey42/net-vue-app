using API;
using API;
using API.Domain.Models;
static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var _applicationContext = services.GetRequiredService<ApplicationContext>();
    if (!_applicationContext.Departments.Any())
    {
        _applicationContext.Departments.Add(new Department { Name = "����� ������" });
        _applicationContext.Departments.Add(new Department { Name = "IT �����" });
        _applicationContext.Departments.Add(new Department { Name = "����� ������" });
        _applicationContext.SaveChanges();
    }

    if (!_applicationContext.Employees.Any())
    {
        _applicationContext.Employees.AddRange(
            new Employee()
            {
                DepartmentId = 1,
                Name = "����",
                Surname = "������",
                Patronymic = "��������",
                Birthday = new DateTime(1990, 10, 8),
                DateOfEmployment = new DateTime(2018, 7, 22),
                Salary = 80000
            },
            new Employee()
            {
                DepartmentId = 2,
                Name = "������",
                Surname = "�������",
                Patronymic = "���������",
                Birthday = new DateTime(1997, 12, 9),
                DateOfEmployment = new DateTime(2021, 6, 14),
                Salary = 70000
            },
            new Employee()
            {
                DepartmentId = 2,
                Name = "�����",
                Surname = "�������",
                Patronymic = "���������",
                Birthday = new DateTime(1987, 1, 3),
                DateOfEmployment = new DateTime(2017, 12, 30),
                Salary = 70000
            }
        );
        _applicationContext.SaveChanges();
    }
}
host.Run();
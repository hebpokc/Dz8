using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Manager. Программа создает проекты, по каждому проекту создаются задачи.");
            Worker worker1 = new Worker("Александр");
            Worker worker2 = new Worker("Анастасия");
            Worker worker3 = new Worker("Антон");
            Worker worker4 = new Worker("Виктория");
            Worker worker5 = new Worker("Владимир");
            Worker worker6 = new Worker("Дарья");
            Worker worker7 = new Worker("Егор");
            Worker worker8 = new Worker("Екатерина");
            Worker worker9 = new Worker("Константин");
            Worker worker10 = new Worker("Маргарита");
            Worker customer = new Worker("Михаил");

            Console.WriteLine($"\nРабочие: \n{worker1.Name}\n{worker2.Name}\n{worker3.Name}\n{worker4.Name}\n{worker5.Name}\n{worker6.Name}\n{worker7.Name}" +
                $"\n{worker8.Name}\n{worker9.Name}\n{worker10.Name}");

            Console.WriteLine("\nПроект - создание сайта");
            Project website = new Project("Разработать сайт для компании", new DateTime(2024, 03, 15), customer);
            website.AssignTeamLead(worker1);
            Console.WriteLine($"\nОписание проекта: {website.ProjectDesription}\nСроки выполнения: {website.Deadline}\nЗаказчик: {website.Customer.Name}" +
                $"\nТимлид: {website.TeamLead.Name}\nСтатус: {website.Status}");

            customer.CreateTask("Определение целей и задач сайта", new DateTime(2023, 11, 12));
            customer.CreateTask("Выбор доменного имени и хостинга", new DateTime(2023, 11, 20));
            customer.CreateTask("Разработка дизайна и структуры сайта", new DateTime(2023, 11, 30));
            customer.CreateTask("Написание и оптимизация кода на языке программирования", new DateTime(2023, 12, 07));
            customer.CreateTask("Интеграция с системами управления контентом", new DateTime(2023, 12, 20));
            customer.CreateTask("Тестирование и отладка сайта", new DateTime(2024, 01, 02));
            customer.CreateTask("Запуск сайта и его продвижение", new DateTime(2024, 01, 23));
            customer.CreateTask("Поддержка и развитие сайта", new DateTime(2024, 03,01));
            List<Task> tasks = website.Tasks;

            Console.WriteLine("\nЗадачи: ");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Описание: {task.TaskDescription}\nДедлайн: {task.Deadline}\nЗаказчик: {task.Initiator.Name}\nСтатус: {task.Status}");
                Console.WriteLine();
            }

            customer.AssignTask(tasks[1], worker2);
            customer.AssignTask(tasks[1], worker3);
            customer.AssignTask(tasks[2], worker4);
            customer.AssignTask(tasks[3], worker5);
            customer.AssignTask(tasks[4], worker6);
            customer.AssignTask(tasks[5], worker7);
            customer.AssignTask(tasks[6], worker8);
            customer.AssignTask(tasks[7], worker9);
            customer.AssignTask(tasks[8], worker10);

            Console.WriteLine("\nРаботники берут/переопределяют/оклоняют задачи");
            worker2.TakeTask();
            worker3.DelegateTask(worker4);
            worker4.TakeTask();
            worker5.DelegateTask(worker7);
            worker6.TakeTask();
            worker7.TakeTask();
            worker8.TakeTask();
            worker9.AbandonTask();
            worker10.AbandonTask();

            customer.DeleteTask(tasks[5]);

            foreach (var task in tasks)
            {
                Console.WriteLine($"Описание: {task.TaskDescription}\nДедлайн: {task.Deadline}\nЗаказчик: {task.Initiator}\nСтатус: {task.Status}");
                Console.WriteLine();
            }
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

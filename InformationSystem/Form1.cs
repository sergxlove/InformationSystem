using InformationSystem.Application.Services;
using InformationSystem.Core.Abstractions.RepositoryAbstractions;
using InformationSystem.Core.Abstractions.ServiceAbstractions;
using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.Core.Models;
using InformationSystem.DataAccess.Sqlite;
using InformationSystem.DataAccess.Sqlite.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace InformationSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddDbContext<InformationSystemDbContext>();
            _serviceCollection.AddScoped<IGroupsRepository, GroupsRepository>();
            _serviceCollection.AddScoped<IResultSessionsRepository, ResultSessionsRepository>();
            _serviceCollection.AddScoped<IStudentsRepository, StudentsRepository>();
            _serviceCollection.AddScoped<ISubjectsRepository, SubjectsRepository>();
            _serviceCollection.AddScoped<ITeachersRepository, TeachersRepository>();
            _serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            _serviceCollection.AddScoped<IGroupsService, GroupsService>();
            _serviceCollection.AddScoped<IResultSessionService, ResultSessionService>();
            _serviceCollection.AddScoped<IStudentsService, StudentsService>();
            _serviceCollection.AddScoped<ISubjectsService, SubjectsService>();
            _serviceCollection.AddScoped<ITeachersService, TeachersService>();
            _serviceCollection.AddScoped<IUsersService, UsersService>();
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }

        private ServiceCollection _serviceCollection;
        private ServiceProvider _serviceProvider;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var usersService = _serviceProvider.GetService<IUsersService>();
            string login = textBox1.Text;
            string password = textBox2.Text;
            var users = await usersService!.CheckLoginPasswordUserAsync(login, password);
            if (users is not null)
            {
                if (users.Role == "master")
                {
                    panel2.Size = new Size(1050, 577);
                }
                else if (users.Role == "worker")
                {
                    panel3.Size = new Size(1050, 577);
                }
                else if (users.Role == "study")
                {
                    panel4.Size = new Size(1050, 577);
                }
            }
            else
            {
                label4.Text = "ошибка входа";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Size = new Size(1050, 0);
            panel1.Size = new Size(1050, 577);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel3.Size = new Size(1050, 0);
            panel1.Size = new Size(1050, 577);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel2.Size = new Size(1050, 0);
            panel1.Size = new Size(1050, 577);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            var studentService = _serviceProvider.GetService<IStudentsService>();
            var student = await studentService!.GetStudentsByNameAsync(name);
            if (student is not null)
            {
                string infoStudent = $"id: {student.Id} \r\nФИО: {student.FirstName} {student.SecondName} " +
                    $"{student.LastName} \r\nEmail: {student.Email} \r\nДата рождения: {student.DateOfBirth}" +
                    $"\r\nId группы: {student.IdGroup}\r\n";
                textBox3.Text = infoStudent;
            }
            else
            {
                label9.Text = "Информация о студенте не найдена";
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var groupService = _serviceProvider.GetService<IGroupsService>();
            var groups = await groupService!.GetAllGroupAsync();
            StringBuilder text = new();
            foreach (var group in groups)
            {
                text.Append($"id: {group.Id} \r\nИмя: {group.Name} \r\nСпециализация: {group.Specialization}\r\n\r\n");
            }
            textBox41.Text = text.ToString();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string name = textBox5.Text;
            var groupService = _serviceProvider.GetService<IGroupsService>();
            var group = await groupService!.GetGroupByNameAsync(name);
            if (group is not null)
            {
                textBox41.Text = $"id: {group.Id} \r\nИмя: {group.Name} \r\nСпециализация: {group.Specialization}\r\n";
            }
            else
            {
                label10.Text = "Информация о группе не найдена";
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            string name = textBox7.Text;
            var teacherService = _serviceProvider.GetService<ITeachersService>();
            var teacher = await teacherService!.GetTeachersByNameAsync(name);
            if (teacher is not null)
            {
                textBox40.Text = $"id: {teacher.Id} \r\nФИО: {teacher.FirstName} {teacher.SecondName} " +
                $"{teacher.LastName} \r\nEmail: {teacher.Email} \r\nДата рождения: {teacher.DateOfBirth}" +
                    $"\r\nКафедра: {teacher.Departament}\r\n";
            }
            else
            {
                label12.Text = "Информация о преподавателе не найдена";
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            string name = textBox9.Text;
            var subjectService = _serviceProvider.GetService<ISubjectsService>();
            var subject = await subjectService!.GetSubjectsByNameAsync(name);
            if (subject is not null)
            {
                textBox10.Text = $"id: {subject.Id} \r\nНазвание: {subject.Name} \r\nid преподавателя: " +
                    $"{subject.IdTeacher} \r\nОписание: {subject.Description}";
            }
            else
            {
                label14.Text = "Информация о предмете не найдена";
            }
        }

        private async void button24_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 1;
                string login = textBox33.Text;
                string password = textBox35.Text;
                string role = comboBox1.Text;
                var userService = _serviceProvider.GetService<IUsersService>();
                await userService!.AddUsersAsync(new Users(id, login, password, role));
                label43.Text = "Пользователь успешно добавлен";
            }
            catch (Exception ex)
            {
                label43.Text = ex.Message;
            }

        }

        private async void button25_Click(object sender, EventArgs e)
        {
            string login = textBox33.Text;
            string password = textBox35.Text;
            var userService = _serviceProvider.GetService<IUsersService>();
            await userService!.DeleteUserAsync(login, password);
            label43.Text = "Пользователь успешно удален";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            label52.Text = "предмет добавлен";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            label52.Text = "предмет обновлен";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            label52.Text = "предмет удален";
        }
    }
}

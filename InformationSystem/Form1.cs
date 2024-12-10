using InformationSystem.Application.Services;
using InformationSystem.Core.Abstractions.RepositoryAbstractions;
using InformationSystem.Core.Abstractions.ServiceAbstractions;
using InformationSystem.Core.Abstructions.RepositoryAbstructions;
using InformationSystem.DataAccess.Sqlite;
using InformationSystem.DataAccess.Sqlite.Repositories;
using Microsoft.Extensions.DependencyInjection;

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
    }
}

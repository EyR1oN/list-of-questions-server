using Microsoft.EntityFrameworkCore;

namespace LoQ.DAL.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Questionnaire> Questionnaire { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questionnaire>().HasData(
                new Questionnaire
                {
                    Id = 1,
                    Title = "Questionnaire 1",
                    Description = "This is questionnaire 1"
                },
                new Questionnaire
                {
                    Id = 2,
                    Title = "Questionnaire 2",
                    Description = "This is questionnaire 2"
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Name = "Question 1",
                    Text = "Question 1?",
                    QuestionnaireId = 1
                },
                new Question
                {
                    Id = 2,
                    Name = "Question 2",
                    Text = "Question 2?",
                    QuestionnaireId = 1
                },
                new Question
                {
                    Id = 3,
                    Name = "Question 3",
                    Text = "Question 3?",
                    QuestionnaireId = 1
                },
                new Question
                {
                    Id = 4,
                    Name = "Question 4",
                    Text = "Question 4?",
                    QuestionnaireId = 1
                }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    Name = "Answer 1",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 2,
                    Name = "Answer 2",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 3,
                    Name = "Answer 3",
                    IsCorrect = false,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 4,
                    Name = "Answer 1",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 5,
                    Name = "Answer 2",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 6,
                    Name = "Answer 3",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 7,
                    Name = "Answer 1",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 8,
                    Name = "Answer 2",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 9,
                    Name = "Answer 3",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 10,
                    Name = "Answer 1",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 11,
                    Name = "Answer 2",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 12,
                    Name = "Answer 3",
                    IsCorrect = false,
                    QuestionId = 4
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Username1",
                    Password = "Password1",
                    Email = "Email1",
                    Role = "Administrator"
                }
            );
        }
    }
}

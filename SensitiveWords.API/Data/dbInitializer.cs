using SensitiveWords.API.Models;

namespace SensitiveWords.API.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.SensitiveWords.Any()) return;

            var words = new List<SensitiveWord>
            {
                new SensitiveWord { Word = "SELECT" },
                new SensitiveWord { Word = "DROP" },
                new SensitiveWord { Word = "CREATE" },
                new SensitiveWord { Word = "UPDATE" },
                new SensitiveWord { Word = "DELETE" },
                new SensitiveWord { Word = "INSERT" },
            };

            context.SensitiveWords.AddRange(words);
            context.SaveChanges();
        }
    }
}


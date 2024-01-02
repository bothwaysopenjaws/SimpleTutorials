using System.Reflection;
using System.Text.Json;

namespace SimpleTutorials.Api.MinimalApi.Model
{
    /// <summary>
    /// Enregistrement d'un article
    /// </summary>
    public record Article
    {
        /// <summary>
        /// Identifiant
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="identifier">Identifiant</param>
        /// <param name="name">Nom</param>
        public Article(int identifier, string name)
        {
            Identifier = identifier;
            Name = name;

        }

        public static async ValueTask<Article> BindAsync(HttpContext context, ParameterInfo parameterInfo)
        {
            using StreamReader? stream = new StreamReader(context.Request.Body);
            Task<string>? body = stream.ReadToEndAsync();

            JsonSerializer.Deserialize<Article>(body.Result);
            Article proxy = JsonSerializer.Deserialize<Article>(body.Result);

            return proxy;
        }
    }
}
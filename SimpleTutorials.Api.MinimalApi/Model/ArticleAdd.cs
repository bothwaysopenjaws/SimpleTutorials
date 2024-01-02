using System.Reflection;

namespace SimpleTutorials.Api.MinimalApi.Model
{
    /// <summary>
    /// Enregistrement d'un article
    /// </summary>
    public record ArticleAdd
    {

        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Constructeur par défaut pour le proxy d'ajout
        /// </summary>
        /// <param name="identifier">Identifiant</param>
        /// <param name="name">Nom</param>
        public ArticleAdd(string name)
        {
            Name = name;

        }


        public static async ValueTask<ArticleAdd> BindAsync(HttpContext context, ParameterInfo parameterInfo)
        {
            using StreamReader? stream = new StreamReader(context.Request.Body);
            Task<string>? body = stream.ReadToEndAsync();

            ArticleAdd proxy = new(body.Result);



            return proxy;
        }
    }
}
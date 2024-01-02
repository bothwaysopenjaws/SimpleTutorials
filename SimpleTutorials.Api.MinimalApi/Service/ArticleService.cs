
using SimpleTutorials.Api.MinimalApi.Model;

namespace SimpleTutorials.Api.MinimalApi.Service
{
    /// <summary>
    /// Services pour les <see cref="Article"/>
    /// </summary>
    public class ArticleService
    {
        #region Properties

        /// <summary>
        /// Liste des articles
        /// </summary>
        private List<Article> Articles { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructeur, instancie les deux premiers articles de la liste.
        /// </summary>
        public ArticleService()
        {

            Articles = new List<Article>()
            {
                new Article(1, "Article 1"),
                new Article(2, "Article 2"),
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Ajoute un nouvel article à la liste
        /// </summary>
        /// <param name="name">Nom de l'article à ajouter</param>
        /// <returns></returns>
        public Article AddArticle(string name)
        {
            Article article = new Article(Articles.Max(id => id.Identifier) + 1, name);
            Articles.Add(article);
            return article;
        }

        /// <summary>
        /// Retourne la liste des articles
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticles() => Articles;

        /// <summary>
        /// Retourne l'article de l'identifiant correspondant
        /// </summary>
        /// <param name="identifier">Identifiant</param>
        /// <returns></returns>
        public Article? GetArticleById(int identifier) => Articles.Find(a => a.Identifier == identifier);

        /// <summary>
        /// Obtient l'article par son nom
        /// </summary>
        /// <param name="name">Nom</param>
        /// <returns></returns>
        public Article? GetArticleByName(string name) => Articles.Find(a => a.Name == name);

        /// <summary>
        /// Supprime l'article par son identifiant
        /// </summary>
        /// <param name="identifier"></param>
        public void DeleteArticle(int identifier) =>
            Articles.Remove(GetArticleById(identifier) ?? throw new Exception("Aucun article associé"));

        #endregion

    }
}
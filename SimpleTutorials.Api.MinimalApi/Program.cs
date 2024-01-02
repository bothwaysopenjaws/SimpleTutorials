
#region Préparation de la base de l'APi

/* On est parti d'un projet console. On a modifier le projet 
<Project Sdk="Microsoft.NET.Sdk"> pour 
<Project Sdk="Microsoft.NET.Sdk.Web">
*/

using Microsoft.AspNetCore.Mvc;
using SimpleTutorials.Api.MinimalApi.Model;
using SimpleTutorials.Api.MinimalApi.Service;

WebApplicationBuilder? builder = WebApplication.CreateBuilder();


// On ajoute ArticleService en tant que Singleton. (instance ayant la durée de vie de l'application)
builder.Services.AddSingleton<ArticleService>();


WebApplication? app = builder.Build();

#endregion






#region Rest EndPoint

#region Get

app.MapGet("/get/hello", () => "Hello Get !");
app.MapGet("/get/{id:int}", ([FromQuery] int id, [FromServices] ArticleService service) =>  service.GetArticleById(id));

#endregion

#region Delete
app.MapDelete("/delete/hello", () => "Hello Delete !");

#endregion

#region Put
// Remarque : utiliser postman pour envoyer des requêtes put/post/patch pour le body
app.MapPut("/put/hello", () => "Hello Put !");

#endregion

#region Post
// Remarque : utiliser postman pour envoyer des requêtes put/post/patch pour le body
app.MapPost("/post/hello", () => "Hello Post !");
app.MapPost("/post/query/", ([FromQuery] string name, [FromServices] ArticleService service) 
    => service.AddArticle(name));
app.MapPost("/post", (Article article, [FromServices] ArticleService service)
    => service.AddArticle(article.Name));
#endregion

#region Patch

app.MapPatch("/patch", () => "Hello Patch !");

#endregion


#region Others

app.MapMethods("/methods", new[] { "GET", "POST" }, () => "Hello methods");

#endregion

#endregion





#region Running

app.Run();


#endregion




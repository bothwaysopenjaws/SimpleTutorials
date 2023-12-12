# Infrastructure de base

## SimpleTutorials.Core
Ajout du Projet .Core contentenant l'ObservableObject (Cf TP garage).
On s'en servira pour notifier l'interface des messages d'erreur et de la modification de la visibilité de la grille principale.
Pour rappel,  __ObservableObject__ permet à l'objet qui l'hérite d'être observable et d'utiliser la méthode SetProperty(). Cette méthode indique le nom de la propriété qui a été modifiée à la vue et lui indique qu'elle doit le mettre à jour.


## SimpleTutorials.DbLib

Contient La liaison avec la base de données via EF core. 

Pour rester simple, on aura qu'une seule table "User"

On y retrouve les packages suivants : 
- EF core
- EF core.SQLServer (le provider)
- EF core Tools ( outils pour faire les migration et la maj de la base)
- System.Configuration.ConfigurationManager (Sert à la récupération de la Configuration défini dans l'App.config)

La base de données s'appellera SimpleTutorials

### Stockage de la chaîne de connexion

Pour éviter d'avoir la chaîne de connexion présente en "dur" dans le code, vous pouvez utiliser un fichier de configuration.
Ce fichier est présent à la racine du projet WPF et porte le nom de App.config. On y retrouve des informations sous la forme de clef-valeur, ici la chaîne de connexion :

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<connectionStrings>
		<clear />
		<add
			name="SQLServerConnection"
			connectionString="Server=localhost;Database=SimpleTutorials;Trusted_Connection=True;TrustServerCertificate=True;"/>
	</connectionStrings>
</configuration>
```

__Ce fichier est intéressant pour plusieurs raisons :__
- Vous pouvez avoir une version locale si vous avez une chaîne de connexion différente
- En stockant la chaîne de connexion en locale, vous pouvez éviter de la mettre sur votre git
- Si vous vous servez à plusieurs reprise de votre chaîne de connexion, vous n'avez plus qu'à la modifier ici.

Vous pouvez acceder à votre chaîne de connexion par le code suivant :
```c#
ConfigurationManager.ConnectionStrings["SQLServerConnection"].ConnectionString;
```

__Remarque :__ Pour pouvoir faire cet appel, la lib System.Configuration.ConfigurationManager (disponible par Nugget) est nécessaire.

On considérera que c'est le "Lvl 1" pour la gestion de la chaîne de connexion. Nous irons plus loin à ce sujet dans un autre projet.


## SimpleTutorials.Wpf.Authentication

C'est le projet de notre interface graphique. Nous allons nous en servir pour s'authentifier et créer des utilisateurs. 

### Le fichier App.xaml.cs

Pour simplifier la gestion, j'ai fais plusieurs implémentations spécifiques dans l'app.xaml.cs.

J'ai fait en sorte que le constructeur supprime et génère automatiquement la base de données à chaque lancement du projet.
Des données de tests sont également insérées au même moment.

Dans le cadre de vos projets, cette étape n'est pas nécessaire, sachez simplement que c'est possible :).


__Remarque :__ Vous avez un exemple d'ajout d'un utilisateur en base de données avec le mot de passe Hashé dans la méthode  AddMockupUsers()

On utilise ici le hasher de Microsoft.AspNet.Identity. 
La version est actuellement bonne, mais target une version du framework du framework plus ancienne, générant un warning.
Pour éviter d'avoir ce warning, j'ai désactivé l'alerte en modifiant le fichier SimpleTutorials.Wpf.Authentication.csproj et en ajoutant la ligne suivante :

```xml
		<NoWarn>nu1701</NoWarn>
```

### La fenêtre principale : MainWindow

Il s'agit du point d'entrée de notre application. 

Elle dispose d'une grid qui contient elle même 2 userControls, MainView et LoginView, déclarer dans ce même ordre.
C'est important car ça signifie que LoginView est au dessus de la mainView. On va donc jouer sur la visibilité de LoginView Pour afficher le contrôle.


### Le converter BoolToVisibilityConverter
Il s'agit d'une classe permettant de transformé un Booléen (vrai/faux) en une visibilité pour l'interface (Visible, collapsed).
Le converter se trouve dans le dossier SimpleTutorials.Wpf.Authentication.Converters
Pour pouvoir l'utiliser, il faut le déclarer dans l'App.xaml : 
```xml 
        <converters:BoolToVisibilityConverter x:Key="SharedBoolToVisibilityConverter"/>
```

Il devient alors disponible en tant que ressource statique dans toute l'application et peut donc être appelée ainsi : 
```xml 
    <Grid
		Visibility="{Binding IsLoggedIn, Converter={StaticResource SharedBoolToVisibilityConverter}, UpdateSourceTrigger=PropertyChanged, ConverterParameter='!'}">
```
Où :
- IsLoggedIn est l'élément qu'on évalue (qui doit donc ici être un booléen) et qui provient du dataContext (donc, le viewModel associé)
- SharedBoolToVisibilityConverter le nom qu'on a donnée en "Key" dans l'app.xaml
- UpdateSourceTrigger=PropertyChanged Indique que l'on déclenche un événement si on modifie IsLoggedIn par la vue
- ConverterParameter='!' permet d'inverser le comportement du converter (cf commentaire du converter)


#### La LoginView
C'est elle qui renvoie le formulaire de connexion. Dans le code behind (LoginView.xaml.cs), on notera 2 méthodes :
- PasswordBoxLogin_PasswordChanged : Cette méthode met à jour le mot de passe dans le VM. On utilise cette méthode car pour des raisons de sécurité, le binding n'est pas possible sur une passwordBox. Il existe des méthodes altérnatives mais c'est assez compliquer à mettre en place ;)
- ConnectButton_Click : Appelle la vérification de l'ID/mdp dans le viewModel

Dans le constructeur, on indique le contexte de données : il s'agit du viewModel qu'on a préparé à cet effet.

C'est elle qui verra sa grille "cachée" si la propriété de son ViewModel "IsLoggedIn" passe à true lors de l'authentification

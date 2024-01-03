# Introduction

Basé sur la vidéo https://www.youtube.com/watch?v=M1WOD_M_-uU

Nécessite .net 8. Blazor est possible sur des versions plus anciennes mais il faut choisir entre webassembly et Server.

# Création du projet
> Type de projet Blazor WebApp, Option Auto, avec les samples, sans HTTPS

# Server 
> S'éxecute côté server et maintient un pont WebSocket

Le pont n'est plus nécessaire en .NET 8. On ne l'a que si on le souhaite.

# WebAssembly (wasm)
Télécharge un client côté terminal. Permet par exemple des modes offline


# Hybrid

Se base sur MAUI


# Rendering

2 options :
> ServerSideRenderign (SSR)
> StreamRendering (SR)


# 2 projets
## SimpleTutorials.Blazor.WebApp -> Projet de base
Un lien websocket sera établi.
Les composants nécessaires seront téléchargés.

Components contients les pages qui sont statiques (Error, Home et Weather)

## SimpleTutorials.Blazor.WebApp.Client -> Pour les webassemblies
Utiliser en local par le client. Nécessite le point d'entrée Program.cs.

Dossier Pages, contient des fichiers Razor nécéssitant une interactivité (Counter).




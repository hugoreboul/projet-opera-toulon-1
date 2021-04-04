## Git

- **Git** permet de **versionner** notre code
- Il suffit de l'installer sur votre machine
  - https://git-scm.com/downloads
- Les commandes **Git** s'exécutent dans une invite de commande
- Il existe plusieurs logiciels qui permettent de faire abstraction des commandes, les **Git clients**
  - https://desktop.github.com/
  - https://git-fork.com/

### Repo

- Le **repo** est la partie du code hébergé sur le serveur GitHub
- Le **repo** est donc en ligne
- Le **repo** contient une branche principale nommée `main` (anciennement nommé `master`)

### Branche

- Une **branche** est une "dérivée" du code en cours
- Il faut choisir une **branche** pour développer dessus
- Lorsqu'on a des **modifications** en cours **on ne peut pas changer de branche**

### Clone

- **Clone** permet de récupérer le projet situé sur le serveur et de le copier en **local** sur sa machine
- Pour s'assurer qu'un projet est bien **Clone** il y a un dossier `.git` situé à la racine du projet qui contient les versions du code dans le langage de **Git**

### Commit

- Lorsqu'on **modifie** du code qui est **versionné** **Git** le voit automatiquement
- Le code qui a été modifié peut être **commit**
- Un **commit** est composé d'un titre et d'un commentaire
- Un **commit** garde en mémoire toutes les modifications qui ont été apporté au code au moment du **commit**
- De ce fait en cliquant sur le titre du **commit** on peut voir les modifications qui ont été apporté à ce moment

### Push

- Lorsqu'on **commit** des modifications on écrit dans le dossier `.git` en local
- Afin de partager le **commit** avec les autres développeurs il faut **push** le **commit** vers le serveur

### Fetch

- Ne pas oublier tout ce qu'on développe à un moment t c'est en local sur notre machine
- Avant de **push** des modifications sur le serveur il faut s'assurer d'**être à jour** avec le **serveur**
- **Fetch** permet de regarder s'il y a eu des **commits** qui ont été **push** par les autres développeurs

### Pull

- L'action **pull** va télécharger sur votre machine en local les **commits** des autres développeurs

### Pour infos

- des **conflits** peuvent apparaitre lorsqu'on veut **commit** des modifications vers le serveur et qu'on a fait un **pull** juste avant, par exemple vous venez de créer une variable `position` dans le fichier `Joueur.cs` et vous voulez **push** les modifications sauf que vous venez de **pull** les modifications d'un développeur et il a aussi créé une variable qui s'appelle `position` dans le même fichier. Le client **Git** va vous proposer de gérer le conflit en choisissant de prendre une des modifications, soit vous gardez la ligne du développeur soit la votre.

---

## Workflow Gitflow

- Un **WF Gitflow** permet gérer le développement collaboratif de plusieurs fonctionnalités sur un projet
- Chaque développeur pourra développer sur une branche de la fonctionnalité
- A la fin d'un dev d'une fonctionnalité l'équipe qualité se charge de passer les tests et de faire l'intégration à la branche en cours du projet
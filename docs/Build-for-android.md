# PROJET

Compiler Unity sur Android

## Prérequis

Installer Android Studio, Android FileTransfer, Unity (n'oubliez pas d'installer les packages Android et Vuforia dans le Unity Manager Installation)

### Getting started

Une fois dans unity, window > Asset Store, rechercher Simple Mobile Placeholder, DL et import


### Installation


```
https://drive.google.com/drive/u/1/folders/1-NXOxxQQSJ6hJFHdioWRsFgOWLWEKYlO 

Installez le JDK fourni dans le dossier /resources/java
Installez Android Studio et dans le dossier SDK, remplacez les tools et les platform-tools fournis dans le dossier /resources/android


```

Dans Unity : Unity > Preferences > External tools 

```
SDK : /Users/aabbou/Library/Android/sdk 
JDK : /Library/Java/JavaVirtualMachines/jdk1.8.0_161.jdk/Contents/Home

```

## Configurer le build 

Dans unity : File > Build Settings

```
Cliquer sur Android et faire Switch Platform 
Add Open Scenes et ajouter la scene courante

```

### Configurer les identifiants 


```
Edit > Project Settings > Player > Other settings 
Dans identification, renommer le bundle identifier qui correspond à com.companyName.productName

```

### Configuration des paramètres


```
Dans other settings : Desactiver android TV compatibility 
Dans XR settings : Activer vuforia augmented reality dans les différents panneaux  
```

### Préparer le device Android 

```
Se mettre en mode développeur et s'assurer que l'USB debugging est activé 
```

## Run le build 

```
Dans file > build settings : Build and run
```

# Fonctions d'ordre supérieur en C#

Les fonctions d'ordre supérieur sont un concept important en programmation qui permet de passer des fonctions comme des arguments à d'autres fonctions. Cela peut sembler complexe au début, mais avec cet article, vous allez comprendre les bases de ces fonctions et apprendre à les utiliser en C#.

## Qu'est-ce qu'une fonction d'ordre supérieur ?

Une fonction d'ordre supérieur est une fonction qui prend une autre fonction comme argument ou retourne une fonction comme valeur de retour. Les fonctions d'ordre supérieur sont également connues sous le nom de fonctions de haut niveau ou de fonctions de deuxième ordre.

## Types de fonctions d'ordre supérieur

Il existe deux types de fonctions d'ordre supérieur :

### 1. Fonctions qui prennent une fonction comme argument

Les fonctions qui prennent une fonction comme argument sont appelées `Action` ou `Func`. 

#### Exemple 1
Voici un exemple d'utilisation de `Action` :
```csharp
Action<int> myAction = x => Console.WriteLine(x);
myAction(5); // Affichera "5" dans la console
```
Dans cet exemple, `myAction` est une fonction qui prend un entier comme argument et affiche ce nombre dans la console.

#### Exemple 2
Voici un exemple d'utilisation de `Action` avec LINQ pour filtrer une collection :
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Action<int> myAction = x => Console.WriteLine(x);
numbers.Where(myAction).ToList(); // Affichera les nombres impairs dans la console
```
Dans cet exemple, `myAction` est une fonction qui prend un entier comme argument et affiche ce nombre dans la console. La méthode `Where` de LINQ utilise cette fonction pour filtrer la collection `numbers` et afficher les nombres impairs.

### 2. Fonctions qui retournent une fonction

Les fonctions qui retournent une fonction sont appelées `Func` ou `Delegate`. 

#### Exemple 1
Voici un exemple d'utilisation de `Func` :
```csharp
Func<int, int> myFunc = x => x * 2;
int result = myFunc(5); // Retourne 10
```
Dans cet exemple, `myFunc` est une fonction qui prend un entier comme argument et retourne le double de ce nombre.

#### Exemple 2
Voici un exemple d'utilisation de `Func` avec LINQ pour filtrer une collection :
```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, bool> myFunc = x => x % 2 == 0;
numbers.Where(myFunc).ToList(); // Retourne la liste des nombres pairs
```
Dans cet exemple, `myFunc` est une fonction qui prend un entier comme argument et retourne un booléen indiquant si le nombre est pair. La méthode `Where` de LINQ utilise cette fonction pour filtrer la collection `numbers` et retourner la liste des nombres pairs.

## Avantages des fonctions d'ordre supérieur

Les fonctions d'ordre supérieur offrent plusieurs avantages, notamment :

### 1. Flexibilité

Les fonctions d'ordre supérieur permettent de créer des fonctions plus génériques et plus flexibles. Vous pouvez passer des fonctions comme arguments pour les modifier ou les combiner.

### 2. Réutilisation

Les fonctions d'ordre supérieur permettent de réutiliser du code en passant des fonctions comme arguments. Vous pouvez créer des fonctions qui peuvent être utilisées avec différentes fonctions.

### 3. Simplification

Les fonctions d'ordre supérieur peuvent simplifier le code en permettant de regrouper des opérations complexes en une seule fonction.

## Exemples d'utilisation

### Sans LINQ
Voici quelques exemples d'utilisation de fonctions d'ordre supérieur :

#### 1. Utilisation de `Action` pour afficher des messages

```csharp
Action<string> myAction = message => Console.WriteLine(message);
myAction("Bonjour"); // Affichera "Bonjour" dans la console
```
#### 2. Utilisation de `Func` pour multiplier des nombres

```csharp
Func<int, int> myFunc = x => x * 2;
int result = myFunc(5); // Retourne 10
```
#### 3. Utilisation de `Func` pour créer une fonction qui retourne une fonction

```csharp
Func<int, Func<int, int>> myFunc = x => y => x + y;
int result = myFunc(5)(3); // Retourne 8
```

### Avec LINQ
Et en voici avec LINQ :

#### 1. Utilisation de `Action` pour afficher des messages

```csharp
List<string> names = new List<string> { "John", "Mary", "Jane" };
Action<string> myAction = name => Console.WriteLine(name);
names.Where(myAction).ToList(); // Affichera les noms dans la console
```
#### 2. Utilisation de `Func` pour filtrer une collection

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, bool> myFunc = x => x % 2 == 0;
numbers.Where(myFunc).ToList(); // Retourne la liste des nombres pairs
```
#### 3. Utilisation de `Func` pour créer une fonction qui retourne une fonction

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
Func<int, Func<int, bool>> myFunc = x => y => x + y > 5;
numbers.Where(myFunc).ToList(); // Retourne la liste des nombres supérieurs à 5
```

## Conclusion

**Action** et **Func** sont donc 2 nouveaux *types* à connaître et maîtriser en C# afin de tirer le maximum de la programmation fonctionnelle et de comprendre ses mécanismes sous-jacents.

De manière générale, les fonctions d'ordre supérieur sont un concept important en programmation qui peut sembler complexe au début, mais qui offre de nombreux avantages. En comprenant les fonctions d'ordre supérieur, vous pouvez créer des programmes plus flexibles, plus réutilisables et plus simples.

## *Source*

Inspiré de [groq ai inference](https://groq.com/) avec le prompt suivant :
```text
théorie sur les fonctions d’ordre supérieur pour des débutants en programmation Csharp en markdown et avec maximum 500 mots
```
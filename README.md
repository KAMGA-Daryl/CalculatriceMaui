# Calculatrice Mobile .NET MAUI

Application de calculatrice mobile moderne, soignée et pleinement fonctionnelle développée avec **.NET MAUI** dans le cadre de l'Atelier DevMobile.

## 🚀 Fonctionnalités implémentées
* **Opérations de base** : Addition (+), Soustraction (-), Multiplication (×) et Division (÷).
* **Fonctions avancées** : Saisie des décimaux (.), calcul du pourcentage (%), changement de signe (±).
* **Gestion ergonomique** : 
  * Remise à zéro totale (Bouton `C`).
  * Effacement du dernier caractère saisi (Bouton `⌫`).
  * Affichage en temps réel de l'opération en cours au-dessus du résultat.
* **Sécurité & Robustesse** : Gestion explicite de la division par zéro (affiche "Erreur" sans planter l'application).

## 📱 Contraintes de Layouts respectées
L'application combine simultanément **5 types de conteneurs différents** pour assurer une interface responsive et élégante sur toutes les tailles d'écran :
1. **VerticalStackLayout** : Structure globale de la page.
2. **Border** : Encadrement stylisé de l'écran d'affichage.
3. **ScrollView** : Gestion du défilement des longs nombres.
4. **HorizontalStackLayout** : Alignement de la barre d'outils supérieure.
5. **Grid** : Organisation rigoureuse du pavé numérique.

## 🛠️ Technologies
* **Framework** : .NET MAUI (.NET 9.0)
* **IDE** : Visual Studio 
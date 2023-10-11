# Warrior Ninja
Hi everyone. I'm Atakan and welcome to my 2D project.

- I worked as a game developer, map designer and project manager in this game project but all the designs in this project are assets.
- First of all, I would like to state that this project is a simple project because it is a training project for me. And since it is a training project, it is not an open-source project :')
<img src="https://media2.giphy.com/media/GJAEEBOhDfUCLq2nCT/giphy.gif" width="25" height="25">

***

# Project Information
_In this section I will talk about the classes i wrote in this project._


***


# Classes

## [CharacterProperties.cs](https://github.com/mesut-atakan/Unity2D_NinjaKnight/blob/main/Assets/Scripts/Character/CharacterProperties.cs)

```
internal abstract class CharacterProperties : MonoBehaviour
```

In this class, the common properties of the main character and the enemy chracter are written and this class Inheritance the `Player Controller`, `EnemyAI` classes.

>**common properties**
>* character Move Speed
>* is dead
>* Character Move()
>* Take Damage()
>* Damage()


***

## # [PlayerController.cs](https://github.com/mesut-atakan/Unity2D_NinjaKnight/blob/main/Assets/Scripts/Character/PlayerController.cs)

In this class, functions and variables are written for the player to move the main character, run, jump and attack.
![](https://cdn1.byjus.com/wp-content/uploads/2021/07/horizontal-and-vertical-lines-2.png)
> This character's left and right movements were enabled by using horizontal input data.

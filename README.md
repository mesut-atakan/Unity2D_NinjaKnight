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
> - This character's left and right movements were enabled by using horizontal input data. _(A, D Inputs)_
>   - The character's movements were implemented using the `RigidBody2D` class!
> - The character's jump mechanics were written using the `RigidBody2D` class.
> - A key was assigned for the character to run, and when the player presses the key, the character starts to accelerate.
### Player Character Controller:

- [X] <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6eEK4vFwXsQ6yqdSjVDUvKYhj5wmQ5U0P5eTqRUQ2tXEMtaM_8FY_TH4EX1KtPc3BE2s&usqp=CAU" width="30" height="30"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdCZkMeT9Nqx5MjVb9oP45J2rjiMFRZBUNKendhVT6xDm6YOhwvvDhM7i2HObk0dvsUK0&usqp=CAU" width="30" height="30"> **You can move the character to the left and right by pressing the keys.**
- [X] <img src="https://cdn1.iconfinder.com/data/icons/input-gestures/200/bar_keyboard_space_tutorial-512.png" width="60" height="60"> **You can jump the character by pressing the button.**

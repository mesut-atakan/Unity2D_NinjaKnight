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

- <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6eEK4vFwXsQ6yqdSjVDUvKYhj5wmQ5U0P5eTqRUQ2tXEMtaM_8FY_TH4EX1KtPc3BE2s&usqp=CAU" width="30" height="30"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdCZkMeT9Nqx5MjVb9oP45J2rjiMFRZBUNKendhVT6xDm6YOhwvvDhM7i2HObk0dvsUK0&usqp=CAU" width="30" height="30"> **You can move the character to the left and right by pressing the `A, D` keys.**
  
- <img src="https://cdn1.iconfinder.com/data/icons/input-gestures/200/bar_keyboard_space_tutorial-512.png" width="60" height="60"> **You can jump the character by pressing the `space` key.**

- <img src="https://t4.ftcdn.net/jpg/02/77/62/11/360_F_277621185_608MmHTVzVUHelKNcJ1jFGFpcLu9mEpi.jpg" width="45" height="35"> **You can make the character run by pressing the `left shift` key.**

- <img src="https://content.presentermedia.com/files/clipart/00013000/13865/left_mouse_highlight_icon_800_wht.jpg" width="36" height="50"> <img src="https://d1nhio0ox7pgb.cloudfront.net/_img/v_collection_png/512x512/shadow/keyboard_key_e.png" width="30" height="30"> **You can make the character perform a counter attack by pressing the `left mouse button` or the `E` key.**




***



## [EnemyAI.cs](https://github.com/mesut-atakan/Unity2D_NinjaKnight/blob/main/Assets/Scripts/Character/EnemyAI.cs)


In this class, a small AI has been written for the enemy. The class features:

- When the main character enters the enemy's pursuit range, the enemy starts to pursue the main character.

- The enemy character can jump over obstacles that come in their way.

- The enemy can kill the player with a single hit.



***

# Assets

## Enemy Character
### [2D Simple Character : Swordman](https://assetstore.unity.com/packages/2d/characters/2d-simple-character-swordman-133259)
<img src="https://assetstorev1-prd-cdn.unity3d.com/key-image/49b18871-de6e-49f8-b301-16366b051e6b.webp">

> The asset came with animations. There were some noticeable errors in the animations, but I didn't care too much about it because I was doing a training project in the 2D area. I didn't use the scripts that came with the project! I wrote the enemy AI myself!


## Main Character
### [Ninja Sprite Sheet (Free)](https://assetstore.unity.com/packages/2d/characters/ninja-sprite-sheet-free-93901)
<img src="https://assetstorev1-prd-cdn.unity3d.com/key-image/c11ab256-f8b8-4fcb-860a-b131b2cc6524.webp">

> The asset did not include any animations, so I created the animations myself by arranging the sprites in the animation window. I also wrote all the scripts myself.

## Map
### [Platformer Tileset - Pixelart Grasslands](https://assetstore.unity.com/packages/2d/environments/platformer-tileset-pixelart-grasslands-248158)
<img src="https://assetstorev1-prd-cdn.unity3d.com/package-screenshot/d01f3e72-1995-41b2-a449-f7db26530334_scaled.jpg">

> I learned how to use the Grid Component while using this asset. I opened the scene that came with the asset and planned and drew the continuation of the scene!

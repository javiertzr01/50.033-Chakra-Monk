# Chakra Monk

## **Basic Game Description**

**Genre, main objective, provide screenshot of your scene if you are proud of it**

The genre was originally supposed to be an action-based, storyline-driven game where the monk goes through 3 stages of levels to each learn skills to finally best the big bad boss. However, this idea took way longer than I expected.

In the end, I decided to do a vertical platformer game with enemies that will try their best to foil your ascend upwards by attempting to kill you. The main objective is simply to reach the door at the highest point of the vertical climb while besting the enemies you meet along the way.

### Game Executable

**State system requirements: Windows**

[Video](https://youtu.be/W3SHSJBwxMU)  
[Executable](https://sutdapac-my.sharepoint.com/:u:/g/personal/javier_teo_mymail_sutd_edu_sg/EckAylc10lBOmBzk6_3dq8kBLORHfvkmoKwpRs5AtsmloA?e=ERxR6u)

### **How to Play**

**Simple procedure on how to navigate in your game**

Left/Right Arrow Keys - Move character left and right

Spacebar - Jump/JumpHold. The longer you hold, the higher you jump.

C, X, S, D Keys - They are the keys I’m most familiar with when using Arrow keys for navigation. Hence, I used them as the attack keys. C and X are your basic normal punches and kicks respectively, while D and S are the special punches and kicks that will generate an energised projectile (But they cost resources).

### Gameplay Video

A ~60s recorded run of your game from start to finish (you may record from Unity editor, show your Game window clearly). You may provide a **working link, or a gif embedded directly here.**

## Features Implementation

Fill up the table below based on the **features** that you want us to grade you with. You may implement more features than what you can afford as your feature points, so you can select the features that we can grade. Feature prerequisite rule should apply.

You are free to transform the table below into short paragraphs if you’d like. The goal is to ensure that we **can find** and **confirm** each node implementation.

| Node ID | Color | Short Description of Implementation | Feature Point Cost | Marks to earn |
| --- | --- | --- | --- | --- |
| 5 | White | In the 1st Scene, the camera only follows horizontally. However, in the 2nd Scene, I tweaked the camera to also follow vertically to account for the gameplay | 1 | 3 |
| 7 | White | The 2nd Scene is a platform game | 1 | 3 |
| 16 | White | My player has 2 forms of normal attacks, a kick and a punch; Activated by pressing on the x and c keys respectively | 1 | 3 |
| 17 | White | I animated all parts of the character from scratch since I did not know if we were allowed to use the given ones.<br>Jumping, Running, Punching, Kicking etc. | 1 | 3 |
| 18 | White | I have a script called Resource Controller that takes care of everything related to player resources in the game | 1 | 3 |
| 19 | White | I created an enemy prefab called MaskedEnemy that I used in the 2nd Scene | 1 | 3 |
| 20 | White | MaskedEnemy can do 2 things:<br>1. If he is in your line of sight, he will walk towards you and he will spam cactus spikes at you<br>2. If you manage to get close, as soon as he touches you, you will suffer a knockback and get dealt damage. | 1 | 3 |
| 21 | White | MaskedEnemy has a low health but very high damage. | 1 | 3 |
| 22 | White | MaskedEnemy has at least 3 animation clips.<br>Walking, OnHit and Death animation (Explosion) | 1 | 3 |
| 23 | White | My 2D canvas has the 2 resources of the game:<br>Chakra and Hearts | 1 | 3 |
| 24 | White | Upon pickup from the ground, the Chakra and Hearts will be automatically accounted for by Resource Controller in real time. | 1 | 3 |
| 26 | White | I have a UIManager script that utilises ScriptableObjects and EventListeners to update the UI elements. All Modularised. | 1 | 3 |
| 33 | White | Whether my player is facing the left or right side is stored as a BoolVariable Scriptable Object used by the Movement Script and the Resource Controller | 1 | 3 |
| 44 | Orange | As MaskedEnemy was a high damage output enemy, there were 2 approaches to tackle him with different costs.<br>1) Get close to him and try to avoid his cactus spikes by accurately timing the jumps and then quickly launch normal attacks on him.<br>2) Spend some Chakra to use the special attack which has a longer range. | 2 | 10 |
| 45 | Orange | New Input System was used for everything input related.  | 2 | 10 |
| 48 | Orange | I have 2 destructible prefabs called Treasure Chest and Block. Both can drop either Chakra, Heart or nothing at all. Chakra can be used to “heal up” and the Heart will be used for the special move alongside Chakra. | 2 | 10 |
| 65 | Pink | 1) He shoots a “light” version of an energised projectile. This light version does more damage than the normal attacks but cost Chakra to activate. Given the scarcity of health as a resource, I thought it was a fun concept to play with.<br>2) He shoots a “dark” version of the energised projectile.<br>This dark version consumes a heart (I tried to make some storyline element there but no time 😟) It does deal significantly more damage for the cost of BOTH higher cost of Chakra and the Heart which is even rarer to obtain. | 3 | 15 |
| 74 | Pink | I tried my best to use the Scriptable Object Game Architecture as much as I could. I would say I did hit the >90% of game functionality because there is only 1 type of cross referencing in the OnTriggerEnter2D part. However, other than that, any kind of cross referencing was avoided as best I could. | 3 | 15 |

**Total Feature Point spent: 25**

**Maximum Marks to earn: 99**

### Feature Tree Visual Representation

Download the feature tree image and indicate the nodes that you have implemented. Display an image of your completed feature tree here, highlight or circle the **nodes** that you have implemented as a visual aid for us when we grade your submission

![Edited-50033-2023-tree.drawio-2.png](readme%20a2e718a5cc16462a96e358551b1f2c23/Edited-50033-2023-tree.drawio-2.png)

### Feature Analysis

For **each** of your **orange**, **pink** and **purple** nodes, explain clearly your game design justification on how this feature upgrades the **overall quality** of the game. In short, you’re providing a short **analysis**.

- If the feature stated that it has to support a core drive, explain which core drive.
- If the feature does not state anything concrete, it becomes an **open ended feature. Please** use proper terminologies whenever possible.
    - You can argue that this feature forms an **elegant rule**, or
    - It improves the UX of the game, or
    - **It improves code maintenance** overall
- Consult our lecture slides for inspiration and samples on how to concisely **analyse** a game.

| Node ID | Color | Analysis |
| --- | --- | --- |
| 44 | Orange | To get to an objective in a game is to resolve conflicts proposed by the developer or people in the community. It is part and parcel of what makes a game fun. The sense of accomplishment after besting an annoying challenge is what keeps the game enjoyable, to know that there is a challenge but you are able to solve it.<br>In this case, the knockback feature of an enemy is annoying since its a platformer. However, being able to beat it feels rewarding. |
| 45 | Orange | This improves the UX of the development phase and the game. |
| 48 | Orange | Having more than 1 option for each drives their curiosity because of its unpredictability. By scaling it to a wider context, the rare pickup item that may or may not drop will entice the player to destroy as many destructible objects as possible. |
| 65 | Pink | Giving the player 2 special abilities allow him to stand out from the ordinary life. It gives special meaning and in a sense, a calling. Drawing on resources taps in the management part of formal elements and creates a conflict so that there is no “optimal” solution of spamming the same attacks over and over again until the end screen. The scarcity of resources challenges the player and that development of skills and accomplishment motivates the player. |
| 74 | Pink | The Scriptable Object Game Architecture makes modularising a lot more apparent and improves code management as we can link things up quickly via the Inspector while keeping the modularity in code. |

## Asset Used & Credits

It’s nice to give **credits** to the creator of the assets (if info is available).

Pixel-Adventure 1

Gothicvania Church Files

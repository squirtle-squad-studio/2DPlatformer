# Tasks
## GUI
### Less Clutter in Scripts
- [ ] Only show debug fields when debug mode is on.
    - [ ] use [ConditionalField("Debug")]
### Add Health Bar
- [ ] Use 5 health bar
### Add Energy Bar
- [ ] Use 100 as base mana

## Level Design
### Scene 1 (Starting Level)
- [ ] Player is at school.
    - [ ] Bullies tells the player that the prop(sword) is in the forest.
    - [ ] Player get lost in the forest looking for the prop.
    - [ ] Player can only walk and run at this point.
- [ ] A medium distance will have a scary vibe (dawn and in a forest)
    - [ ] Pop a dialogue of the player character
        - [ ] Nervous attitude
    - [ ] A zombie will start chasing at the player from behind
        - [ ] Zombie speed should be slow which leaves
            - [ ] Leave enough time for player to pick up sword
    - [ ] A prop sword will be there and it is what the player is looking for
        - [ ] Player can pick up the sword
    - [ ] There will be more zombies and the player is surrounded
    - [ ] Tom comes and save the player
        - [ ] Tom then provides shelter for the player
### Scene 2
#### Player wakes up
- [ ] Tom assigns the player for some tasks
    - [ ] Get wood
        - [ ] Repair barricades
        - [ ] Make fire for cooking
    - [ ] Get water
#### Player and Tom talk about each other's lives
- [ ] Player
    - [ ] Lost world 2019
        - [ ] School project in an acting class
- [ ] Tom
    - [ ] Insight on the current year 2200
    - [ ] Tragedy with his family

## Character
- [ ] Tom
- [ ] Kent
- [ ] Player
    - [ ] Sword attack
        - [ ] Upgrade in scene 3: Dash attack
        - [ ] Upgrade in scene 3: Restore Mana
    - [ ] Fireball attack
        - [ ] Upgrade in scene 3: Mark enemy
            * Resets Dash attack cooldown

## Scripting
### Cooldown class
- [ ] nextCastTime be a private variable
- [ ] rename NextCD to increment
- [ ] Remove Cooldown method

## Bugs to Fix
- [ ] Player
    - [ ] Projectile firing backward
        * Produced by the player using fire ball attack
            * When player immediately turn around as the fire ball is spawned.

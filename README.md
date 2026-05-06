# CollectAndSurvive-Unity

A Unity gameplay programming prototype focused on player movement, pickup collection, enemy patrol behavior, UI feedback, and level flow.

The player must collect all pickups while avoiding a patrolling enemy. If the enemy catches the player, the level restarts after a short delay. Once all pickups are collected, the player wins and can restart the level.

## Overview

**CollectAndSurvive** is a small Unity gameplay prototype built with C#.  
The project was created as part of a Unity learning path focused on understanding core gameplay programming concepts, scene organization, reusable prefabs, UI systems, and basic level flow.

## Demo Video

A short gameplay demo is available here:

[Watch Demo](https://youtu.be/rp2WE4EYd9c)

## Windows Build

A playable Windows build is available in the GitHub Releases section:

[Download Windows Build](https://github.com/Jason404T/CollectAndSurvive-Unity/releases/tag/v1.0)

## Controls

| Action | Input |
|---|---|
| Move | WASD or Arrow Keys |
| Collect Pickups | Touch pickups |
| Avoid Enemy | Keep distance from the patrolling enemy |
| Restart After Winning | R |

## Main Features

- Player movement using `Rigidbody`
- Camera follow system
- Pickup collection system
- UI pickup counter
- Win condition with on-screen message
- Level restart flow
- Patrolling enemy
- Enemy collision that restarts the level
- Basic obstacle layout
- Organized scene hierarchy
- Reusable prefabs

## Technical Highlights

- Component-based gameplay architecture using Unity and C#
- Rigidbody-based player movement
- Trigger-based pickup collection
- Collision-based enemy interaction
- Separated gameplay logic and UI logic
- Simple level manager for restart and win-state behavior
- Reusable prefabs for pickups, enemies, and level objects
- UI feedback using TextMeshPro

## Built With

- Unity 6
- C#
- TextMeshPro

## Project Structure

```text
Assets/
├── Materials
├── Prefabs
├── Scenes
├── Scripts
└── UI
# Dad's Castle Rescue

A game for Dad — like Stone Sword Castle, but this time **Dad has to save his child**!

Dad the Brave Knight must climb the castle and rescue light fury from the top of the tallest tower.

## Story

Light fury is waiting at the top of the tallest castle tower, waving for help. Dad puts on his knight armour, grabs his sword, and climbs up to save her — through the Castle Gardens, across the Great Hall, and all the way up the Tallest Tower.

## Levels (20 golden keys in all)

1. **Castle Gardens** — collect 5 golden keys
2. **The Great Hall** — collect 7 golden keys
3. **The Tallest Tower** — collect 8 golden keys

Collect every key in a level to unlock the door up to the next one.

## How to play

- **Run:** Arrow keys / A and D, or the on-screen touch buttons
- **Jump:** Space, W, or Up Arrow (or the on-screen JUMP button)
- **Dodge:** rolling barrels — they cost Dad a heart if they bump him
- **Bouncy slimes:** friendly! They only bounce Dad gently and never hurt him
- **Hearts:** grab them to heal a heart
- **Magic shields:** grab one and Dad is protected for a while

## The ending

At the top of the tallest tower, Dad finds light fury waving. Hugs, confetti, and a trophy: **"Best Dad in the Whole Kingdom!"**

## How to play it in Unity on Windows

1. Clone this repo: `git clone https://github.com/cassie-gamer/dads-castle-rescue.git`
2. Open the folder in Unity Hub (Unity 6000 / 2022 LTS or newer)
3. Open the first scene and press **Play**
4. Build it for Windows from **File > Build Settings** when you want to play it on your PC

## Scripts

- `Assets/Scripts/DadKnight.cs` — Dad runs, jumps, takes hits, heals, and cheers
- `Assets/Scripts/KeyCollector.cs` — golden keys, hearts, and magic shields
- `Assets/Scripts/BarrelHazard.cs` — rolling barrels and friendly bouncy slimes
- `Assets/Scripts/CastleLevelManager.cs` — 3 levels, 5/7/8 keys, rescue and win

## Playable web version

A playable web version of this game is the `dad-s-castle-rescue` web artifact.

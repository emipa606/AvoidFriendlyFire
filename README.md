# AvoidFriendlyFire

![Image](https://i.imgur.com/WAEzk68.png)

Update of Falconnes mod
https://steamcommunity.com/sharedfiles/filedetails/?id=1134165362

![Image](https://i.imgur.com/7Gzt3Rg.png)

	
![Image](https://i.imgur.com/NOW7jU1.png)

Colonists with the option enabled will not take a shot if the projectile's path could hit a friendly or neutral pawn (taking into account miss radius). Drafted colonists will look for a target with a clean shot (or wait if there isn't one), while hunters will reposition themselves.

This should hopefully alleviate some of the micromanagement needed to stop ranged colonists shooting friendlies, without changing the way friendly fire works in the game or reducing its potency.


== Usage ==
Any colonist with an appropriate weapon will show an “Avoid Friendly Fire” toggle button when they are selected (which is On by default; you can toggle it off for individual colonists). With this On their AI will automatically do the right thing.

If you manually try to force a drafted colonist who is set to avoid friendly fire to shoot an enemy with a friendly in the way, you will see a "Cannot hit target" message as you would if LoS was blocked.

Shooters who are being blocked by friendlies (but would otherwise have a target) will have their name on the map and in the Colonist Bar be written in cyan. Likewise, the first friendly blocking any shooter will show up in green.

There is a setting in the Mod Options screen to always enable 'Avoid FF' status on a pawn when it's undrafted. If you tend to disable the 'Avoid FF' setting on pawns during combat, using this option will ensure it is always turned back on again before the next combat. This option is off by default.

== Shield Belts ==
Shooters will not worry about pawns wearing a shield belt with at least 10% power standing in the line of fire, so you can still use shielded infantry to attack while ranged troops continue to fire over them from behind. If the shield drops below 10% power while the pawn is still subject to friendly fire, then the shooters will stop. They will resume shooting after the shield gets above 10%.

This behaviour can be disabled from the mod options if needed.


== Targeting Overlay ==
If you use the game’s manual targeting button (the one with the B hotkey that then shows the weapons range), you will see a red overlay that appears from the shooter to where you point the mouse (see image). This overlay shows the potential “fire cone” from a standard ranged weapon in the game, from the shooter to a target under the mouse (miss radius depends on weapon and shooter skill). Any pawn within the red overlay could potentially be hit. This is purely a visual aid for planning and can be disabled from the Mod Settings menu if you don’t like it. Note that pawns within 4 tiles of the shooter do not receive friendly fire, so the overlay does not mark them red and the mod takes this into account when deciding if a shooter should stop. In the example image the shooter on the top right will not shoot the pirate on the bottom left because the colonist "Flip" could potentially get hit.


== Animals ==
By default the mod will also take into account animals with an assigned master and protect them from friendly fire, so you should be able to use and release trained animals without them getting shot. In the Mod Settings you can expand this to include all tamed colony animals, such as livestock, but this is off by default as it could be annoying and cause performance issues on slower machines.


== Notes ==
This mod can be added to an existing save.

This mod is compatible with the Combat Extended mod, however the more complex fire trajectory in CE may mean this mod may not be 100% effective at very long ranges.

It is an often requested feature to add FF avoidance to turrets. However I want my mods to be pure QoL changes and not affect the balance of the game. The improvised turrets are cheap and friendly fire is an intended weakness of them (as mentioned in their tooltip). I am happy for another mod that adds smarter, more expensive turrets to incorporate my code to provide that functionality.


== Current Limitations ==
* Does not support explosive weapons such as grenades and weapons such as miniguns with a large forced miss radius. They will be used as normal and you will need to micromanage them as before. These might be supported in the future.

* Will protect neutral pawns on your map, but not animals owned by them. E.g., if there are traders around during a raid, your colonists will avoid hitting them but not watch out for their animals. Should be fixed in the future.

* Only affects the AI of your colonists. Does not prevent the computer controlled factions shooting their own troops; that’s a hard problem.

* Only affects the AI of shooters, who will stop shooting when someone gets in the way. Nothing is done to stop undrafted pawns from wandering into the middle of battle; again a harder problem to solve.

Github release for standalone install: https://github.com/Falconne/AvoidFriendlyFire/releases
Ludeon Thread: https://ludeon.com/forums/index.php?topic=35571.0

Translations:
* Japanese by @Proxyer
* Traditional Chinese by @FantasyMusic

![Image](https://i.imgur.com/Rs6T6cr.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using wServer.realm;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using common.resources;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Sewers = () => Behav()
            .Init("DS Bat",
                new State(
                    new State("Idle",
                       new Wander(0.75),
                       new PlayerWithinTransition(6, "fight")
                    ),
                    new State("fight",
                       new Follow(2, 8, 1),
                       new Wander(1),
                       new Shoot(10, count: 1, coolDown: 500),
                       new StayBack(0.4, 0.1),
                       new NoPlayerWithinTransition(6, "Idle")
                    )
                )
            )

            .Init("DS Natural Slime God",
                new State(
                    new Prioritize(
                        new StayAbove(1, 200),
                        new Follow(1, range: 7),
                        new Wander(0.4)
                        ),
                    new Shoot(12, projectileIndex: 0, count: 5, shootAngle: 10, predictive: 1, coolDown: 1000),
                    new Shoot(10, projectileIndex: 1, predictive: 1, coolDown: 650),
                    new Reproduce(densityMax: 2)
                    ),
                new Threshold(.01,
                    new TierLoot(6, ItemType.Weapon, 0.04),
                    new TierLoot(7, ItemType.Weapon, 0.02),
                    new TierLoot(8, ItemType.Weapon, 0.01),
                    new TierLoot(7, ItemType.Armor, 0.04),
                    new TierLoot(8, ItemType.Armor, 0.02),
                    new TierLoot(9, ItemType.Armor, 0.01),
                    new TierLoot(4, ItemType.Ability, 0.02)
                    ),
                new Threshold(0.07,
                    new ItemLoot("Potion of Defense", 0.07)
                    )
            )

            .Init("DS Alligator",
                new State(
                    new State("only",
                        new Wander(0.75),
                        new Shoot(6, 3, 20)
                        )
                )
            )
            
            .Init("DS Brown Slime",
                new State(
                new Wander(0.2),
                new Follow(0.7, 10, 0),
                new Shoot(5, 8, coolDown: 2500),
                new Grenade(3, 0, 0.5, coolDown: 1000, effect: ConditionEffectIndex.Slowed, effectDuration: 5000),
                new Reproduce("DS Brown Slime Trail", 1, 20, 250)
                )
            )
            
            .Init("DS Brown Slime Trail",
                new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("shoot",
                        new Shoot(15, 1, coolDown: 6001, coolDownOffset: 1),
                        new TimedTransition(5000, "suicide")
                    ),
                    new State("suicide",
                        new Suicide()
                    )
                )
            )
            
            .Init("DS Yellow Slime",
                new State(
                  new Wander(0.2),
                  new Follow(0.7, 10, 0),
                  new Shoot(5, 8, coolDown: 2500),
                  new Grenade(3, 0, 0.5, coolDown: 1000, effect: ConditionEffectIndex.Slowed, effectDuration: 5000, color: 0),
                  new Reproduce("DS Yellow Slime Trail", 1, 20, 250)
                )
            )

            .Init("DS Yellow Slime Trail",
                new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("shoot",
                        new Shoot(15, 1, coolDown: 6001, coolDownOffset: 1),
                        new TimedTransition(5000, "suicide")
                    ),
                    new State("suicide",
                        new Suicide()
                    )
                )
            )

            .Init("DS Goblin Brute", 
                new State(
                    new State("first",
                        new Wander(0.75),
                        new PlayerWithinTransition(7.2, "second")
                        ),
                    new State("second",
                        new Shoot(7, 4, 15, predictive: 0.4),
                        new Follow(0.8, 7, 0),
                        new NoPlayerWithinTransition(7.2, "first")
                        )
                )
            )

            .Init("DS Goblin Knight",
                new State(
                    new Shoot(7, 1, predictive: 0.75, coolDown: 500),
                    new Wander(0.75),
                    new State("first",
                        new PlayerWithinTransition(6, "second", true)
                    ),
                    new State("second",
                        new Follow(0.95, 6, 1)
                        )
                )
            )

            .Init("DS Goblin Peon", 
                new State(
                new Wander(0.75),
                    new State("first",
                        new Shoot(8, 2, 15, coolDown: 500),
                        new Follow(0.25, 5, 3)
                    )
                )
            )

            .Init("DS Goblin Sorcerer",
            new State(
            new Wander(0.75),
                new State("idle",
                    new Shoot(9, 5, 15, 0, coolDown: 1000),
                    new Grenade(3, 30, 7, coolDown: 1000, effect: ConditionEffectIndex.Confused, effectDuration: 3000)
                    )
                ),
            new ItemLoot("Magic Potion", 0.15)
            )

            .Init("DS Goblin Warlock", 
                new State(
                    new State("idle",
                        new Wander(0.3),
                        new PlayerWithinTransition(8, "shoot")
                    ),
                    new State("shoot",
                        new Wander(0.3),
                        new Shoot(8, 2, 3, 0, coolDown: 500),
                        new Shoot(8, 1, projectileIndex: 1, coolDown: 1000),
                        new NoPlayerWithinTransition(8, "idle")
                    )
                ),
            new TierLoot(4, ItemType.Ability, 0.01),
            new ItemLoot("Magic Potion", 0.15)
            )

            .Init("DS Master Rat",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("first",
                        new PlayerWithinTransition(5, "second")
                        ),
                    new State("second",
                        new Taunt("Hello young adventurers, will you be able to answer my question correctly?"),
                        new TimedTransition(3000, "q1", true),
                        new TimedTransition(3000, "q2", true),
                        new TimedTransition(3000, "q3", true),
                        new TimedTransition(3000, "q4", true),
                        new TimedTransition(3000, "q5", true)
                        ),
                    new State("q1",
                        new Taunt("What time is it?"),
                        new PlayerTextTransition("correct", "Its pizza time!", ignoreCase: true),
                        new PlayerTextTransition("correct", "Its pizza time", ignoreCase: true),
                        new TimedTransition(15000, "incorrect")
                        ),
                    new State("q2",
                        new Taunt("Where is the safest place in the world?"),
                        new PlayerTextTransition("correct", "Inside my shell.", ignoreCase: true),
                        new PlayerTextTransition("correct", "Inside my shell", ignoreCase: true),
                        new TimedTransition(15000, "incorrect")
                        ),
                    new State("q3",
                        new Taunt("What is fast, quiet and hidden by the night?"),
                        new PlayerTextTransition("correct", "A ninja of course!", ignoreCase: true),
                        new PlayerTextTransition("correct", "A ninja of course", ignoreCase: true),
                        new TimedTransition(15000, "incorrect")
                        ),
                    new State("q4",
                        new Taunt("How do you like your pizza?"),
                        new PlayerTextTransition("correct", "Extra cheese, hold the anchovies.", ignoreCase: true),
                        new PlayerTextTransition("correct", "Extra cheese, hold the anchovies", ignoreCase: true),
                        new TimedTransition(15000, "incorrect")
                        ),
                    new State("q5",
                        new Taunt("Who did this to me?"),
                        new PlayerTextTransition("correct", "Dr. Terrible, the mad scientist.", ignoreCase: true),
                        new PlayerTextTransition("correct", "Dr. Terrible, the mad scientist", ignoreCase: true),
                        new TimedTransition(15000, "incorrect")
                        ),
                    new State("correct",
                        new TossObject("DS Blue Turtle", 2, 45),
                        new TossObject("DS Orange Turtle", 2, 135),
                        new TossObject("DS Purple Turtle", 2, 225),
                        new TossObject("DS Red Turtle", 2, 315),
                        new Taunt("Cowabunga!"),
                        new TimedTransition(5000, "suicide")
                        ),
                    new State("incorrect",
                        new Shoot(99, 16, coolDown: 99999),
                        new Suicide()
                        ),
                    new State("suicide",
                        new Suicide()
                        )
                )
            )

            .Init("DS Blue Turtle",
                new State(
                    new Wander(0.3),
                    new StayCloseToSpawn(0.3, 3)
                ),
                new Threshold(0.01,
                new ItemLoot("Void Blade", 0.01)
                    )
            )

            .Init("DS Orange Turtle",
                new State(
                    new Wander(0.3),
                    new StayCloseToSpawn(0.3, 3)
                ),
                new Threshold(0.01,
                new ItemLoot("Void Blade", 0.01)
                    )
            )

            .Init("DS Purple Turtle",
                new State(
                    new Wander(0.3),
                    new StayCloseToSpawn(0.3, 3)
                ),
                new Threshold(0.01,
                new ItemLoot("Void Blade", 0.01)
                    )
            )

            .Init("DS Red Turtle",
                new State(
                    new Wander(0.3),
                    new StayCloseToSpawn(0.3, 3)
                ),
                new Threshold(0.01,
                new ItemLoot("Void Blade", 0.01)
                    )
            )

            .Init("DS Golden Rat",
                new State(
                    new State("idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new PlayerWithinTransition(6, "scream")
                    ),
                    new State("scream",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new Taunt("Squeek!"),
                        new TimedTransition(2000, "run")
                    ),
                    new State("run",
                        new StayBack(1, 13),
                        new TimedTransition(15000, "suicide"),
                        new NoPlayerWithinTransition(12, "suicide")
                    ),
                    new State("suicide",
                        new Suicide()
                    )
                ),
                new ItemLoot("Potion of Defense", 0.15),
                new ItemLoot("Murky Toxin", 0.005)
                
            )

            .Init("DS Rat", 
                new State(
                new Wander(0.75),
                new Shoot(7, 3, 25, predictive: 0.1, coolDown: 750)
                )
            )

        .Init("DS Boss Minion",
            new State(
                new State("idle",
                    new Wander(0.6),
                    new Grenade(3, 50, 10, coolDown: 5000)
                    )
                )
            )

        .Init("DS Gulpord the Slime God M",
            new State(
                new State("idle",
                    new Orbit(0.6, 3, target: "ds gulpord the slime god"),
                    new Shoot(10, 8, 45, 1, coolDown: 1500),
                    new Shoot(10, 4, 60, 0, coolDown: 4500),
                    new HpLessTransition(0.025, "ss")
                    ),
                new State("ss",
                    new Spawn("DS Gulpord the Slime God S", coolDown: 999999),
                    new Spawn("DS Gulpord the Slime God S", coolDown: 999999),
                    new Suicide()
                    )
                )
            )

        .Init("DS Gulpord the Slime God S",
            new State(
                new State("idle",
                    new Orbit(0.6, 3, target: "ds gulpord the slime god"),
                    new Shoot(10, 4, 20, 1, coolDown: 2000)
                    )
                )
            )

        .Init("DS Gulpord the Slime God",
            new State(
                new RealmPortalDrop(),
                new State("idle",
                    new PlayerWithinTransition(12, "begin")
                    ),
                new State("begin",
                    new TimedTransition(500, "shoot")
                    ),
                new State("shoot",
                    new HpLessTransition(0.90, "randomshooting"),
                    new Shoot(10, 8, 45, 1, coolDown: 2000),
                    new Shoot(10, 5, 72, 0, 0, coolDown: 1000),
                    new Shoot(10, 5, 72, 0, 6, coolDown: 1000),
                    new TimedTransition(400, "shoot1")
                    ),
                new State("shoot1",
                    new HpLessTransition(0.90, "randomshooting"),
                    new Shoot(10, 5, 72, 0, 15, coolDown: 1000),
                    new Shoot(10, 5, 72, 0, 21, coolDown: 1000),
                    new TimedTransition(400, "shoot2")
                    ),
                new State("shoot2",
                    new HpLessTransition(0.90, "randomshooting"),
                    new Shoot(10, 5, 72, 0, 30, coolDown: 1000),
                    new Shoot(10, 5, 72, 0, 36, coolDown: 1000),
                    new TimedTransition(400, "shoot3")
                    ),
                new State("shoot3",
                    new HpLessTransition(0.90, "randomshooting"),
                    new Shoot(10, 5, 72, 0, 45, coolDown: 1000),
                    new Shoot(10, 5, 72, 0, 51, coolDown: 1000),
                    new TimedTransition(400, "shoot4")
                    ),
                new State("shoot4",
                    new HpLessTransition(0.90, "randomshooting"),
                    new Shoot(10, 5, 72, 0, 60, coolDown: 1000),
                    new Shoot(10, 5, 72, 0, 66, coolDown: 1000),
                    new TimedTransition(400, "shoot")
                    ),
                new State("randomshooting",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ReturnToSpawn(1),
                    new TimedTransition(1500, "randomshooting1")
                    ),
                new State("randomshooting1",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 8, 45, 1, coolDown: 2000),
                    new Shoot(10, 9, 40, 0, 0, coolDown: 1000),
                    new TimedTransition(200, "randomshooting2")
                    ),
                new State("randomshooting2",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 30, coolDown: 1000),
                    new TimedTransition(200, "randomshooting3")
                    ),
                new State("randomshooting3",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 3, coolDown: 1000),
                    new TimedTransition(200, "randomshooting4")
                    ),
                new State("randomshooting4",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 81, coolDown: 1000),
                    new TimedTransition(200, "randomshooting5")
                    ),
                new State("randomshooting5",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 250, coolDown: 1000),
                    new TimedTransition(200, "randomshooting6")
                    ),
                new State("randomshooting6",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 172, coolDown: 1000),
                    new TimedTransition(200, "randomshooting7")
                    ),
                new State("randomshooting7",
                    new HpLessTransition(0.70, "tossnoobs"),
                    new Shoot(10, 9, 40, 0, 183, coolDown: 1000),
                    new TimedTransition(200, "randomshooting1")
                    ),
                new State("tossnoobs",
                    new TossObject("DS Boss Minion", 3, 0, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 45, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 90, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 135, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 180, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 225, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 270, coolDown: 99999999),
                    new TossObject("DS Boss Minion", 3, 315, coolDown: 99999999),
                    new TimedTransition(100, "derp")
                    ),
                new State("derp",
                    new ConditionalEffect(ConditionEffectIndex.Armored),
                    new HpLessTransition(0.50, "invstate"),
                    new Shoot(10, 6, 12, 0, coolDown: 3000),
                    new Wander(0.5),
                    new StayCloseToSpawn(0.5, 7)
                    ),
                new State("invstate",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new State("baibaiscrubs",
                    new ReturnToSpawn(speed: 2),
                    new ChangeSize(20, 100),
                    new TimedTransition(200, "seclol")
                    ),
                new State("seclol",
                    new ChangeSize(20, 80),
                    new TimedTransition(1, "seclol2")
                    ),
                new State("seclol2",
                    new ChangeSize(20, 60),
                    new TimedTransition(1, "seclol3")
                    ),
                new State("seclol3",
                    new ChangeSize(20, 40),
                    new TimedTransition(1, "seclol4")
                    ),
                new State("seclol4",
                    new ChangeSize(20, 20),
                    new TimedTransition(1, "seclol5")
                    ),
                new State("seclol5",
                    new ChangeSize(20, 0),
                    new TimedTransition(1, "nubs")
                    ),
                new State("nubs",
                    new TossObject("DS Gulpord the Slime God M", 3, 32, coolDown: 9999999, tossInvis: true),
                    new TossObject("DS Gulpord the Slime God M", 3, 15, coolDown: 9999999, tossInvis: true),
                    new TimedTransition(3000, "idleeeeee")
                    ),
                new State("idleeeeee",
                    new EntitiesNotExistsTransition(10, "seclolagain", "DS Gulpord the Slime God M", "DS Gulpord the Slime God S")
                    ),
                new State("seclolagain",
                    new ChangeSize(0, 0),
                    new TimedTransition(1, "seclolagain1")
                    ),
                new State("seclolagain1",
                    new ChangeSize(30, 30),
                    new TimedTransition(1, "seclolagain2")
                    ),
                new State("seclolagain2",
                    new ChangeSize(60, 60),
                    new TimedTransition(1, "seclolagain3")
                    ),
                new State("seclolagain3",
                    new ChangeSize(90, 90),
                    new TimedTransition(1, "seclolagain4")
                    ),
                new State("seclolagain4",
                    new ChangeSize(120, 120),
                    new TimedTransition(1, "seclolagain5")
                    ),
                new State("seclolagain5",
                    new ChangeSize(150, 150),
                    new TimedTransition(1, "GO ANGRY!!!!111!!11")
                    ),
                new State("GO ANGRY!!!!111!!11",
                    new Flash(0xFF0000, 1, 1),
                    new TimedTransition(1000, "FOLLOW")
                    )
                ),
                new State("FOLLOW",
                new RealmPortalDrop(),
                new ConditionalEffect(ConditionEffectIndex.ParalyzeImmune),
                new ConditionalEffect(ConditionEffectIndex.StunImmune),
                new ConditionalEffect(ConditionEffectIndex.Armored),
                new Shoot(10, 8, 45, 2, coolDown: 2000),
                new Shoot(3, 1, 0, 1, coolDown: 1000),
                new Follow(0.6, 10, 0),
                    new State("xdshoot",
                        new Shoot(10, 2, 5, 0, coolDown: 150),
                        new TimedTransition(1750, "xdshoot1")
                        ),
                    new State("xdshoot1",
                        new Shoot(10, 2, 10, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot2")
                        ),
                    new State("xdshoot2",
                        new Shoot(10, 2, 15, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot3")
                        ),
                    new State("xdshoot3",
                        new Shoot(10, 2, 20, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot4")
                        ),
                    new State("xdshoot4",
                        new Shoot(10, 2, 25, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot5")
                        ),
                    new State("xdshoot5",
                        new Shoot(10, 2, 30, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot6")
                        ),
                    new State("xdshoot6",
                        new Shoot(10, 2, 35, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot7")
                        ),
                    new State("xdshoot7",
                        new Shoot(10, 2, 40, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot8")
                        ),
                    new State("xdshoot8",
                        new Shoot(10, 2, 45, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot")
                        ),
                    new State("xdshoot",
                        new Shoot(10, 2, 50, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot9")
                        ),
                    new State("xdshoot9",
                        new Shoot(10, 2, 55, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot0")
                        ),
                    new State("xdshoot0",
                        new Shoot(10, 2, 60, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot00")
                        ),
                    new State("xdshoot00",
                        new Shoot(10, 2, 65, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot000")
                        ),
                    new State("xdshoot000",
                        new Shoot(10, 2, 70, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot0000")
                        ),
                    new State("xdshoot0000",
                        new Shoot(10, 2, 75, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshootxd")
                        ),
                    new State("xdshootxd",
                        new Shoot(10, 2, 80, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshootxdd")
                        ),
                    new State("xdshootxdd",
                        new Shoot(10, 2, 85, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshootxddd")
                        ),
                    new State("xdshootxddd",
                        new Shoot(10, 2, 90, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshootfff")
                        ),
                    new State("xdshootfff",
                        new Shoot(10, 2, 95, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshooteee")
                        ),
                    new State("xdshooteee",
                        new Shoot(10, 2, 100, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshootyyy")
                        ),
                    new State("xdshootyyy",
                        new Shoot(10, 2, 105, 0, coolDown: 1500),
                        new TimedTransition(100, "xdshoot")
                        )
                    )
                ),
            new Threshold(0.1,
                new ItemLoot("Greater Potion of Defense", 1),
                new ItemLoot("Void Blade", 0.005),
                new ItemLoot("Murky Toxin", 0.005),
                new ItemLoot("Slurp Knight Skin", 0.01)
                )
            )
            ;
    }
}
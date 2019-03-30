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
        private _ MountainTemple = () => Behav()
        .Init("Daichi the Fallen",
            new State(
                new ScaleHP(17000),
                new State("hplesslast",
                new HpLessTransition(0.25, "lastPhase"),
                new State("Idle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new PlayerWithinTransition(5, "movetomiddle")
                    ),
                new State("movetomiddle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Delay(2000, new Taunt("Ha Ha fools, you are too late. lord Xil will arrive soon in this realm.")),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "goinvis")
                    ),
                new State("goinvis",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1500, "moveflame1")
                    ),
                new State("moveflame1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 72.5f, 7.5f),
                    new TimedTransition(2500, "govis")
                    ),
                new State("govis",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1500, "spawnflame1")
                    ),
                new State("spawnflame1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Fire Power", 2, coolDown: 999999),
                    new TimedTransition(250, "goinvis1")
                    ),
                new State("goinvis1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "moveflame2")
                    ),
                new State("moveflame2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.6f, 72.5f, 18.5f),
                    new TimedTransition(3000, "govis1")
                    ),
                new State("govis1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "spawnflame2")
                    ),
                new State("spawnflame2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Earth Power", 2, coolDown: 999999),
                    new TimedTransition(250, "goinvis2")
                    ),
                new State("goinvis2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "moveflame3")
                    ),
                new State("moveflame3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.6f, 61.5f, 18.5f),
                    new TimedTransition(3000, "govis2")
                    ),
                new State("govis2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "spawnflame3")
                    ),
                new State("spawnflame3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Water Power", 2, coolDown: 999999),
                    new TimedTransition(250, "goinvis3")
                    ),
                new State("goinvis3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "moveflame4")
                    ),
                new State("moveflame4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.6f, 61.5f, 7.5f),
                    new TimedTransition(3000, "govis3")
                    ),
                new State("govis3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "spawnflame4")
                    ),
                new State("spawnflame4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Spawn("Air Power", 2, coolDown: 999999),
                    new TimedTransition(240, "goinvis4")
                    ),
                new State("goinvis4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "moveflame5")
                    ),
                new State("moveflame5", //middle
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "govis4")
                    ),
                new State("govis4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "shoot1")
                    ),
                new State("shoot1",
                    new Shoot(20, 18, projectileIndex: 0, fixedAngle: 0, coolDown: 5000),
                    new State("shoot1a",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: 14, coolDown: 150),
                        new TimedTransition(3600, "shoot1b")
                        ),
                    new State("shoot1b",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: -14, coolDown: 150)
                        ),
                    new TimedTransition(5000, "invisagain")
                    ),
                new State("invisagain",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "movetoblue")
                    ),
                new State("movetoblue",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 61.5f, 18.5f),
                    new TimedTransition(2500, "visagain")
                    ),
                new State("visagain",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "shootblue")
                    ),
                new State("shootblue",
                    new Shoot(20, 20, 17, 4, 0, 260, coolDown: 800),
                    new TimedTransition(4000, "invisagain1")
                    ),
                new State("invisagain1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "movetored")
                    ),
                new State("movetored",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(1, 72.5f, 7.5f),
                    new TimedTransition(2500, "visagain1")
                    ),
                new State("visagain1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1750, "shootred")
                    ),
                new State("shootred",
                    new Shoot(20, 20, 17, 2, 0, 240, coolDown: 800), 
                    new TimedTransition(4000, "invisagain2")
                    ),
                new State("invisagain2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "movetoblack")
                    ),
                new State("movetoblack",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.8f, 61.5f, 7.5f),
                    new TimedTransition(2500, "visagain2")
                    ),
                new State("visagain2",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "shootblack")
                    ),
                new State("shootblack",
                    new Shoot(20, 20, 17, 3, 0, 240, coolDown: 800),
                    new TimedTransition(4000, "invisagain3")
                    ),
                new State("invisagain3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "movetogreen")
                    ),
                new State("movetogreen",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(1, 72.5f, 18.5f),
                    new TimedTransition(2500, "visagain3")
                    ),
                new State("visagain3",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "shootgreen")
                    ),
                new State("shootgreen",
                    new Shoot(20, 20, 17, 5, 0, 240, coolDown: 800),
                    new TimedTransition(4000, "invisagain4")
                    ),
                new State("invisagain4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "movetomiddle1")
                    ),
                new State("movetomiddle1",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "visagain4")
                    ),
                new State("visagain4",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "shootagain"),
                    new HpLessTransition(0.75, "2ndPhase")
                    ),
                new State("shootagain",
                    new Shoot(20, 18, projectileIndex: 0, fixedAngle: 0, coolDown: 5000),
                    new State("insideshootagainidle",
                        new TimedTransition(5000, "insideshootagain")
                        ),
                    new State("insideshootagain",
                        new Shoot(20, 3, 10, 7, coolDown: 1666),
                        new TimedTransition(5000, "insideshootagain1")
                        ),
                    new State("insideshootagain1",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: 14, coolDown: 150),
                        new TimedTransition(3600, "insideshootagain2")
                        ),
                    new State("insideshootagain2",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: -14, coolDown: 150)
                        ),
                    new TimedTransition(15000, "invisagain")
                    ),
                new State("2ndPhase",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("You think you can defeat me? Then let me show you the true power of Xil!"),
                    new TimedTransition(500, "tauntelem")
                    ),
                new State("backtomiddlein",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "backtomiddle")
                    ),
                new State("backtomiddle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "backtomiddlevi")
                    ),
                new State("backtomiddlevi",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "tauntelem")
                    ),
                new State("tauntelem",
                    new Taunt("Fear the Elements!"),
                    new Order(15, "Fire Power", "shooting"),
                    new Order(15, "Air Power", "shooting"),
                    new Order(15, "Earth Power", "shooting"),
                    new Order(15, "Water Power", "shooting"),
                    new TimedTransition(6000, "flash")
                    ),
                new State("flash",
                    new Flash(0xffffff, 2500, 3),
                    new TimedTransition(2500, "2ndshoot")
                    ),
                new State("2ndshoot",
                    new Shoot(20, 18, projectileIndex: 0, fixedAngle: 0, coolDown: 5000),
                    new Shoot(20, 3, 10, 7, coolDown: 1666),
                    new Shoot(20, 4, 170, 6, 0, 117, coolDown: 250),
                    new Taunt("You are no match for my Powers!"),
                    new TimedTransition(15000, "invisagain"),
                    new HpLessTransition(0.5, "3rdmiddleinv")
                    ),
                new State("3rdmiddleinv",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "3rdmiddle")
                    ),
                new State("3rdmiddle",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "3rdmiddlevi")
                    ),
                new State("3rdmiddlevi",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "3rdPhase"),
                    new HpLessTransition(0.45, "3rdshoot")
                    ),
                new State("3rdPhase",
                    new Taunt("You don’t lack skills! But you have underestimated the power lying within this Temple. Let me show you."),
                    new Shoot(20, 38, projectileIndex: 8, coolDown: 999999),
                    new TimedTransition(100, "spawnhead")
                    ),
                new State("spawnhead",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Flash(0xfdd900, 10000, 10),
                    new TossObject("Water Elemental", 6, 45, 999999),
                    new TossObject("Air Elemental", 6, 135, 999999),
                    new TossObject("Fire Elemental", 6, 225, 999999),
                    new TossObject("Earth Elemental", 6, 315, 999999),
                    new TimedTransition(12000, "3rdshoot")
                    ),
                new State("3rdshoot",
                    new Shoot(20, 18, projectileIndex: 0, fixedAngle: 0, coolDown: 5000),
                    new Reproduce("chasingHorror", coolDown: 2000),
                    new State("inside3rdshootidle",
                        new TimedTransition(5000, "insideshootagain")
                        ),
                    new State("inside3rdshoot",
                        new Shoot(20, 3, 10, 7, coolDown: 1666),
                        new Shoot(20, 4, 170, 8, 0, 117, coolDown: 250)
                        ),
                    new TimedTransition(20000, "tauntelem")
                    )
                    ),
                new State("lastPhase",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(1),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(3)),
                    new Delay(750, new SetAltTexture(4)),
                    new TimedTransition(1000, "lastPhasemid")
                    ),
                new State("lastPhasemid",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new MoveTo(0.5f, 66.5f, 12.5f),
                    new TimedTransition(2500, "lastPhasevi")
                    ),
                new State("lastPhasevi",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new SetAltTexture(3),
                    new Delay(250, new SetAltTexture(2)),
                    new Delay(500, new SetAltTexture(1)),
                    new Delay(750, new SetAltTexture(5)),
                    new TimedTransition(1000, "lastPhaseshoot")
                    ),
                new State("lastPhaseshoot",
                    new HpLessTransition(0.05, "dying"),
                    new Taunt("ENOUGH! You fought well but now it’s time for you to die."),
                    new Taunt("Unlimited power!"),
                    new Reproduce("chasingHorror", coolDown: 2000),
                    new Shoot(20, 18, projectileIndex: 0, fixedAngle: 0, coolDown: 5000),
                    new Shoot(20, 3, 10, 7, coolDown: 1666),
                    new Shoot(20, 4, 170, 6, 0, 117, coolDown: 250),
                    new State("insidelastphase",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: 14, coolDown: 150),
                        new TimedTransition(3600, "insidelastphase1")
                        ),
                    new State("insidelastphase1",
                        new Shoot(20, 4, projectileIndex: 1, fixedAngle: 0, rotateAngle: -14, coolDown: 150),
                        new TimedTransition(3600, "insidelastphase")
                        )
                    ),
                new State("dying",
                    new ConditionalEffect(ConditionEffectIndex.Invincible),
                    new Taunt("Nooo! What is happening? How can I lose with such great power? Xil, help me."),
                    new TimedTransition(5000, "dying1")
                    ),
                new State("dying1",
                    new Flash(0xf20d0d, 10000000, 80000),
                    new ChangeSize(25, 250)
                    )
                ),
            new Threshold(0.035,
                new ItemLoot("Wand of the Fallen", 0.004),
                new ItemLoot("Orb of Aether", 0.004),
                new ItemLoot("Wine Cellar Incantation", .01),
                new ItemLoot("Potion of Defense", 0.2),
                new ItemLoot("Potion of Defense", 0.4),
                new ItemLoot("Potion of Attack", 0.4),
                new ItemLoot("Potion of Dexterity", 0.4),
                new ItemLoot("Potion of Speed", 0.4),
                new ItemLoot("Potion of Wisdom", 0.4),
                new ItemLoot("Potion of Vitality", 0.4),

                new TierLoot(5, ItemType.Ring, 0.07),
                new TierLoot(5, ItemType.Ability, 0.05),
                new TierLoot(12, ItemType.Armor, 0.05),
                new TierLoot(11, ItemType.Armor, 0.07),
                new TierLoot(12, ItemType.Weapon, 0.05),
                new TierLoot(11, ItemType.Weapon, 0.07)
                )
            )

            .Init("Fire Power",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle"),
                    new State("shooting",
                        new Shoot(20, count: 6, fixedAngle: 0, rotateAngle: 10, coolDown: 600),
                        new TimedTransition(6000, "Idle")
                        )
                    )
            )
            .Init("Air Power",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle"),
                    new State("shooting",
                        new Shoot(20, count: 6, fixedAngle: 22, rotateAngle: 10, coolDown: 600),
                        new TimedTransition(6000, "Idle")
                        )
                    )
            )
            .Init("Water Power",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle"),
                    new State("shooting",
                        new Shoot(20, count: 6, fixedAngle: 69, rotateAngle: 10, coolDown: 600),
                        new TimedTransition(6000, "Idle")
                        )
                    )
            )
            .Init("Earth Power",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle"),
                    new State("shooting",
                        new Shoot(20, count: 3, fixedAngle: 121, rotateAngle: 10, coolDown: 600),
                        new TimedTransition(6000, "Idle")
                        )
                    )
            )
            .Init("chasingHorror",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("follow",
                        new Follow(1, 10, 0),
                        new PlayerWithinTransition(1, "suicide", true),
                        new TimedTransition(5000, "forreal")
                        ),
                    new State("suicide",
                        new Flash(0xffffff, 1000, 1),
                        new Shoot(20, 1, coolDownOffset: 1000),
                        new TimedTransition(1000, "forreal")
                        ),
                    new State("forreal",
                        new Suicide()
                        )
                    )
            )
            .Init("Water Elemental",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("walk",
                        new MoveTo(0.5f, 66.5f, 12.5f),
                        new TimedTransition(2500, "die")
                        ),
                    new State("die",
                        new Flash(0xffffff, 500, 3),
                        new TimedTransition(500, "forreal")
                        ),
                    new State("forreal",
                        new Suicide()
                        )
                    )
            )
            .Init("Air Elemental",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("walk",
                        new MoveTo(0.5f, 66.5f, 12.5f),
                        new TimedTransition(2500, "die")
                        ),
                    new State("die",
                        new Flash(0xffffff, 500, 3),
                        new TimedTransition(500, "forreal")
                        ),
                    new State("forreal",
                        new Suicide()
                        )
                    )
            )
            .Init("Fire Elemental",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("walk",
                        new MoveTo(0.5f, 66.5f, 12.5f),
                        new TimedTransition(2500, "die")
                        ),
                    new State("die",
                        new Flash(0xffffff, 500, 3),
                        new TimedTransition(500, "forreal")
                        ),
                    new State("forreal",
                        new Suicide()
                        )
                    )
            )
            .Init("Earth Elemental",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("walk",
                        new MoveTo(0.5f, 66.5f, 12.5f),
                        new TimedTransition(2500, "die")
                        ),
                    new State("die",
                        new Flash(0xffffff, 500, 3),
                        new TimedTransition(500, "forreal")
                        ),
                    new State("forreal",
                        new Suicide()
                        )
                    )
            )
            .Init("Corrupted Caster",
                new State(
                    new Shoot(8, 10, projectileIndex: 1, coolDown: 2000),
                    new Shoot(8, 1, projectileIndex: 0, coolDown: 750, predictive: 1),
                    new Follow(0.5, 8, 0.1f),
                    new Orbit(0.2, 1, 8)
                    )
            )
            .Init("Corrupted Bowman",
                new State(
                    new Wander(0.5),
                    new Follow(0.25, 10, 4),
                    new Shoot(10, 2, 10, coolDown: 1000),
                    new Shoot(10, 1, projectileIndex: 1, coolDown: 2000)
                    )
            )
            .Init("Corrupted Spearman",
                new State(
                    new Follow(0.75, 10, 0.1f),
                    new Shoot(10, 3, 10, coolDown: 1500),
                    new Shoot(10, 8, projectileIndex: 1, coolDown: 1000)
                    )
            )
            .Init("Mini Corrupted Armor",
                new State(
                    new Follow(0.65, 10, 0.1f),
                    new Wander(0.2),
                    new Shoot(6, 3, 20, coolDown: 1500)
                    )
            )
            .Init("Corrupted Armor",
                new State(
                    new State("Idle",
                        new PlayerWithinTransition(15, "yeet")
                        ),
                    new State("yeet",
                        new Reproduce("Mini Corrupted Armor", coolDown: 8000),
                        new Shoot(15, 1, coolDown: 250),
                        new Shoot(15, 8, projectileIndex: 1, coolDown: 600)
                        )
                    )
            )
            .Init("Corrupted Monk",
                new State(
                    new Follow(0.5, 10, 8),
                    new Wander(0.75),
                    new Shoot(7, 5, 10, coolDown: 3000)
                    )
            )
            .Init("Corrupted Spawn",
                new State(
                    new Shoot(10, 2, 20, coolDown: 750, predictive: 1),
                    new Follow(0.75, 10, 0.1f),
                    new Wander(0.2)
                    )
            )
            ;
    }
}

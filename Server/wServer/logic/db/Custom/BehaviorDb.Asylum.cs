#region
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
#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Asylum = () => Behav()

        .Init("BedlamGod",
            new State(
            new Reproduce("ChaosGuardian", coolDown: 10000, densityMax: 6, densityRadius: 40),

                //new Shoot(15, projectileIndex: 0, count: 1, coolDown: 600), //fire
                //new Shoot(15, projectileIndex: 1, count: 3, shootAngle: 20, coolDown: 1500), //Boomerang star
                //new Shoot(15, projectileIndex: 2, count: 2, shootAngle: 40, coolDown: 2000), //blade
                //new Shoot(15, projectileIndex: 3, count: 8, shootAngle: 45, fixedAngle:0, coolDown: 3000), //purple

                new State("minions",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new Spawn("ChaosGuardian", 4),
                    new Shoot(15, projectileIndex: 4, count: 18, shootAngle: 20, coolDown: 6000), //(360)
                    new Shoot(15, projectileIndex: 0, count: 1, coolDown: 600), //fire
                    new Shoot(15, projectileIndex: 3, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2500), //purple
                    new Shoot(15, projectileIndex: 1, count: 3, shootAngle: 15, coolDown: 5000), //Boomerang star
                    new EntityNotExistsTransition("ChaosGuardian", 40, "first")
                ),
                new State("first",
                    new Wander(0.3),
                    new Follow(0.05, range: 15),
                    new Shoot(15, projectileIndex: 0, count: 1, coolDown: 600), //fire
                    new Shoot(15, projectileIndex: 1, count: 3, shootAngle: 15, coolDown: 1500), //Boomerang star
                    new Shoot(15, projectileIndex: 2, count: 2, shootAngle: 40, coolDown: 2000), //blade
                    new Shoot(15, projectileIndex: 3, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2500), //purple
                    new HpLessTransition(0.1, "calm")
                ),
                new State("calm",
                    new Shoot(15, projectileIndex: 3, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2500), //purple
                    new HpLessTransition(0.075, "rage")
                ),
                new State("rage",
                    new Reproduce("Roach", coolDown: 500),
                    new Order(20, "ChaosGuardian", "rage"),
                    new Shoot(15, projectileIndex: 0, count: 1, coolDown: 600), //fire
                    new Shoot(15, projectileIndex: 1, count: 3, shootAngle: 15, coolDown: 850), //Boomerang star
                    new Shoot(15, projectileIndex: 2, count: 2, shootAngle: 40, coolDown: 2000), //blade
                    new Shoot(15, projectileIndex: 3, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2500) //purple
                )
            )
        )

        .Init("ChaosGuardian",
            new State(
                new HealEntity(40, "BedlamGod", 80, 7500),
                new State("first",
                    new Orbit(0.75, 3, 10, "BedlamGod"),
                    new Shoot(15, projectileIndex: 2, count: 1, coolDown: 1000), //blade
                    new Shoot(15, projectileIndex: 1, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2000) //purple
                ),
                new State("rage",
                    new Follow(0.8, 15, 1),
                    new Shoot(15, projectileIndex: 2, count: 1, coolDown: 1000), //blade
                    new Shoot(15, projectileIndex: 1, count: 8, shootAngle: 45, fixedAngle: 0, coolDown: 2000) //red
                )
            ),
            new ItemLoot("Health Potion", 0.5),
            new ItemLoot("Magic Potion", 0.5)

        )

        .Init("Asylum Wizzard",
                new State(
                    new Spawn("Wizzard Spawn", 5, 0, 200),
                    new State("pause",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(2000, "start_the_fun")
                        ),
                    new State("start_the_fun",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt("Its Time for you to...   DIE!!! >:D"),
                        new TimedTransition(1500, "Daisy_attack")
                        ),
                    new State("Daisy_attack",
                        new Prioritize(
                            new StayCloseToSpawn(0.3, 7),
                            new Wander(0.3)
                            ),
                        new State("Quadforce1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 0, coolDown: 300),
                            new TimedTransition(200, "Quadforce2")
                            ),
                        new State("Quadforce2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 15, coolDown: 300),
                            new TimedTransition(200, "Quadforce3")
                            ),
                        new State("Quadforce3",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 30, coolDown: 300),
                            new TimedTransition(200, "Quadforce4")
                            ),
                        new State("Quadforce4",
                            new Shoot(10, projectileIndex: 3, coolDown: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 300),
                            new TimedTransition(200, "Quadforce5")
                            ),
                        new State("Quadforce5",
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 60, coolDown: 300),
                            new TimedTransition(200, "Quadforce6")
                            ),
                        new State("Quadforce6",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 75, coolDown: 300),
                            new TimedTransition(200, "Quadforce7")
                            ),
                        new State("Quadforce7",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 90, coolDown: 300),
                            new TimedTransition(200, "Quadforce8")
                            ),
                        new State("Quadforce8",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Shoot(10, projectileIndex: 3, coolDown: 1000),
                            new Shoot(0, projectileIndex: 0, count: 4, shootAngle: 90, fixedAngle: 105, coolDown: 300),
                            new TimedTransition(200, "Quadforce1")
                            ),
                        new HpLessTransition(0.3, "Whoa_nelly"),
                        new TimedTransition(18000, "Warning")
                        ),
                    new State("Warning",
                        new Prioritize(
                            new StayCloseToSpawn(0.5, 7),
                            new Wander(0.5)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 15),
                        new Follow(0.4, 9, 2),
                        new TimedTransition(3000, "Summon_the_clones")
                        ),
                    new State("Summon_the_clones",
                        new Prioritize(
                            new StayCloseToSpawn(0.85, 7),
                            new Wander(0.85)
                            ),
                        new Shoot(10, projectileIndex: 0, coolDown: 1000),
                        new Spawn("Wizzard Clone", 4, 0, 200),
                        new TossObject("Wizzard Clone", 5, 0, 100000),
                        new TossObject("Wizzard Clone", 5, 240, 100000),
                        new TossObject("Wizzard Clone", 7, 60, 100000),
                        new TossObject("Wizzard Clone", 7, 300, 100000),
                        new State("invulnerable_clone",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(3000, "vulnerable_clone")
                            ),
                        new State("vulnerable_clone",
                            new TimedTransition(1200, "invulnerable_clone")
                            ),
                        new TimedTransition(16000, "Warning2")
                        ),
                    new State("Warning2",
                        new Prioritize(
                            new StayCloseToSpawn(0.85, 7),
                            new Wander(0.85)
                            ),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 25),
                        new TimedTransition(5000, "Whoa_nelly")
                        ),
                    new State("Whoa_nelly",
                        new Prioritize(
                            new StayCloseToSpawn(0.6, 7),
                            new Wander(0.6)
                            ),
                        new Shoot(10, projectileIndex: 3, count: 3, shootAngle: 120, coolDown: 900),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 40, coolDown: 1600,
                            coolDownOffset: 0),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 220, coolDown: 1600,
                            coolDownOffset: 0),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 130, coolDown: 1600,
                            coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 2, count: 3, shootAngle: 15, fixedAngle: 310, coolDown: 1600,
                            coolDownOffset: 800),
                        new State("invulnerable_whoa",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2600, "vulnerable_whoa")
                            ),
                        new State("vulnerable_whoa",
                            new TimedTransition(1200, "invulnerable_whoa")
                            ),
                        new TimedTransition(10000, "Absolutely_Massive")
                        ),
                    new State("Absolutely_Massive",
                        new ChangeSize(13, 260),
                        new Prioritize(
                            new StayCloseToSpawn(0.2, 7),
                            new Wander(0.2)
                            ),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 40, coolDown: 2000,
                            coolDownOffset: 400),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 60, coolDown: 2000,
                            coolDownOffset: 800),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 50, coolDown: 2000,
                            coolDownOffset: 1200),
                        new Shoot(10, projectileIndex: 1, count: 9, shootAngle: 40, fixedAngle: 70, coolDown: 2000,
                            coolDownOffset: 1600),
                        new State("invulnerable_mass",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new TimedTransition(2600, "vulnerable_mass")
                            ),
                        new State("vulnerable_mass",
                            new TimedTransition(1000, "invulnerable_mass")
                            ),
                        new TimedTransition(14000, "Start_over_again")
                        ),
                    new State("Start_over_again",
                        new ChangeSize(-20, 100),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xff00ff00, 0.2, 15),
                        new TimedTransition(3000, "Daisy_attack")
                        )
                    ),
                new Threshold(1,
                    new ItemLoot("Potion of Vitality", 1)
                ),
                new Threshold(0.015,
                    new TierLoot(2, ItemType.Potion, 0.07)
                    ),
                new Threshold(0.03,
                    new ItemLoot("Crystal Wand", 0.005),
                    new ItemLoot("Crystal Sword", 0.006)
                    )
            )
            .Init("Wizzard Clone",
                new State(
                    new Prioritize(
                        new StayCloseToSpawn(0.85, range: 5),
                        new Wander(0.85)
                        ),
                    new Shoot(10, coolDown: 1400),
                    new State("taunt",
                        new Taunt(0.09, "I am everywhere and nowhere!"),
                        new TimedTransition(1000, "no_taunt")
                        ),
                    new State("no_taunt",
                        new TimedTransition(1000, "taunt")
                        ),
                    new Decay(17000)
                    )
            )
            .Init("Wizzard Spawn",
                new State(
                    new State("change_position_fast",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Prioritize(
                            new StayCloseToSpawn(3.6, 12),
                            new Wander(3.6)
                            ),
                        new TimedTransition(800, "attack")
                        ),
                    new State("attack",
                        new Shoot(10, predictive: 0.3, coolDown: 500),
                        new State("keep_distance",
                            new Prioritize(
                                new StayCloseToSpawn(1, 12),
                                new Orbit(1, 9, target: "Asylum Wizzard", radiusVariance: 0)
                                ),
                            new TimedTransition(2000, "go_anywhere")
                            ),
                        new State("go_anywhere",
                            new Prioritize(
                                new StayCloseToSpawn(1, 12),
                                new Wander(1)
                                ),
                            new TimedTransition(2000, "keep_distance")
                            )
                        )
                    )
            )

            .Init("AsylumEye",
                new State(
                    new State("idle",
                        new PlayerWithinTransition(15, "Spiral1")
                        ),
                    new State("Spiral1",
                        new Shoot(0, projectileIndex: 0, count: 6, fixedAngle: 0, rotateAngle: 10, coolDown: 200),
                        new TimedTransition(9000, "phase2")
                        ),
                    new State("phase2",
                        new Shoot(30, projectileIndex: 0, count: 4, fixedAngle: 0, coolDown: 150),
                        new TossObject("AsylumMaggots", 5, 0, 100000),
                        new TossObject("AsylumMaggots", 5, 240, 100000),
                        new TossObject("AsylumMaggots", 7, 60, 100000),
                        new TossObject("AsylumMaggots", 7, 300, 100000),
                        new TossObject("AsylumMaggots", 5, 120, 100000),
                        new TossObject("AsylumMaggots", 7, 180, 100000),
                        new TimedTransition(7500, "Spiral1")
                        )
                    )
            )

            .Init("AsylumMaggots",
                new State(
                        new Shoot(10, predictive: 0.3, coolDown: 1500),
                        new Wander(0.8)
                    )
            )

            .Init("AsylumLootEye",
                new State(
                        new State("First",
                            new TossObject("AsylumLootBomb", 7, coolDown: 1500),
                            new Shoot(10, count: 16, projectileIndex: 0, fixedAngle: 0, coolDown: 500),
                            new TimedTransition(5000, "Second")
                            ),
                        new State("Second",
                           new TossObject("AsylumLootBomb", 7, coolDown: 2000),
                           new TimedTransition(2500, "First")

                    )
                )
            )
            .Init("AsylumLootBomb",
                new State(
                    new State("First",
                      new TimedTransition(1000, "Second")
                    ),
                    new State("Second",
                      new Shoot(16, 6),
                      new Suicide()
                   )
                )
            )
            .Init("AsylumGuard",
                new State(
                    new State("First",
                      new Wander(0.3),
                      new TossObject("AsylumBomb", 7, coolDown: 5000),
                      new Shoot(10, count: 2, projectileIndex: 0, shootAngle: 10, predictive: 0.3, coolDown: 500)
                )
            )
            )
            .Init("AsylumBomb",
                new State(
                    new State("First",
                      new TimedTransition(1000, "Second")
                    ),
                    new State("Second",
                      new Shoot(16, 6),
                      new Suicide()
                   )
                )
            )
            .Init("AsylumStatue",
                new State(
                    new State("First",
                      new Shoot(10, count: 1, projectileIndex: 0, coolDown: 1000),
                      new Shoot(10, count: 4, projectileIndex: 1, shootAngle: 90, coolDown: 800),
                      new Shoot(10, count: 5, projectileIndex: 2, shootAngle: 10, coolDown: 750)
                )
            )
            )
            .Init("Insane Patient",
                new State(
                    new Wander(0.8),
                    new Shoot(15, 1, projectileIndex: 0, coolDown: 1000, predictive: 0.2)
                )
            )
            .Init("Nurse",
                new State(
                    new State("first",
                        new Wander(0.4),
                        new Shoot(15, 1, projectileIndex: 1, coolDown: 400, predictive: 0.1),
                        new TimedTransition(5000, "second")
                    ),
                    new State("second",
                        new Wander(0.6),
                        new Shoot(15, 8, 45, projectileIndex: 1, fixedAngle: 0, coolDown: 1250),
                        new TimedTransition(7500, "first")
                    )
                )
            )
            .Init("Roach",
                new State(
                    new Follow(1, 10, 1, coolDown: 400),
                    new Shoot(15, count: 1, predictive: 0.4, coolDown: 250)
                )
            )
            .Init("Asylum Button",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle1",
                        new PlayerWithinTransition(6, "Idle2", true)
                    ),
                    new State("Idle2",
                        new Spawn("Asylum spawner", 1),
                        new PlayerWithinTransition(0.5, "Order", true)
                    ),
                    new State("Order",
                        new Order(5, "Asylum spawner", "int"),
                        new SetAltTexture(1),
                        new TimedTransition(0, "I am out")
                    ),
                    new State("I am out")
                )
            )
            .Init("Asylum spawner",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("Idle"),
                    new State("int",
                        new Order(8, "ADSU", "spawn"),
                        new Order(8, "ADSD", "spawn"),
                        new Order(8, "ADSR", "spawn"),
                        new Order(8, "ADSL", "spawn"),
                        new TimedTransition(100, "spawn1", true),
                        new TimedTransition(100, "spawn2", true),
                        new TimedTransition(100, "spawn3", true)
                    ),
                    new State("spawn1",
                        new TossObject("Insane Patient", 4, 45),
                        new TossObject("Insane Patient", 3, 220),
                        new TossObject("AsylumGuard", 6, 260),
                        new TossObject("shtrs Ice Adept", 4, 60),
                        new TossObject("Nurse", 5, 0),
                        new TossObject("Nurse", 5, 120),
                        new TossObject("Roach", 5, 280),
                        new TossObject("Roach", 5, 15),
                        new TossObject("Roach", 5, 135),
                        new TossObject("Roach", 5, 233),
                        new TimedTransition(10, "Idle2")
                    ),
                    new State("spawn2",
                        new TossObject("Insane Patient", 4, 45),
                        new TossObject("shtrs Fire Adept", 3, 120),
                        new TossObject("AsylumGuard", 6, 260),
                        new TossObject("AsylumGuard", 4, 60),
                        new TossObject("Nurse", 5, 0),
                        new TossObject("Nurse", 5, 180),
                        new TimedTransition(10, "Idle2")
                    ),
                    new State("spawn3",
                        new TossObject("Insane Patient", 4, 45),
                        new TossObject("Nurse", 3, 220),
                        new TossObject("AsylumGuard", 6, 260),
                        new TossObject("shtrs Ice Adept", 4, 60),
                        new TossObject("shtrs Ice Adept", 5, 0),
                        new TossObject("Nurse", 5, 180),
                        new TossObject("shtrs Stone Knight", 5, 120),
                        new TossObject("shtrs Stone Knight", 5, 280),
                        new TimedTransition(3000, "Idle2")
                    ),
                    new State("Idle2",
                        new EntitiesNotExistsTransition(10, "tosuicide", "Nurse", "shtrs Ice Adept", "AsylumGuard", "Insane Patient", "Roach", "shtrs Fire Adept", "shtrs Ice Adept", "shtrs Stone Knight")
                    ),
                    new State("tosuicide",
                        new TimedTransition(2500, "suicide")
                        ),
                    new State("suicide",
                        new Order(30, "ADSU", "say"),
                        new Order(30, "ADSD", "say"),
                        new Order(30, "ADSL", "say"),
                        new Order(30, "ADSR", "say"),
                        new Suicide()
                    )
                )
            )
            .Init("ADSU",
                new State(
                    new State("Idle"),
                    new State("spawn",
                        new TossObject("ADU", 1, 150, maxDensity: 1, densityRange: 6, tossInvis: false)
                        ),
                    new State("say",
                        new Taunt("Say 'U' if you want to go this way!"),
                        new PlayerTextTransition("removewall", "U")
                        ),
                    new State("removewall",
                        new Order(4, "ADU", "remove")
                        )
                )
            )
            .Init("ADU",
                new State(
                    new State("idle"),
                    new State("remove",
                        new ApplySetpiece("AsylumU"),
                        new Suicide()
                        )
                    )
            )
            .Init("ADSD",
                new State(
                    new State("Idle"),
                    new State("say"
                    )
                )
            )
            .Init("ADSL",
                new State(
                    new State("Idle"),
                    new State("say"
                    )
                )
            )
            .Init("ADSR",
                new State(
                    new State("Idle"),
                    new State("say"
                    )
                )
            )
            .Init("Asylum remover",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true)
                    )
            )
            ;
    }
}
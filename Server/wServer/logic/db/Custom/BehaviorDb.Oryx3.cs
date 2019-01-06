#region

using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Oryx3 = () => Behav()
        .Init("Oryx 2",
            new State("Transform",
                new State(
                    new PlayerWithinTransition(10, "Taunt1"),
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable)
                        ),
                        new State("Taunt1",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("you came too late"),
                            new TimedTransition(3000, "Taunt2")
                        ),
                        new State("Taunt2",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("My Plan will be a success"),
                            new TimedTransition(3000, "Taunt3")
                        ),
                        new State("Taunt3",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("I can feel the power overflowing"),
                            new TimedTransition(1000, "Transform1")
                ),
            new State("Transform1",
                new Transform("Oryx Evolve1")
                )
            )
            )
        .Init("Oryx Evolve1",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(1000, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx Evolve2")
                )
            )
            )
        .Init("Oryx Evolve2",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(1000, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx Evolve3")
                )
            )
            )
        .Init("Oryx Evolve3",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(800, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx Evolve4")
                )
            )
            )
        .Init("Oryx Evolve4",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(800, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx Evolve5")
                )
            )
            )
        .Init("Oryx Evolve5",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(600, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx Evolve6")
                )
            )
            )
        .Init("Oryx Evolve6",
            new State("Transform",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                new TimedTransition(600, "Transform2")
                ),
            new State("Transform2",
                new Transform("Oryx the Mad God 3")
                )
            )
            )
                .Init("Oryx the Mad God 3",
                new State(
                    new State("Taunts",
                        new DropPortalOnDeath("Portal of Cowardice", 1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new State("Idle",
                            new PlayerWithinTransition(10, "Taunt1")
                        ),
                        new State("Taunt1",
                            new Taunt("HAHAHAHAHAHA!!"),
                            new TimedTransition(3000, "Taunt2")
                        ),
                        new State("Taunt2",
                            new Taunt("My great plan will be a success!"),
                            new TimedTransition(3000, "Taunt3")
                        ),
                        new State("Taunt3",
                            new Taunt("No one can stop me!"),
                            new TimedTransition(3000, "Taunt4")
                        ),
                        new State("Taunt4",
                            new Taunt("Now, I will slaughter you into a million pieces."),
                            new TimedTransition(3000, "Taunt5")
                        ),
                        new State("Taunt5",
                            new Taunt("Your Strugle is worthless!"),
                            new TimedTransition(3000, "Taunt6")
                        ),
                        new State("Taunt6",
                            new Taunt("Prepare to die!"),
                            new TimedTransition(3000, "Attack1")
                        )
                    ),
                   new State("Attacks",
                        new State("Attack1",
                            new Wander(.05),
                            new Shoot(25, projectileIndex: 6, count: 20, shootAngle: 20, coolDown: 4000, coolDownOffset: 4000),
                            new Shoot(25, projectileIndex: 4, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 5, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 2, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 6, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 0, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 1, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 3, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                             new TossObject("Skeletal Knight2", 5, angle: 0, coolDown: 5000),
                             new Taunt(1, 8000, "Puny mortals! My {HP} HP will annihilate you!"),
                             new TimedTransition(25000, "nospawn"),
                            new HpLessTransition(.25, "Attack2")
                            ),
                        new State("nospawn",
                            new Wander(.05),
                            new Taunt(1, 8000, "Puny mortals! My {HP} HP will annihilate you!"),
                            new Shoot(25, projectileIndex: 6, count: 20, shootAngle: 20, coolDown: 4000, coolDownOffset: 4000),
                            new Shoot(25, projectileIndex: 4, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 5, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 2, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 6, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 0, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 1, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 3, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new EntityNotExistsTransition("Skeletal Knight2", 15, "Attack1"),
                            new HpLessTransition(.35, "Attack2")

                        ),
                         new State("Attack2",
                            new Wander(.05),
                            new Taunt("I must live on!"),
                            new Follow(.1, 15, 3),
                            new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!"),
                            new Shoot(25, projectileIndex: 6, count: 8, shootAngle: 45, coolDown: 2000, coolDownOffset: 2000),
                            new Shoot(25, projectileIndex: 6, count: 3, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new Shoot(25, projectileIndex: 2, count: 2, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new Shoot(25, projectileIndex: 4, count: 2, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new Shoot(25, projectileIndex: 5, count: 3, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new Shoot(25, projectileIndex: 3, count: 3, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new Shoot(25, projectileIndex: 0, count: 3, predictive: 0.2, shootAngle: 25, coolDown: 1000, coolDownOffset: 1000),
                            new TossObject("Skeletal Knight2", 5, angle: 0, coolDown: 5000),
                            new TimedTransition(25000, "nospawn2"),
                            new HpLessTransition(0.1, "Death")
                             ),
                         new State("nospawn2",
                            new Wander(.05),
                            new Follow(.1, 15, 3),
                            new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!"),
                            new Shoot(25, projectileIndex: 6, count: 20, shootAngle: 20, coolDown: 4000, coolDownOffset: 4000),
                            new Shoot(25, projectileIndex: 4, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 5, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 2, count: 2, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 6, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 0, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 1, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new Shoot(25, projectileIndex: 3, count: 3, predictive: 0.2, shootAngle: 15, coolDown: 1350, coolDownOffset: 1350),
                            new EntityNotExistsTransition("Skeletal Knight2", 15, "Attack2"),
                            new HpLessTransition(0.1, "Death")
                        ),
                        new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("HOW DID I FAIL TO WEAKLINGS!!"),
                            new TimedTransition(3000, "suicide")
                            ),
                        new State("suicide",
                            new Suicide()
                            )
        )
                    ),
                    new Threshold(0.05,
                    new ItemLoot("Potion of Vitality", 1),
                    new ItemLoot("Potion of Attack", 0.4),
                    new ItemLoot("Potion of Defense", 0.4),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new ItemLoot("Potion of Oryx", 0.05),
                    new TierLoot(11, ItemType.Weapon, 0.2),
                    new TierLoot(12, ItemType.Weapon, 0.1),
                    new TierLoot(13, ItemType.Weapon, 0.05),
                    new TierLoot(14, ItemType.Weapon, 0.01),
                    new TierLoot(5, ItemType.Ability, 0.2),
                    new TierLoot(6, ItemType.Ability, 0.1),
                    new TierLoot(7, ItemType.Ability, 0.05),
                    new TierLoot(8, ItemType.Ability, 0.01),
                    new TierLoot(12, ItemType.Armor, 0.2),
                    new TierLoot(13, ItemType.Armor, 0.1),
                    new TierLoot(14, ItemType.Armor, 0.05),
                    new TierLoot(15, ItemType.Armor, 0.01),
                    new TierLoot(5, ItemType.Ring, 0.15),
                    new TierLoot(6, ItemType.Ring, 0.05),
                    new TierLoot(7, ItemType.Ring, 0.01)
                        ),
                        new Threshold(0.20,
                            new ItemLoot("Potion of Maxy", 0.0001),
                            new ItemLoot("Amulet of Resurrection", 0.009)
                       )
                        )
                    .Init("Skeletal Knight",
                    new State(
                        new State("Start",
                            new TimedTransition(1000, "Attack")
                            ),
                        new State("Attack",
                            new Follow(.7, range: 1),
                            new Wander(0.1),
                            new Shoot(10, projectileIndex: 0, coolDown: 1000)
                            )
                            ),
                    new Threshold(0.50,
                        new ItemLoot("Potion of Defense", 0.05)
                        )
                        )
                    .Init("Skeletal Knight2",
                    new State(
                        new State("Start",
                            new TimedTransition(1000, "Attack")
                            ),
                        new State("Attack",
                            new Follow(.7, range: 1),
                            new Wander(0.1),
                            new Shoot(10, projectileIndex: 0, coolDown: 1000)
                            )
                            ),
                    new Threshold(0.50,
                        new ItemLoot("Potion of Defense", 0.05)
              )
            );
    }
}
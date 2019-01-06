#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using common.resources;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ ForbiddenJungle = () => Behav()
            .Init("Great Coil Snake",
                new State(
                    new DropPortalOnDeath("Forbidden Jungle Portal", 20),
                    new Prioritize(
                        new StayCloseToSpawn(0.8, 5),
                        new Wander(0.4)
                        ),
                    new State("Waiting",
                        new PlayerWithinTransition(15, "Attacking")
                        ),
                    new State("Attacking",
                        new Shoot(10, projectileIndex: 0, coolDown: 700, coolDownOffset: 600),
                        new Shoot(10, 10, 36, 1, coolDown: 2000),
                        new TossObject("Great Snake Egg", 4, 0, 5000, coolDownOffset: 0),
                        new TossObject("Great Snake Egg", 4, 90, 5000, 600),
                        new TossObject("Great Snake Egg", 4, 180, 5000, 1200),
                        new TossObject("Great Snake Egg", 4, 270, 5000, 1800),
                        new NoPlayerWithinTransition(30, "Waiting")
                        )
                    )
            )
            .Init("Great Snake Egg",
                new State(
                    new TransformOnDeath("Great Temple Snake", 1, 2),
                    new State("Wait",
                        new TimedTransition(2500, "Explode"),
                        new PlayerWithinTransition(2, "Explode")
                        ),
                    new State("Explode",
                        new Suicide()
                        )
                    )
            )
            .Init("Great Temple Snake",
                new State(
                    new Prioritize(
                        new Follow(0.6),
                        new Wander(0.4)
                        ),
                    new Shoot(10, 2, 7, 0, coolDown: 1000, coolDownOffset: 0),
                    new Shoot(10, 6, 60, 1, coolDown: 2000, coolDownOffset: 600)
                    )
            )
           .Init("Mask Hunter",
               new State(
                   new Follow(0.8, 10, 1, -1, 500),
                   new Wander(1),
                   new Shoot(10, count: 1, coolDown: 200)
                   )
            )
           .Init("Mask Warrior",
               new State(
                   new Shoot(10, count: 8, fixedAngle: 45, coolDown: 500),
                   new Wander(0.5),
                   new Follow(0.8, 10, 1, -1, 250)
                   )
            )
           .Init("Mask Shaman",
               new State(
                   new Shoot(10, count: 8, coolDown: 750),
                   new Wander(0.4)
                   )
            )
           .Init("Basilisk Baby",
               new State(
                   new Orbit(.7, 3, radiusVariance: 0.5),
                   new Shoot(10, count: 1, coolDown: 750)
                   )
            )
           .Init("Basilisk",
               new State(
                   new Wander(0.5),
                   new StayBack(0.5, 5),
                   new Shoot(10, count: 1, coolDown: 1000),
                   new Shoot(10, count: 1, projectileIndex: 1, coolDown: 500, coolDownOffset: 0),
                   new Shoot(10, count: 1, projectileIndex: 2, coolDown: 500, coolDownOffset: 50),
                   new Shoot(10, count: 1, projectileIndex: 3, coolDown: 500, coolDownOffset: 100)
                   )
            )
           .Init("Mixcoatl the Masked God",
               new State(
                   new State("First",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                       new TimedTransition(5000, "Second")
                   ),
                   new State("Second",
                       new Shoot(10, count: 8, fixedAngle: 45, coolDown: 1500),
                       
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 0, coolDown: 2000, coolDownOffset:0),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 45, coolDown: 2000, coolDownOffset: 250),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 90, coolDown: 2000, coolDownOffset: 500),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 135, coolDown: 2000, coolDownOffset: 750),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 180, coolDown: 2000, coolDownOffset: 1000),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 225, coolDown: 2000, coolDownOffset: 1250),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 270, coolDown: 2000, coolDownOffset: 1500),
                       new Shoot(10, 3, 10, projectileIndex: 1, fixedAngle: 315, coolDown: 2000, coolDownOffset: 1750),
                       new TimedTransition(10000, "Third")
                   ),
                   new State("Third",
                       new Shoot(10, projectileIndex: 2, count: 1, coolDown: 250),
                       new TimedTransition(10000, "Second")
                    )
                   ),
            new TierLoot(5, ItemType.Weapon, 0.05),
            new TierLoot(6, ItemType.Weapon, 0.03),
            new TierLoot(6, ItemType.Armor, 0.05),
            new ItemLoot("Staff of the Crystal Serpent", 0.2),
            new ItemLoot("Cracked Crystal Skull", 0.2),
            new ItemLoot("Robe of the Tlatoani", 0.2),
            new ItemLoot("Crystal Bone Ring", 0.2)
            )
            ;
    }
}

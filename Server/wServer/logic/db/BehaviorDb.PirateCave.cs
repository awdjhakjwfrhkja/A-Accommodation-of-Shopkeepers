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
        private _ PirateCave = () => Behav()
        .Init("Dreadstump the Pirate King",
            new State(
                new DropPortalOnDeath(target: "Portal of Cowardice", probability: 1), // probability: 1  means 100% chance so 0.25 means 25% chance and so on
                new State("Idle",
                    new PlayerWithinTransition(dist: 15, targetState: "Start")
                    ),
                new State("Start",
                    new StayCloseToSpawn(speed: 1, range: 7),
                    new Wander(speed: 0.3),
                    new Shoot(radius: 8, count: 1, projectileIndex: 1, coolDown: 2000, predictive: 0.9),
                    new Shoot(radius: 8, count: 1, projectileIndex: 0, coolDown: 2000, predictive: 0.9),
                    new Taunt(0.3, 7000, 
                        "Hah! I'll drink my rum out of your skull!",
                        "Eat cannonballs!",
                        "Arrrr..."
                        )
                    )
                ),
              new TierLoot(4, ItemType.Weapon, 0.01),
              new TierLoot(3, ItemType.Weapon, 0.05),
              new TierLoot(2, ItemType.Weapon, 0.15),
              new TierLoot(1, ItemType.Armor, 0.2),
              new TierLoot(2, ItemType.Armor, 0.1),
              new TierLoot(3, ItemType.Armor, 0.05),
              new TierLoot(4, ItemType.Armor, 0.01),
              new TierLoot(1, ItemType.Ring, 0.1),
              new ItemLoot("Pirate Rum", 0.01)
            )
        .Init("Pirate Lieutenant",
            new State(
                new Prioritize(
                    new Protect(speed: 0.4, protectee: "Dreadstump the Pirate King", protectionRange: 6),
                    new Wander(speed: 0.5),
                    new Follow(speed: 1, acquireRange: 6, range: 1, duration: -1, coolDown: 0)
                    ),
                new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                ),
            new TierLoot(3, ItemType.Weapon, 0.05),
            new TierLoot(2, ItemType.Weapon, 0.15),
            new TierLoot(1, ItemType.Armor, 0.2),
            new TierLoot(1, ItemType.Ring, 0.1)
            )
        .Init("Pirate Captain",
              new State(
                  new Prioritize(
                      new Protect(speed: 0.4, protectee: "Dreadstump the Pirate King", protectionRange: 6),
                      new Wander(speed: 0.5),
                      new Follow(speed: 1, acquireRange: 6, range: 1, duration: -1, coolDown: 0)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 ),
              new TierLoot(3, ItemType.Weapon, 0.05),
              new TierLoot(2, ItemType.Weapon, 0.15),
              new TierLoot(1, ItemType.Armor, 0.2),
              new TierLoot(1, ItemType.Ring, 0.1),
              new ItemLoot("Pirate Rum", 0.01)
          )
        .Init("Pirate Commander",
              new State(
                  new Prioritize(
                      new Protect(speed: 0.4, protectee: "Dreadstump the Pirate King", protectionRange: 6),
                      new Wander(speed: 0.5)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 ),
              new TierLoot(3, ItemType.Weapon, 0.05),
              new TierLoot(2, ItemType.Weapon, 0.15),
              new TierLoot(1, ItemType.Armor, 0.2),
              new TierLoot(1, ItemType.Ring, 0.1),
              new ItemLoot("Pirate Rum", 0.01)
          )
        .Init("Cave Pirate Brawler",
              new State(
                  new State("Something wong",
                      new Follow(speed: 1, acquireRange: 6, range: 1, duration: -1, coolDown: 0),
                      new Wander(speed: 0.3),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  ),
                  new ItemLoot("Health Potion", 0.2)
          )
        .Init("Cave Pirate Sailor",
              new State(
                  new State("booty",
                      new Wander(speed: 0.8),
                      new Follow(speed: 0.8, acquireRange: 6, range: 1, duration: -1, coolDown: 0),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  ),
                  new ItemLoot("Health Potion", 0.2)
            )
        .Init("Cave Pirate Cabin Boy",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.5)
                      )
                  ),
                  new TierLoot(1, ItemType.Weapon, 0.4)
          )
        .Init("Cave Pirate Macaw",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.5)
                      )
                  ),
                  new TierLoot(1, ItemType.Ability, 0.2)
          )
        .Init("Cave Pirate Moll",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.1)
                      )
                  ),
                  new TierLoot(1, ItemType.Ability, 0.2)
          )
        .Init("Cave Pirate Monkey",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.1)
                      )
                  ),
                  new TierLoot(1, ItemType.Ability, 0.2)
          )
        .Init("Cave Pirate Parrot",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.1)
                      )
                  ),
                  new TierLoot(1, ItemType.Ability, 0.2)
          )
        .Init("Cave Pirate Hunchback",
              new State(
                  new Prioritize(
                      new Wander(speed: 0.5)
                      )
                  ),
                  new TierLoot(1, ItemType.Ability, 0.2)
          )
        .Init("Cave Pirate Veteran",
              new State(
                  new State("yolo",
                      new Follow(speed: 1, acquireRange: 6, range: 1, duration: -1, coolDown: 0),
                      new Wander(speed: 0.8),
                      new Shoot(radius: 5, count: 1, projectileIndex: 0, coolDown: 1000)
                      )
                  ),
                  new ItemLoot("Health Potion", 0.2)
          )
        .Init("Pirate Admiral",
              new State(
                  new Prioritize(
                      new Protect(speed: 0.4, protectee: "Dreadstump the Pirate King", protectionRange: 6),
                      new Wander(speed: 0.5),
                      new Follow(speed: 1, acquireRange: 6, range: 1, duration: -1, coolDown: 0)
                      ),
                      new Shoot(radius: 7, projectileIndex: 0, predictive: 1, coolDown: 1500)
                 ),
              new TierLoot(3, ItemType.Weapon, 0.05),
              new TierLoot(2, ItemType.Weapon, 0.15),
              new TierLoot(1, ItemType.Armor, 0.2),
              new TierLoot(2, ItemType.Armor, 0.1),
              new TierLoot(1, ItemType.Ring, 0.1),
              new ItemLoot("Pirate Rum", 0.01)
            );
    }
}
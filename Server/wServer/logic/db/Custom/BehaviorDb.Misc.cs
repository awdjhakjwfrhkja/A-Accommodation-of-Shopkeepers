using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Misc = () => Behav()
            .Init("White Fountain",
                new State(
                    new HealPlayer(5, 1000, 100),
                    new HealPlayerMP(5, 1000, 20)
                    )
        )
        .Init("Quest Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new Flash(0xE2AC2D, 1, 4800),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                  ),
                new Threshold(1,
                    new TierLoot(10, ItemType.Weapon, 0.06),
                    new TierLoot(5, ItemType.Ability, 0.06),
                    new TierLoot(10, ItemType.Armor, 0.06),
                    new TierLoot(4, ItemType.Ring, 0.06),
                    new TierLoot(5, ItemType.Ring, 0.06),
                new Threshold(0.28,
                    new ItemLoot("Potion of Attack", 1),
                    new ItemLoot("Potion of Defense", 1),
                    new ItemLoot("Potion of Speed", 0.6),
                    new ItemLoot("Potion of Dexterity", 0.4),
                    new ItemLoot("Potion of Mana", 0.02),
                    new ItemLoot("Potion of Life", 0.01),
                    new ItemLoot("Potion of Vitality", 0.06),
                    new ItemLoot("Potion of Wisdom", 0.05),
                    new ItemLoot("Wand of the Bulwark", 0.001),
                    new ItemLoot("Staff of Extreme Prejudice", 0.001),
                    new ItemLoot("Cloak of the Planewalker", 0.01),
                    new ItemLoot("Demon Blade", 0.001),
                    new ItemLoot("Doom Bow", 0.001),
                    new ItemLoot("Void Blade", 0.001),
                    new ItemLoot("Murky Toxin", 0.001),
                    new ItemLoot("Conducting Wand", 0.001),
                    new ItemLoot("Scepter of Fulmination", 0.001),
                    new ItemLoot("Harlequin Armor", 0.001),
                    new ItemLoot("Prism of Dancing Swords", 0.001),
                    new ItemLoot("Plague Poison", 0.001),
                    new ItemLoot("Resurrected Warrior's Armor", 0.001),
                    new ItemLoot("Tome of Purification", 0.001),
                    new ItemLoot("Robe of the Mad Scientist", 0.001)
                    )
                )
            )
            .Init("Epic Quest Chest",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new Flash(0x5B1E99, 0, 4800),
                        new TimedTransition(5000, "UnsetEffect")
                    ),
                    new State("UnsetEffect")
                  ),
                new Threshold(0.1,
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.08),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06),
                new Threshold(0.32,
                    new ItemLoot("Potion of Attack", 0.5),
                    new ItemLoot("Potion of Defense", 0.5),
                    new ItemLoot("Potion of Speed", 0.6),
                    new ItemLoot("Potion of Dexterity", 0.4),
                    new ItemLoot("Potion of Mana", 0.2),
                    new ItemLoot("Potion of Life", 0.1),
                    new ItemLoot("Potion of Vitality", 0.6),
                    new ItemLoot("Potion of Wisdom", 0.05),
                    new ItemLoot("Doku No Ken", 0.01),
                    new ItemLoot("Pirate King's Cutlass", 0.001),
                    new ItemLoot("Ancient Stone Sword", 0.01),
                    new ItemLoot("Thousand Shot", 0.01),
                    new ItemLoot("Skull of Endless Torment", 0.01),
                    new ItemLoot("Wand of the Fallen", 0.01),
                    new ItemLoot("Water Dragon Silk Robe", 0.01),
                    new ItemLoot("Bracer of the Guardian", 0.01)
                    )
                )
            )
        .Init("Fake White Bag",
                new State(
                    new State("Idle",
                        new ConditionalEffect(ConditionEffectIndex.Invincible),
                        new TimedTransition(30000, "UnsetEffect")
                    ),
                    new State("UnsetEffect",
                        new Suicide()
                        )
                    )
            )
        .Init("Nexus Crier",
            new State(
                new State("Idle",
                new StayCloseToSpawn(speed: 0, range: 10),
                new PlayerWithinTransition(dist:15, targetState: "Text1")
                ),
                new State("Text1",
                new Taunt("Welcome to Darkness Dynasty"),
                new NoPlayerWithinTransition(dist: 15, targetState: "Idle"),
                new TimedTransition(time: 10000, targetState: "Text2")
                ),
                new State("Text2",
                new Taunt("Text 2"),
                new NoPlayerWithinTransition(dist: 15, targetState: "Idle"),
                new TimedTransition(time: 10000, targetState: "Text3")
                ),
                new State("Text3",
                new Taunt("Text 3"),
                new NoPlayerWithinTransition(dist: 15, targetState: "Idle"),
                new TimedTransition(time: 10000, targetState: "Text4")
                 ),
                new State("Text4",
                new Taunt("Text 4"),
                new NoPlayerWithinTransition(dist: 15, targetState: "Idle"),
                new TimedTransition(time: 10000, targetState: "Text1")
            )));
    }
}
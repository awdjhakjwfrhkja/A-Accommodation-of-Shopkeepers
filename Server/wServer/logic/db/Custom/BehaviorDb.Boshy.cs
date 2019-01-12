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
        private _ Boshy = () => Behav()
            .Init("Boshy",
            new State(
                new Taunt("It's Boshy Time!"),
                new State(
                        new Wander(0.3),
                        new AoeEffect(10, ConditionEffectIndex.ArmorBroken, 5000),
                        new Shoot(15, 9, 40, projectileIndex: 0, coolDown: 750, coolDownOffset: 1000),
                        new Shoot(15, 3, 10, projectileIndex: 1, coolDown: 500, coolDownOffset: 1000)
                   )
                 ),
                 new Threshold(0.005,
                    new ItemLoot("Greater Potion of Defense", 0.1),
                    new ItemLoot("Greater Potion of Dexterity", 0.1),
                    new ItemLoot("Greater Potion of Attack", 0.1),
                    new ItemLoot("Greater Potion of Wisdom", 0.1),
                    new ItemLoot("Greater Potion of Vitality", 0.1),
                    new ItemLoot("Greater Potion of Life", 0.1),
                    new ItemLoot("Greater Potion of Mana", 0.1),
                    new ItemLoot("Greater Potion of Speed", 0.1),
                    new ItemLoot("Potion of Defense", 0.5),
                    new ItemLoot("Potion of Dexterity", 0.5),
                    new ItemLoot("Potion of Attack", 0.5),
                    new ItemLoot("Potion of Wisdom", 0.5),
                    new ItemLoot("Potion of Vitality", 0.5),
                    new ItemLoot("Potion of Life", 0.5),
                    new ItemLoot("Potion of Mana", 0.5),
                    new ItemLoot("Potion of Speed", 0.5),
                    new ItemLoot("Boshy Gun", 0.0025)
                    )
            )
        ;
    }
}
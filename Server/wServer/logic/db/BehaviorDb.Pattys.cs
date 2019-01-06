using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wServer.realm;
using common;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;
using common.resources;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Pattys = () => Behav()
            .Init("St. Patricks Event",
                new State(
                    new DropPortalOnDeath("Rainbow Road", 1),
                    new Wander(3)
                    )
            )
            .Init("St. Patricks Event Chest",
                new State(
                    new Flash(0x09ff00, 2, 100),
                    new PlayerWithinTransition(5, "Inv"),
                    new State ("Inv",
                        new TimedTransition(1000000, "Dmg")
                    ),
                    new State("Dmg",
                        new Taunt(0.8, "Kill me to earn great rewards!!!")
                    )
                    ),
            new ItemLoot("Clover Bow", 0.1),
            new ItemLoot("Sword of the Rainbow's End", 0.1)
            );
    }
}
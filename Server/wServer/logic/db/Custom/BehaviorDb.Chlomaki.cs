using common.resources;
using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Chlomaki = () => Behav()
            .Init("Chlomaki",
              new State(
              new HpLessTransition(0.8, "torage1"),
                new State("first",
                    //new Reproduce("Goblen", 50, 6, 5000),
                    //new Wander(.3),
                    //new Shoot(30, 5, 10, 0, predictive: .5, coolDown: 750),
                    new Shoot(30, 3, rotateAngle: 18, projectileIndex: 1, fixedAngle: 0, coolDown: 250, coolDownOffset: 0)
                    ),
                new State("torage1",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(1),
                    new TimedTransition(1000, "torage2")
                ),
                new State("torage2",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(2),
                    new TimedTransition(1000, "torage3")
                ),
                new State("torage3",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new SetAltTexture(3),
                    new TimedTransition(1000, "rage")
                ),
                new State("rage",
                    new SetAltTexture(4),
                    new Taunt("NOW I'M MAD")
                )
            )
        )
        ;
    }
}
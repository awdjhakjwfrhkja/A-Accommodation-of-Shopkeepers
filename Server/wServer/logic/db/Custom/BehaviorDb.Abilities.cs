#region

using wServer.logic.behaviors;
using wServer.logic.transitions;
using common.resources;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Abilities = () => Behav()
            .Init("Marble Pillar",
                new State(
                    new ConditionalEffect(ConditionEffectIndex.Invincible, true),
                    new State("start",
                        new TimedTransition(4500, "disappear"),
                        new GivePlayersEffect(3, ConditionEffectIndex.Armored),
                        new GivePlayersEffect(3, ConditionEffectIndex.Damaging)
                    ),
                    new State("disappear",
                        new Suicide()
                        )
                    )

            );
    }
}
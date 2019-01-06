#region

using wServer.realm.entities;
using System.Linq;
using wServer.realm;
using common.resources;

#endregion

namespace wServer.logic.behaviors
{
    public class AoeEffect : Behavior
    {

        private readonly double range;
        private readonly ConditionEffectIndex effect;
        private readonly int effectDuration;

        public AoeEffect(double range, ConditionEffectIndex effect, int effectDuration)
        {
            this.range = (float)range;
            this.effect = effect;
            this.effectDuration = effectDuration;
        }


        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            Entity[] inRange = host.GetNearestEntities(range, null).ToArray();
            foreach (Player i in inRange)
            {
                i.ApplyConditionEffect(new ConditionEffect
                {
                    Effect = effect,
                    DurationMS = effectDuration
                });
                break;
            }
        }
    }
}
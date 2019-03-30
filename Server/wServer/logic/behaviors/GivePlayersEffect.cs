#region

using wServer.realm.entities;
using System.Linq;
using wServer.realm;
using common.resources;

#endregion

namespace wServer.logic.behaviors
{
    public class GivePlayersEffect : Behavior
    {

        private readonly double range;
        private readonly ConditionEffectIndex effect;
        private readonly short duration;

        public GivePlayersEffect(double range, ConditionEffectIndex effect, short duration = 500)
        {
            this.range = (float)range;
            this.effect = effect;
            this.duration = duration;
        }


        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            Entity[] inRange = host.GetNearestEntities(range, null).ToArray();
            foreach (Player i in inRange)
            {
                i.ApplyConditionEffect(new ConditionEffect
                {
                    Effect = effect,
                    DurationMS = duration
                });
                break;
            }
        }
    }
}
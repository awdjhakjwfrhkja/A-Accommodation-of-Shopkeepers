/*#region

using wServer.realm;
using wServer.realm.entities;

#endregion

namespace wServer.logic.behaviors
{
    public class SetAltTextureCycle : Behavior
    {
        private readonly int index1;
        private readonly int index2;
        private Cooldown coolDown;
        private readonly int coolDownOffset;

        public SetAltTextureCycle(
            int index1, 
            int index2, 
            Cooldown coolDown = new Cooldown(),
            int _coolDownOffset = 0)
        {
            this.index1 = index1;
            this.index2 = index2;
            this.coolDown = coolDown.Normalize();
            this.coolDownOffset = _coolDownOffset;
        }

        protected override void OnStateEntry(Entity host, RealmTime time, ref object state)
        {
            state = coolDownOffset;
        }

        protected override void TickCore(Entity host, RealmTime time, ref object state)
        {
            int cool = (int)state;

            if (cool <= 0)
            {
                if ((host as Enemy).AltTextureIndex != index1)
                {
                    (host as Enemy).AltTextureIndex = index1;
                }
                else
                {
                    (host as Enemy).AltTextureIndex = index2;
                }
                cool = coolDown.Next(Random);
            }
            else
                cool -= time.ElaspedMsDelta;

            state = cool;
        }
    }
}
*/
namespace Orion.GamePlay
{
    public struct EffectsDuration
    {
        public int LightingDuration;
        public int ShieldDuration;
        public int FireDuration;

        public EffectsDuration(int lightingDuration, int shieldDuration, int fireDuration)
        {
            LightingDuration = lightingDuration;
            ShieldDuration = shieldDuration;
            FireDuration = fireDuration;
        }
    }
}
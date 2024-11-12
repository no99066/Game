namespace Model
{
    public static class Config
    {
        public const float EnemySpeedOfMovement = 1.5f;
        public const float EnemyDamage = 0.01f;
        public const float EnemyHealth = 3f;

        public const float MinDistanceWithTarget = 0.8f;
        public const float MaxDistanceWithTarget = 1.2f;

        public const float HeroHealth = 120f;
        public const float CastleHealth = 200f;

        public const float GunfireDamage = 1f;
        public const float GunfireSpeed = 7f;

        public const int GolemScore = 15;

        public const float CountOfRestoreHealth = 50;
        public const float CountOfSpeedUp = 2;

        public const string HealthMessageException = "Object must extend constructor with parameter";
    }
}
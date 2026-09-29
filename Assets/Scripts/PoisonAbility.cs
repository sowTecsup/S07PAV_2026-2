public class PoisonAbility : BaseAbility
{
    public override void Execute()
    {
        Shoot(4f, StatusEffect.Poison, 5f);
        PlayFeedback();
    }
}

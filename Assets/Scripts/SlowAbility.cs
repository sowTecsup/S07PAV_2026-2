public class SlowAbility : BaseAbility
{
    public override void Execute()
    {
        Shoot(5f, StatusEffect.Slow, 4f);
        PlayFeedback();
    }
}

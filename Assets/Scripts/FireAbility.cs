public class FireAbility : BaseAbility
{
    public override void Execute()
    {
        Shoot(10f, StatusEffect.Burn, 3f);
        PlayFeedback();
    }
}

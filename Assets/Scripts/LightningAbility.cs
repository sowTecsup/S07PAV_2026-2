using MoreMountains.Feedbacks;

public class LightningAbility : BaseAbility
{
    public MMFeedbacks particlesFeedback;

    public override void Execute()
    {
        Shoot(20f, StatusEffect.Shock, 0f);
        PlayFeedback();
    }

    protected override void PlayFeedback()
    {
        base.PlayFeedback();
        particlesFeedback.PlayFeedbacks();
    }
}

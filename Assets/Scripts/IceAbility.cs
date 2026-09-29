using MoreMountains.Feedbacks;

public class IceAbility : BaseAbility
{
    public MMFeedbacks particlesFeedback;

    public override void Execute()
    {
        Shoot(6f, StatusEffect.Freeze, 2f);
        PlayFeedback();
    }

    protected override void PlayFeedback()
    {
        base.PlayFeedback();
        particlesFeedback.PlayFeedbacks();
    }
}

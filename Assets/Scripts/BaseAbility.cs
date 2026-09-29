using MoreMountains.Feedbacks;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Transform firePoint;
    public MMFeedbacks castFeedback;

    public abstract void Execute();

    protected virtual void PlayFeedback()
    {
        castFeedback.PlayFeedbacks();
    }

    protected void Shoot(float speed, StatusEffect effect, float duration)
    {
        Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        projectile.speed = speed;
        projectile.effect = effect;
        projectile.duration = duration;
    }
}

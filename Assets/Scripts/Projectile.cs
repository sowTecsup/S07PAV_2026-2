using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public StatusEffect effect;
    public float duration;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Dummy dummy = other.GetComponent<Dummy>();
        if (dummy == null) return;

        if (duration > 0) dummy.ApplyStatus(effect, duration);
        else dummy.ApplyStatus(effect);

        Destroy(gameObject);
    }
}

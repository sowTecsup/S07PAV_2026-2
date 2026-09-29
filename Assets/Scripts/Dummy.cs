using UnityEngine;

public class Dummy : MonoBehaviour
{
    public void ApplyStatus(StatusEffect effect)
    {
        Debug.Log("Dummy recibe " + effect);
    }

    public void ApplyStatus(StatusEffect effect, float duration)
    {
        Debug.Log("Dummy recibe " + effect + " durante " + duration + " s");
    }
}

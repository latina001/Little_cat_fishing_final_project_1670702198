using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    public string fishName;
    public int points;
    public float speed;

    public abstract void Swim();

}

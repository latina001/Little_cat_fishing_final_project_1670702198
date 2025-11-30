using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    [SerializeField] private string fishName;
    [SerializeField] private int points;
    [SerializeField] private float speed; 

    public string FishName => fishName;
    public int Points => points;
    public float Speed
    {
        get => speed;
        set => speed = value;  
    }

    public abstract void Swim();

    private void Update()
    {
        Swim();
    }
}

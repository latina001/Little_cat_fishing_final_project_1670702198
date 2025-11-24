using UnityEngine;

public class Goldfish : Fish
{
    void Start()
    {
        fishName = "Goldfish";
        points = 5;
        speed = 2f;
    }

    public override void Swim()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}

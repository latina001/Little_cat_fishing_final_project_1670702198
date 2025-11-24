using UnityEngine;

public class Salmon : Fish
{
    void Start()
    {
        fishName = "Salmon";
        points = 5;
        speed = 15f;
    }

    public override void Swim()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void Update()
    {
        Swim();
    }

    
}

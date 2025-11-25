using UnityEngine;

public class Mackerel : Fish
{
    void Start()
    {
        fishName = "Mackerel";
        points = 2;
        speed = 4f;
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
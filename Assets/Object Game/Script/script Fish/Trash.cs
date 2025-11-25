using UnityEngine;

public class Trash : Fish
{
    void Start()
    {
        fishName = "Old Boot";
        points = -3;
        speed = 2f;
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
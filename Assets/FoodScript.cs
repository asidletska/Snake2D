using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public Apple apple;
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GetComponentInParent<Apple>().NewApple();
    }
}

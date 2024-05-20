using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Snake snake;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            //Snake.Eat();
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}

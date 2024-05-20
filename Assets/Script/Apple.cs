using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject food;
    int height = 0;
    int width = 0;

    int sizeHeight = 5;

    void Start()
    {
        height = (int)(sizeHeight / 0.6f) - 1;
        width = (int)((Screen.width / (Screen.height / sizeHeight) - 0.3f) / 0.6f) - 1;

    }

    float timer = 0;
 
    void Update()
    {
        if (timer < 0) 
        {
            GenerateFruite();
            timer = height * width;
        }
        timer -=Time.deltaTime;
    }
    void GenerateFruite()
    {

    }
}

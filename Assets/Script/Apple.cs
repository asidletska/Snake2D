using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject food;
    int height = 0;
    int width = 0;

    int sizeHeight = 15;
    float speed = 1;
    void Start()
    {
        height = (int)(sizeHeight / 1.2f) - 1;
        width = (int)((Screen.width / (Screen.height / sizeHeight) - 0.6f) / 0.6f) - 1;

    }

    float timer = 0;
 
    void Update()
    {
        if (timer * speed < 0) 
        {
            if(GetComponentInChildren<FoodScript>() != null)
            {
                Destroy(GetComponentInChildren<FoodScript>().gameObject);
            }
            GenerateFruite();
            timer = width + height;
        }
        timer -=Time.deltaTime;
    }
    public void NewApple()
    {
        timer = -1;
    }
    void GenerateFruite()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        Instantiate(food, new Vector3 (x, y, 10), Quaternion.identity, transform);
    }
}

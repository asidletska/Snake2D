using UnityEngine;

public class Fence : MonoBehaviour
{
    float screenWidth;
    float screenHeight;
    public GameObject prefabBox;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 5;
        screenWidth = (Screen.width / (Screen.height / screenHeight)) - 1f;

        int x = (int)(screenWidth / 1f);
        int y = (int)(screenHeight / 1f);

        for (int i = 0; i < x; i++)
        {
            Instantiate(prefabBox, new Vector3(i*1f, y*1f, 0),Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



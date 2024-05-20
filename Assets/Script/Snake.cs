using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject prefabBody;
    public GameObject rotPrefab1;
    public GameObject rotPrefab2;
    float speed = 1;
    float screenWidth = 0;
    float screenHeight = 0;

    bool isEaten = false;
    int headRot = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = 5;
        screenWidth = Screen.width / (Screen.height / 30) - 0.6f;
        Move();
    }

    float timer = 1f;
    void Update()
    {
        if(timer * speed > 1)
        {
            Move();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    public void Move()
    {
        Head h = GetComponentInChildren<Head>();
        if (headRot == 0 && h.transform.position.x + 0.6f < screenWidth)
        {            
            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);

            h.transform.position = new Vector3(h.transform.position.x + 0.6f,
                                               h.transform.position.y,
                                               h.transform.position.z);
            MoveBody();
        }

        if (headRot == 90 && h.transform.position.y + 0.6f < screenHeight)
        {
            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);

            h.transform.position = new Vector3(h.transform.position.x,
                                               h.transform.position.y + 0.6f,
                                               h.transform.position.z);
            MoveBody();
        }

        if (headRot == 180 && h.transform.position.x - 0.6f <  screenHeight)
        {
            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);

            h.transform.position = new Vector3(h.transform.position.x - 0.6f,
                                               h.transform.position.y,
                                               h.transform.position.z);
            MoveBody();
        }

        if (headRot == 270 && h.transform.position.y - 0.6f <  screenHeight)
        {
            Instantiate(prefabBody, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);

            h.transform.position = new Vector3(h.transform.position.x,
                                               h.transform.position.y - 0.6f,
                                               h.transform.position.z);
            MoveBody();
        }
    }
    public void Eat()
    {
        isEaten = true;
    }
    void MoveBody()
    {
        if (!isEaten)
        {
            Body[] bb = GetComponentsInChildren<Body>();

            Tail t = GetComponentInChildren<Tail>();
            t.transform.rotation = bb[1].transform.rotation;
            t.transform.position = bb[0].transform.position;

            Destroy(bb[0].gameObject);
        }
        else
        {
            isEaten = false;
        }

    }

    public void Up()
    {
        timer = 0;
        if (headRot == 0 || headRot == 180)
        {
            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 90);

            if (headRot == 180)
            {
                Instantiate(rotPrefab1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            if (headRot == 0)
            {
                Instantiate(rotPrefab2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            headRot = 90;

            h.transform.position = new Vector3(h.transform.position.x,
                                   h.transform.position.y + 0.6f,
                                   h.transform.position.z);
            MoveBody();
        }
    }
    public void Down()
    {
        timer = 0;
        if (headRot == 0 || headRot == 180)
        {
            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 270);

            if (headRot == 0)
            {
                Instantiate(rotPrefab1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            if (headRot == 180)
            {
                Instantiate(rotPrefab2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            headRot = 270;

            h.transform.position = new Vector3(h.transform.position.x,
                                   h.transform.position.y - 0.6f,
                                   h.transform.position.z);
            MoveBody();
        }
    }
    public void Left()
    {
        timer = 0;
        if (headRot == 90 || headRot == 270)
        {
            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 180);

            if (headRot == 270)
            {
                Instantiate(rotPrefab1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            if (headRot == 90)
            {
                Instantiate(rotPrefab2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            headRot = 180;

            h.transform.position = new Vector3(h.transform.position.x - 0.6f,
                                   h.transform.position.y,
                                   h.transform.position.z);
            MoveBody();
        }
    }
    public void Right()
    {
        timer = 0;
        if (headRot == 90 || headRot == 270)
        {
            Head h = GetComponentInChildren<Head>();

            h.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (headRot == 90)
            {
                Instantiate(rotPrefab1, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            if (headRot == 270)
            {
                Instantiate(rotPrefab2, h.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            }
            headRot = 0;

            h.transform.position = new Vector3(h.transform.position.x + 0.6f,
                                   h.transform.position.y,
                                   h.transform.position.z);
            MoveBody();
        }
    }
}

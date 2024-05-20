using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeDemo : MonoBehaviour
{
    public GameObject prefabBody;
    // Start is called before the first frame update
    void Start()
    {
        Move();
    }
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            Move();
            timer = 1;
        }
        timer -= Time.deltaTime;
    }

    public void Move()
    {
        Head h = GetComponentInChildren<Head>();

        Instantiate(prefabBody, h.transform.position, Quaternion.identity, transform);

        h.transform.position = new Vector3(h.transform.position.x + 0.6f,
                                           h.transform.position.y,
                                           h.transform.position.z);
        Body[] bb = GetComponentsInChildren<Body>();
        Destroy(bb[0].gameObject);


        Tail t = GetComponentInChildren<Tail>();

        t.transform.position = bb[0].transform.position;




    }
}

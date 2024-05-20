using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public List<Transform> Tails;
    public float BodyDistance;
    public GameObject BodyPrefab;
    [Range(0f, 4f)]
    public float Speed;
    private Transform _transform;

    // Start is called before the first frame update
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);
        float angel = Input.GetAxis("Horizontal") * 4;
      //  _transform.Rotate(0.)
    }
    private void MoveSnake(Vector3 newPosition)
    {
        _transform.position = newPosition;
    }
}

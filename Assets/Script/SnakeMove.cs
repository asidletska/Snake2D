using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class SnakeMove : MonoBehaviour
{

    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public UnityEvent OnEat;
    [SerializeField] Text scoreText;
    private int score = 0;
    [SerializeField] Text bestScore;
    private int bestscore = 0;

    private void Start()
    {
        ResetState();

        if (PlayerPrefs.HasKey("snakeScore"))
        {
            bestscore = PlayerPrefs.GetInt("snakeScore");
        }
        else
        {
            bestscore = 0;
        }

        CheckScore();
    }
    private void CheckScore()
    {
        if (score > bestscore) 
        {           
            bestscore = score;
            scoreText.text = "SCORE: " + score.ToString();
            bestScore.text = "BEST SCORE: " + bestscore.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
    }
    private void FixedUpdate()
    {
        for(int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);

    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector3.zero;


        if (score > bestscore)
        {
            bestscore = score;
            PlayerPrefs.SetInt("snakeScore", bestscore);
        }
        score = 0;
        CheckScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            score++;
            CheckScore();   
            if (OnEat != null)
            {
                OnEat.Invoke();
            }
        }
        else if (other.tag == "Obstacles")
        {
            ResetState();

        }
    }
}

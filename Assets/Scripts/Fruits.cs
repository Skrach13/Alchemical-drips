using UnityEngine;

public class Fruits : MonoBehaviour
{
    [SerializeField] private Vector3[] _scaleFruits;
    [SerializeField] private Color[] _colorsFruits;
    [SerializeField] private float _powerTorque;

    [SerializeField] private SpriteRenderer _renderer;
    private int _indexFruits;
    private bool _creatorNewFruits;
    private Rigidbody2D _rigidbody2D;

    public int IndexFruits { get => _indexFruits; set => _indexFruits = value; }
    public bool CreatorNewFruits { get => _creatorNewFruits; set => _creatorNewFruits = value; }
    public Rigidbody2D Rigidbody2D { get => _rigidbody2D; private set => _rigidbody2D = value; }
    public SpriteRenderer Renderer { get => _renderer; set => _renderer = value; }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fr = collision.gameObject.GetComponent<Fruits>();
        if(fr != null)
        {
            if(fr.IndexFruits == _indexFruits)
            {
                if(fr.CreatorNewFruits == false)
                {
                    _creatorNewFruits = true;
                    Vector3 newPosition = Vector3.Lerp(transform.position, fr.transform.position, 0.5f);
                    Destroy(fr.gameObject);
                    var newFruit = Instantiate(gameObject);
                    newFruit.transform.position = newPosition;
                    newFruit.GetComponent<Fruits>().LevelUpFruits(IndexFruits + 1);
                    Destroy(gameObject);
                }
            }
        }

        Rigidbody2D.AddTorque(_powerTorque);    
    }

    public void SpawnFruits()
    {
        int index = Random.Range(0, _scaleFruits.Length);
        IndexFruits = index;
        _renderer.color = _colorsFruits[index];
        transform.localScale = _scaleFruits[index];
    }

    public void LevelUpFruits(int index)
    {
        if(index < _scaleFruits.Length)
        {
            IndexFruits = index;
            _renderer.color = _colorsFruits[index];
            transform.localScale = _scaleFruits[index];
            Debug.Log($"new fruits index {index}");
            Score.Instance.ScorePlayer += index;
        }
        else
        {
            Debug.Log($"Destroy {index}");
            Score.Instance.ScorePlayer += index * 2;

            Destroy(gameObject);
        }
    }
}

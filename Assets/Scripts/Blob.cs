using UnityEngine;

public class Blob : MonoBehaviour
{
    [SerializeField] private Vector3[] _scaleBlobs;
    [SerializeField] private Color[] _colorsBlobs;
    [SerializeField] private float _powerTorque;

    [SerializeField] private SpriteRenderer _renderer;
    private int _indexBlobs;
    private bool _creatorNewBlobs;
    private Rigidbody2D _rigidbody2D;

    public int IndexBlobs { get => _indexBlobs; set => _indexBlobs = value; }
    public bool CreatorNewBlobs { get => _creatorNewBlobs; set => _creatorNewBlobs = value; }
    public Rigidbody2D Rigidbody2D { get => _rigidbody2D; private set => _rigidbody2D = value; }
    public SpriteRenderer Renderer { get => _renderer; set => _renderer = value; }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fr = collision.gameObject.GetComponent<Blob>();
        if(fr != null)
        {
            if(fr.IndexBlobs == _indexBlobs)
            {
                if(fr.CreatorNewBlobs == false)
                {
                    _creatorNewBlobs = true;
                    Vector3 newPosition = Vector3.Lerp(transform.position, fr.transform.position, 0.5f);
                    Destroy(fr.gameObject);
                    var newBlob = Instantiate(gameObject, newPosition,Quaternion.identity);
                    //newFruit.transform.position = newPosition;
                    newBlob.GetComponent<Blob>().LevelUpBlobs(IndexBlobs + 1);
                    Destroy(gameObject);
                }
            }
        }

        Rigidbody2D.AddTorque(_powerTorque);    
    }

    public void SpawnBlob()
    {
        int index = Random.Range(0, _scaleBlobs.Length);
        IndexBlobs = index;
        _renderer.color = _colorsBlobs[index];
        transform.localScale = _scaleBlobs[index];
    }

    public void SpawnBlob(int maxLevelBlob)
    {
        int index = Random.Range(0, _scaleBlobs.Length);
        IndexBlobs = index;
        _renderer.color = _colorsBlobs[index];
        transform.localScale = _scaleBlobs[index];
    }

    public void LevelUpBlobs(int index)
    {
        if(index < _scaleBlobs.Length)
        {
            IndexBlobs = index;
            _renderer.color = _colorsBlobs[index];
            transform.localScale = _scaleBlobs[index];
            Debug.Log($"new blobs index {index}");
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

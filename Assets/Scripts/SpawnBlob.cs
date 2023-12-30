using UnityEngine;

public class SpawnBlob : MonoBehaviour
{
    [SerializeField] private Blob _blobPref;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parantBlob;
    [SerializeField] private SpawnArea _spawnArea;

    private Blob newBlob;
    private Vector3 prevPositionSpawn;
    private void Start()
    {
        SpawBlob();
        _spawnArea.OnSpawn += SpawnNewBlob;

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (newBlob != null)
            {
                newBlob.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                newBlob = null;
            }
        }

        if (newBlob != null)
        {
            if (prevPositionSpawn != transform.position)
            {
                prevPositionSpawn = transform.position;
                Vector3 newPosition = _spawnPoint.position - new Vector3(0, newBlob.Renderer.bounds.size.y / 2, 0);
                newBlob.transform.position = newPosition;
               // newfruit.transform.position = _spawnPoint.position;
            }
        }
    }
    private void OnDestroy()
    {
        _spawnArea.OnSpawn -= SpawnNewBlob;
    }

    private void SpawnNewBlob()
    {
        SpawBlob();
    }

    private void SpawBlob()
    {
        newBlob = Instantiate(_blobPref, _parantBlob);
        newBlob.SpawnBlob();
        Vector3 newPosition = _spawnPoint.position - new Vector3(0, newBlob.Renderer.bounds.size.y / 2, 0);
        newBlob.transform.position = newPosition;
    }
}

using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    [SerializeField] private Fruits _fruitPref;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parantFruits;
    [SerializeField] private SpawnArea _spawnArea;

    private Fruits newfruit;
    private Vector3 prevPositionSpawn;
    private void Start()
    {
        SpawFruits();
        _spawnArea.OnSpawn += SpawnNewFruits;

    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (newfruit != null)
            {
                newfruit.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                newfruit = null;
            }
        }
        if (newfruit != null)
        {
            if (prevPositionSpawn != transform.position)
            {
                prevPositionSpawn = transform.position;
                newfruit.transform.position = _spawnPoint.position;
            }
        }
    }
    private void OnDestroy()
    {
        _spawnArea.OnSpawn -= SpawnNewFruits;
    }

    private void SpawnNewFruits()
    {
        SpawFruits();
    }

    private void SpawFruits()
    {
        newfruit = Instantiate(_fruitPref, _parantFruits);
        newfruit.SpawnFruits();
        Vector3 newPosition = _spawnPoint.position - new Vector3(0, newfruit.Renderer.bounds.size.y / 2, 0);
        newfruit.transform.position = newPosition;
    }
}

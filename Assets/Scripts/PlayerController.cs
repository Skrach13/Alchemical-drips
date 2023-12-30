using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _scaleSpeed;

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            _transform.position = new Vector3(_transform.position.x + (Input.GetAxis("Horizontal") * _scaleSpeed), _transform.position.y, _transform.position.z);
        }
    }


}

using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public event Action OnSpawn;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"stay trigger ");
        OnSpawn?.Invoke();
    }
   
}

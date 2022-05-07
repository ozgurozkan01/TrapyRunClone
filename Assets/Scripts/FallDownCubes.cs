using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownCubes : MonoBehaviour
{
    [SerializeField] private GameObject obj1, obj2;
    private Collider _collider1, _collider2;
    
    // Start is called before the first frame update
    void Start()
    {
        if (obj1 != null)
            _collider1 = obj1.GetComponent<Collider>();
        
        if (obj2 != null)
            _collider2 = obj2.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_collider1.bounds.Intersects(_collider2.bounds))
        {
            obj1.AddComponent<Rigidbody>();
        }
    }
}

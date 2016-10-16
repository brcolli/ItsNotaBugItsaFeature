using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{

    [SerializeField] private float sensitivity = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sensitivity);
    }
}

using UnityEngine;
using System.Collections;

public class GrappleHook : MonoBehaviour {
    public Transform cam;
    private RaycastHit hit;
    private Rigidbody rb;
    private bool attatched = false;
    private float momentum;
    public float speed;
    private float step;
    private bool grounded_ = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit))
            {
                attatched = true;
                rb.isKinematic = true;
            }
            else
                attatched = false; rb.isKinematic = false;          
        }
        if (Input.GetMouseButtonUp(0))
        {
            attatched = false;
            rb.isKinematic = false;
            rb.velocity = cam.forward * momentum;
        }
        if (attatched)
        {
            momentum += Time.deltaTime * speed;
            step = momentum * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
        }
        if (!attatched && momentum >=0)
        {
            momentum -= Time.deltaTime * 5;
            step = 0;
        }
        if (grounded_ && momentum <=0)
        {
            momentum = 0;
            step = 0;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground") || collision.gameObject.tag.Equals("Wall"))
            grounded_ = true;
    }
}

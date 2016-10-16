using UnityEngine;
using System.Collections;

public class WallRun : MonoBehaviour
{
    private bool isWallR = false;
    private bool isWallL = false;
    private RaycastHit hitr;
    private RaycastHit hitl;
    private int jumpCount = 0;
    private Rigidbody rb;
    public float runTime = 0.5f;

    private bool grounded_ = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !grounded_ && jumpCount <= 1)
        {
            if (Physics.Raycast(transform.position, transform.right, out hitr, 1))
            {
                if (hitr.transform.tag == "Wall")
                {
                    isWallR = true;
                    isWallL = false;
                    jumpCount++;
                    rb.useGravity = false;
                    StartCoroutine(afterRun());
                    grounded_ = false;
                }
                if (Physics.Raycast(transform.position, transform.right, out hitr, 1))
                {
                    if (hitr.transform.tag == "Wall")
                    {
                        isWallL = true;
                        isWallR = false;
                        jumpCount++;
                        rb.useGravity = false;
                        StartCoroutine(afterRun());
                        grounded_ = false;
                    }
                }
            }
        }
    }
    IEnumerator afterRun()
    {
        yield return new WaitForSeconds(runTime);
        isWallR = false;
        isWallL = false;
        rb.useGravity = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            grounded_ = true;
    }
}
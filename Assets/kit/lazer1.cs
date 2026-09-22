using System.Threading;
using UnityEngine;

public class lazer1 : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;
        transform.rotation = cam.transform.rotation;
        transform.position = cam.transform.position + cam.transform.forward * 5;
        Destroy(gameObject, 0.5f);

    }

    void LateUpdate()
    {
        //transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("monster"))
        {
            Debug.Log("monster");
            Destroy(collision.gameObject);
        }
    }

}
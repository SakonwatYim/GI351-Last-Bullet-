using UnityEngine;

public class bullet_player : MonoBehaviour
{
    float speed = 50f;
    public Monster monster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, speed * Time.deltaTime))
        {
            if (hit.collider.CompareTag("monster"))
            {
                Destroy(hit.collider.gameObject);
                Destroy(gameObject);
            }
            if (hit.collider.CompareTag("WallY_under") || hit.collider.CompareTag("WallY_on") || hit.collider.CompareTag("WallX_left") || hit.collider.CompareTag("WallX_right"))
            {
                Destroy(gameObject);
            }
            

        }
    }
}

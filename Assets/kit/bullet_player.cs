using UnityEngine;

public class bullet_player : MonoBehaviour
{
    float speed = 120f;
    float speed_bullet = 50f;
    public player Player;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = FindFirstObjectByType<player>();
        damage = Player.damage;
    }

    // Update is called once per frame
    void Update()
    {

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, speed * Time.deltaTime))
        {
            if (hit.collider.CompareTag("monster"))
            {
                Monster monster = hit.collider.GetComponent<Monster>();
                damage = Player.damage;
                monster.health -= damage;
                if (monster.health <= 0)
                {
                    Destroy(hit.collider.gameObject);
                }
                Destroy(gameObject);
                
            }
            if (hit.collider.CompareTag("WallY_under") || hit.collider.CompareTag("WallY_on") || hit.collider.CompareTag("WallX_left") || hit.collider.CompareTag("WallX_right"))
            {
                Destroy(gameObject);
            }
        }
        transform.position += transform.forward * speed_bullet * Time.deltaTime;
    }
}

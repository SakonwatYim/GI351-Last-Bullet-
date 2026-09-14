using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Monster monster;
    public float speed = 30; 
    // Update is called once per frame
    void Update()
    {
        transform.position += monster.distance_direction.normalized * (100 * Time.deltaTime);
        if (Physics.Raycast(transform.position, monster.distance_direction, out RaycastHit shoot, speed *Time.deltaTime))
        {
            if (shoot.collider.CompareTag("Player"))
            {
                Destroy(monster.player);
                //√Õ∑”‡√◊ËÕßplayer
                monster.hasShoot = true;
                Destroy(gameObject);
            }
            if(shoot.collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
                monster.hasShoot = true;
            }
            if (shoot.collider.CompareTag("monster"))
            {
                Destroy(gameObject);
                monster.hasShoot = true;
            }
        }
     

       
    }
}
    
       
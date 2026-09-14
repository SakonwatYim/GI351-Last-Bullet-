using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Monster : MonoBehaviour
{
    public int Detection = 100;
    public float speed_monster = 10;
    public int max_Distance = 10;
    public int min_Distance = 2;
    public Transform firepoint;
    public GameObject player;
    public GameObject bullet;
    public float distance_player;
    Vector3 position_random;
     public Vector3 distance_direction;
   public bool hasShoot = true;

    Rigidbody rb;
    public void player_Distance()
    {
        //ต้องใช้Vector(Normalize)Normalize=ให้ระยะทางที่ห่างกันคือ1เหลือไว้แค่ทิศทาง      (ทำการหาส่วนต่าง)
        
            if (distance_player < Detection)
            {
                if (hasShoot == true)
                {
                    GameObject shoot = Instantiate(bullet,firepoint.position, Quaternion.identity);
                bullet bulletScript = shoot.GetComponent<bullet>();
                bulletScript.monster = this;
                hasShoot = false;


                }
            float z = Mathf.MoveTowards(transform.position.z, player.transform.position.z, 20 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x,transform.position.y,z);
            }

        
    }
    public void random_Position()
    {
        position_random = new Vector3(transform.position.x + Random.Range(min_Distance, max_Distance), transform.position.y, transform.position.z + Random.Range(min_Distance, max_Distance));
  
    }
    public void move()
    {       
        //ต่ำแหน่งปัจจุบัน,ต่ำแหน่งที่ต้องการ,ความเร็วที่ไป                                                  คูณทุกครั้งที่เคลื่อนที่
        transform.position = Vector3.MoveTowards(transform.position, position_random, speed_monster * Time.deltaTime);
        //หมุนตัว


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallY"))
        {
            position_random = new Vector3(transform.position.x + Random.Range(min_Distance, max_Distance), transform.position.y, transform.position.z - Random.Range(min_Distance, max_Distance));
        }
        if (collision.gameObject.CompareTag("WallX"))
        {
            position_random = new Vector3(transform.position.x - Random.Range(min_Distance, max_Distance), transform.position.y, transform.position.z + Random.Range(min_Distance, max_Distance));
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random_Position();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {   //เก็บสิ่งที่ชนไว้ในhit
        distance_player = Vector3.Distance(player.transform.position, transform.position);
        distance_direction = player.transform.position - transform.position;
        Debug.DrawRay(firepoint.position, distance_direction * Detection, Color.red);
        distance_direction.Normalize();
        if (distance_player <= Detection)
        {
           
            transform.LookAt(player.transform);
            //ตรวจว่าชชนอะไรบ้าง                                   ไว้เช็คว่าชนกับอะไร(ประกาศตัวแปรhitแล้วเอาไปเก็บไว้Physics.Raycast)
            if (Physics.Raycast(firepoint.position, distance_direction, out RaycastHit hit, 100))
            {
               // Debug.Log("raycastชนเพลย์เยอร์");
                if (hit.collider.CompareTag("Player"))
                {
                    player_Distance();
                }
            }
        }
      
          
            if (Vector3.Distance(transform.position, position_random) <=0.01)
             {
            rb.AddTorque(new Vector3(0, Random.Range(1, 20), 0));
            firepoint.rotation = transform.rotation;
            random_Position();
             }

        move();
            
    }
}

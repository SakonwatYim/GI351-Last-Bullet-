using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int speed_monster = 2;
    public int max_Distance = 5;
    public int min_Distance = 2;
    Vector3 position_x;


    
    public void random_Position()
    {
        position_x = new Vector3(Random.Range(min_Distance, max_Distance), transform.position.y, transform.position.z);
        return;
    }
    public void move()
    {                                           //ต่ำแหน่งปัจจุบัน,ต่ำแหน่งที่ต้องการ,ความเร็วที่ไป
        transform.position = Vector3.MoveTowards(transform.position, position_x, speed_monster);

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Wall"))
        {
            position_x = transform.position;
            random_Position();
            move();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        random_Position();
        move();
    }

    // Update is called once per frame
    void Update()
    {
        //คือหาส่วนต่างระหว่างสองอันนี้
      if(Vector3.Distance(transform.position, position_x) <=0.01)
        {
            random_Position();
        }
        move();
    }
}

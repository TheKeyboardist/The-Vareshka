using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int powerupID;
    void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6.0f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                if(powerupID==0)
                {
                    //enable triple shot here 
                    player.TripleShotPowerupOn();
                }
                else if(powerupID==1)
                {
                    //enable speed boost here
                    player.SpeedBoostPowerupOn();
                }
                else if (powerupID==2)
                {
                    //enable shield here
                    player.ShieldPowerOn();
                }
               
                
            }
            Destroy(this.gameObject);
        }
        
    }
}

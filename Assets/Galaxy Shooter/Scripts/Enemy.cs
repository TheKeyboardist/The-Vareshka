using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.5f;
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
	void Start ()
    {
        transform.position = new Vector3(Random.Range(-8.0f,6.0f), 7.44f, 0);
	}
	
	void Update ()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.54)
        {
            float randomX = Random.Range(-8f, 6f);
            transform.position = new Vector3(randomX, 7.44f, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player !=null)
            {
                player.Damage();
                Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }


            
        }
    }


}

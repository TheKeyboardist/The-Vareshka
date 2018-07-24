using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _EnmemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;

	void Start ()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
	}

     IEnumerator SpawnEnemyRoutine()
     {
        while(true)
        {
            Instantiate(_EnmemyShipPrefab, new Vector3(Random.Range(-8.0f, 6.0f), 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

     }

    IEnumerator SpawnPowerupRoutine()
    {
        
        while(true)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-8f, 6f), 7.44f, 0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
        }
    }
}

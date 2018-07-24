using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public bool canTripleShot=false;
    public bool canSpeedBoost = false;
    public bool canShieldProtect = false;
    [SerializeField]
    private float _speedBoostEncrease = 1.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _TripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _fireRate = 0.25f; 
    private float _nextFire = 0.0f;
    [SerializeField]
    private int lives = 1;
    [SerializeField]
    private GameObject _explosionPrefab;

    private void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
    }
	
     


private void Update ()
    {
        Movement();
        Shoot();
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > _nextFire)
            {
                if (canTripleShot == true)
                {
                    Instantiate(_TripleShotPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
                }
                else
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.2f, 0), Quaternion.identity);
                _nextFire = Time.time + _fireRate;
            }
        }
    }
    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(canSpeedBoost == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * _speedBoostEncrease * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * _speedBoostEncrease *  verticalInput);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
        }
        

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }
        if (transform.position.x > 9.74f)
        {
            transform.position = new Vector3(-9.688f, transform.position.y, 0);
        }
        if (transform.position.x < -9.688f)
        {
            transform.position = new Vector3(9.74f, transform.position.y, 0);
        }
    }
    public void Damage()
    {
        if (canShieldProtect == true)
        {
            canShieldProtect = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        else
        {
            if (lives > 1)
            {
                lives--;
            }
            else
            {
                Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);

            }
        }
    }


    public void TripleShotPowerupOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    public void SpeedBoostPowerupOn()
    {
        canSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }
    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canSpeedBoost = false;
    }

    public void ShieldPowerOn()
    {
        canShieldProtect = true;
        _shieldGameObject.SetActive(true);
        StartCoroutine(ShieldPowerDownRoutine());
    }
    public IEnumerator ShieldPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _shieldGameObject.SetActive(false);
        canShieldProtect = false;
    }

}

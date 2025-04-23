using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 controllerInput;
    public float speed = 5f;
    Rigidbody rb;
    public List<GameObject> enemies;
    public GameObject gun;
    public GameObject bulletSpawn;
    public GameObject swordHandle;
    public GameObject bulletPrefab;
    LevelManager lm;
    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        rb = GetComponent<Rigidbody>();
        enemies = new List<GameObject>();
        InvokeRepeating("Shoot", 0, 2);
    }

    void Update()
    {
        controllerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        enemies = enemies.OrderBy(enemy => Vector3.Distance(enemy.transform.position, transform.position)).ToList();
        if (enemies.Count > 0 && Vector3.Distance(transform.position, enemies[0].transform.position) < 2f)
        {
            swordHandle.SetActive(true);
            swordHandle.transform.Rotate(0, 2f, 0);
        }
        else
        {
            swordHandle.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(controllerInput.x, 0, controllerInput.y);
        Vector3 targetPosition = transform.position + movementVector * Time.fixedDeltaTime * speed;
        rb.MovePosition(targetPosition);
    }
    void Shoot()
    {
        if(enemies.Count > 0)
        {
            gun.transform.LookAt(enemies[0].transform);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, gun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
            Debug.Log("Pif paf!");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            lm.ReducePlayerHealth(5);
        }
    }
}

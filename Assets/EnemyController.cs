using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    public float speed = 4f;
    LevelManager lm;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PlayerWeapon"))
        {
            lm.AddPoints(1);
            Destroy(gameObject);
        }
    }
}

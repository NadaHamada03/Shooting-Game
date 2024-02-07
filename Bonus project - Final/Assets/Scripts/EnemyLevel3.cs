using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLevel3 : MonoBehaviour
{
    private float enemyspeed = 12f;
    public static int kills = 0;

    void Start()
    {
        UnityEngine.Debug.Log("Level 3");
        UnityEngine.Debug.Log(kills);
    }

    void Update()
    {
        transform.Translate(UnityEngine.Vector3.down * enemyspeed * Time.deltaTime);

        if (transform.position.y <= -7.5f)
        {
            transform.position = new UnityEngine.Vector3(UnityEngine.Random.Range(-9f, 9f), 7, 0);
        }

        CheckKills();
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Player player = Other.transform.GetComponent<Player>();
            player.Damage();
            Destroy(this.gameObject);
        }

        if (Other.tag == "Laser")
        {
            kills++;
            UnityEngine.Debug.Log(kills);
            Destroy(Other.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void CheckKills()
    {
        if (kills == 5)
        {
            UnityEngine.Debug.Log("You Won");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLevel2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _EnemyPrefab;

    private bool stopspawning = false;

    public Player _player;

    public GameOverScreen gameover;

    public bool StopSpawning
    {
        get
        {
            return stopspawning;
        }

        set
        {
            stopspawning = value;
        }
    }

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        CheckDeath();
    }

    IEnumerator SpawnRoutine()
    {
        for (int i = 0; i < 5; i++)
        {
            if (stopspawning == false)
            {
                UnityEngine.Vector3 PosToSpawn = new UnityEngine.Vector3(UnityEngine.Random.Range(-9f, 9f), 7, 0);

                GameObject newEnemy = Instantiate(_EnemyPrefab, PosToSpawn, UnityEngine.Quaternion.identity);

                yield return new WaitForSeconds(2.0f);

                CheckDeath();

            }

        }
    }

    public void CheckDeath()
    {
        if (_player._lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameover.Setup();
    }

}

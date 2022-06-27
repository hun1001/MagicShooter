using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoSingleton<EnemySpawnManager>
{
    private GameObject _ghoul = null;

    private List<GameObject> _enemyList = null;

    void Start()
    {
        _enemyList = new List<GameObject>();
        _ghoul = Resources.Load<GameObject>("Prefabs/Enemy/Ghoul");
        StartCoroutine(SpawnGhouls());
    }

    private IEnumerator GhoulPositionCheck()
    {
        while (true)
        {
            foreach (var ghoulTemp in _enemyList)
            {
                if (ghoulTemp.transform.position.x > 60 || ghoulTemp.transform.position.x < -70 || ghoulTemp.transform.position.z > 60 || ghoulTemp.transform.position.z < -75)
                {
                    GhoulDead(ghoulTemp);
                }
            }
            yield return new WaitForSeconds(30f);
        }
    }

    public void GhoulDead(GameObject deadObject)
    {
        _enemyList.Remove(deadObject);
        Destroy(deadObject);
    }

    private IEnumerator SpawnGhouls()
    {
        float coolTime = 0;
        while (true)
        {
            SpawnGhoul();
            coolTime = Random.Range(1f, 10f);
            yield return new WaitForSeconds(coolTime);
        }
    }

    private void SpawnGhoul()
    {
        GameObject ghoul = Instantiate(_ghoul, new Vector3(Random.Range(-70f, 60f), 0, Random.Range(-75f, 60f)), Quaternion.identity);
        _enemyList.Add(ghoul);
    }
}

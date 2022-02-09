using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    public int xPos;
    public int zPos;
    public int enemyList;
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    IEnumerator EnemySpawn(){
        while (enemyList < 10){
            xPos = Random.Range(1,50);
            zPos = Random.Range(1,31);
            int EnemyType = Random.Range(1,3);
            if(EnemyType == 1){
                Instantiate(ghost1, new Vector3(xPos,-6,zPos), Quaternion.identity);
            }
            else if(EnemyType == 2){
                Instantiate(ghost2, new Vector3(6,0,6), Quaternion.identity);
            }
            else {
                Instantiate(ghost3, new Vector3(6,0,6), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
            enemyList+=1;
        }
            
        }
}


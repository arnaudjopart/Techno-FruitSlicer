using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private SpawnPosition[] m_spawnPositionArray;
    [SerializeField] private GameObject[] m_fruitPrefabsArray;

    [SerializeField] float m_forceValue = 15;
    [SerializeField] private float m_spawnFrequencyInSecond = 1;
    [SerializeField] Transform m_countainer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_spawnFrequencyInSecond);
            Debug.Log("Spawn");
            var randomSpawnPositionIndex = Random.Range(0, m_spawnPositionArray.Length);
            var randomFruitIndex = Random.Range(0, m_fruitPrefabsArray.Length);

            var instance = Instantiate(m_fruitPrefabsArray[randomFruitIndex], m_spawnPositionArray[randomSpawnPositionIndex].transform.position,
                Quaternion.identity);
            instance.transform.parent = m_countainer;
            instance.GetComponent<Rigidbody>().AddForce(Vector3.up*m_forceValue,ForceMode.Impulse);
            instance.GetComponent<Rigidbody>().AddTorque(new Vector3(0,1,1),ForceMode.Impulse);
            instance.GetComponent<FruitController>().m_countainer = m_countainer;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

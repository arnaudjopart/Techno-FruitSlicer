using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform[] m_spawnPositionArray;
    [SerializeField] private GameObject[] m_fruitPrefabsArray;

    [SerializeField] float m_forceValue = 15;
    [SerializeField] private float m_spawnFrequencyInSecond = 1;
    [SerializeField] Transform m_container;
    [SerializeField] GameManager m_gameManager;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_spawnFrequencyInSecond);

            var randomSpawnPositionIndex = Random.Range(0, m_spawnPositionArray.Length);
            var randomFruitIndex = Random.Range(0, m_fruitPrefabsArray.Length);

            var instance = Instantiate(m_fruitPrefabsArray[randomFruitIndex], m_spawnPositionArray[randomSpawnPositionIndex].position,
                Quaternion.identity);
            instance.transform.parent = m_container;
            var rigidBody = instance.GetComponent<Rigidbody>();
            rigidBody.AddForce(m_spawnPositionArray[randomSpawnPositionIndex].up*m_forceValue,ForceMode.Impulse);
            rigidBody.AddTorque(new Vector3(0,1,1),ForceMode.Impulse);
            var collidable = instance.GetComponent<CollidableBase>();
            collidable.m_container = m_container;
            collidable.m_gameManager = m_gameManager;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

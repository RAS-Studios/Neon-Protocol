using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField] private GameObject enemiePrefab;
    [SerializeField] private Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("WaveManager lancé");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Zombie  créé");
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(
                enemiePrefab, 
                point.position, 
                Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

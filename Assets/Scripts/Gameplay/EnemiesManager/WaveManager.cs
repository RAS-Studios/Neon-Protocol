using UnityEngine;
using System.Collections;


public class WaveManager : MonoBehaviour
{
    private Transform joueurCible;
    [SerializeField] private GameObject enemiePrefab;
    [SerializeField] private Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("WaveManager lancé");
        StartCoroutine(RechercherJoueurEnBoucle());

    }

    IEnumerator RechercherJoueurEnBoucle()
    {
        // Tant que l'IA n'a pas trouvé de cible, elle cherche
        while (joueurCible == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

            if (playerObj != null)
            {
                // Récupère les informations du GameObject
                joueurCible = playerObj.transform;
                Debug.Log("IA : Joueur trouvé et ciblé !");
                StartCoroutine(spawnEnemies());
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }

    IEnumerator spawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Zombie créé");
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(
                enemiePrefab,
                point.position,
                Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

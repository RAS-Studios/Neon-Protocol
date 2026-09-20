using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemiesManager : MonoBehaviour
{
    private Transform joueurCible;
    private NavMeshAgent agent;

    private float tempsEntreRecherches = 1f; // Cherche le joueur toutes les secondes

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Pour récupérer le NavMeshAgent

        // Lance la recherche en boucle dès le début car sinon si je le recherche qu'une fois ensuite ça bloque car lorsque que la map est créer le joueur lui non
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
            }
            else
            {
                // Attend 1s avant de chercher à nouveau 
                yield return new WaitForSeconds(tempsEntreRecherches);
            }
        }
    }

    void Update()
    {
        if (joueurCible != null)
        {
            agent.SetDestination(joueurCible.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] float levelEndDelay = 8f;

    DeathHandler death;

    private void Awake()
    {
        death = FindObjectOfType<DeathHandler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(EndSession());
        }

        IEnumerator EndSession()
        {
            yield return new WaitForSeconds(levelEndDelay);
            death.EndGame();
        }
    }
}

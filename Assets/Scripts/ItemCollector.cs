using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{
    [SerializeField] Text coinsCounter;
    [SerializeField] AudioSource coinCollectSound;

    private int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinCollectSound.Play();
            Destroy(other.gameObject);
            coins++;
            coinsCounter.text = "Coins: " + coins;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Text _coinCountView;
    [SerializeField] private UnityEvent _reached;

    private int _receivedCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _receivedCoin++;
            _coinCountView.text = $"Coins: {_receivedCoin.ToString()}";
            _reached.Invoke();
            Destroy(collision.gameObject); 
        }
    }
}

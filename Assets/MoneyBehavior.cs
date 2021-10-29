using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBehavior : MonoBehaviour
{
    [SerializeField]
    private int money;


    private void Start()
    {
    }

    private void Update()
    {
        gameObject.GetComponent<Text>().text = money.ToString();
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
    }
}

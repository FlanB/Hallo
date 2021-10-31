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

    public int GetMoney()
    {
        return money;
    }

    public void AddMoney(int amount)
    {
        money += amount;
        StartCoroutine(greenFlash(gameObject.GetComponent<Text>()));
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
        StartCoroutine(redFlash(gameObject.GetComponent<Text>()));
    }

    private IEnumerator redFlash(Text other)
    {
        other.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        other.color = Color.black;
    }
    private IEnumerator greenFlash(Text other)
    {
        other.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        other.color = Color.black;
    }
}

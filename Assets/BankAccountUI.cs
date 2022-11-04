using System;
using UnityEngine;
using UnityEngine.UI;

public class BankAccountUI : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    [SerializeField] private Player _accountOwner;

    private void Start()
    {
        _accountOwner.BankAccount.OnMoneyChanged += AccountOwner_OnMoneyChanged;
    }

    private void AccountOwner_OnMoneyChanged(BankAccount bankAccount)
    {
        _moneyText.text = bankAccount.Money.ToString();
    }
}

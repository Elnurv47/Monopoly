using System;
using UnityEngine;

public class Player : Character
{
    public Land Land { get; set; }

    public BankAccount BankAccount { get; set; } = new BankAccount() { Money = 1000 };

    [SerializeField] private int _index;

    public void TryBuyPropertyOn(PropertyLand landToBuy)
    {
        Player landOwner = landToBuy.Owner;

        if (landOwner == null)
        {
            int level1PropertyPrice = landToBuy.PropertyPurchasePrices[1];
            BankAccount.Money -= level1PropertyPrice;
            landToBuy.SetOwner(this);
            return;
        }

        if (BankAccount.Money >= landToBuy.RentRate)
        {
            PayMoneyTo(landToBuy.RentRate, landOwner);
            landToBuy.SetOwner(this);
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }

    public void PayMoneyTo(int amount, Player playerToPay)
    {
        BankAccount.Money -= amount;
        playerToPay.BankAccount.Money += amount;
    }
}

public class BankAccount
{
    private int _money;
    public int Money 
    {
        get => _money;
        set
        {
            _money = value;
            OnMoneyChanged?.Invoke(this);
        }
    }

    public Action<BankAccount> OnMoneyChanged;
}

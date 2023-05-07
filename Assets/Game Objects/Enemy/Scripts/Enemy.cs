using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward;
    [SerializeField] int goldPenalty;

    Bank bank;

    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold()
    {
        if (bank == null) { return; }

        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null) { return; }

        bank.Withdraw(goldReward);
    }
}

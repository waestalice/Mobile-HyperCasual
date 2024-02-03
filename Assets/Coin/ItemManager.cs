using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using EBAC.Core.Singleton;

public class ItemManager : Singleton<ItemManager>
{
	public SOInt coins;
	public SOInt diamonds;
	public TextMeshProUGUI uiTextCoins;
	public TextMeshProUGUI uiTextDiamonds;

	private void Start()
	{
		Reset();
	}

	private void Reset()
	{
		coins.value = 0;
		UpdateUI();
	}

	public void AddCoins(int amount = 1)
	{
		coins.value += amount;
		UpdateUI();
	}

	public void AddDiamonds(int amount = 5)
	{
    diamonds.value += amount;
    UpdateUI();
	}

	private void UpdateUI()
	{
		uiTextCoins.text = "Moedas: " + coins.value;
		uiTextDiamonds.text = "Diamantes: " + diamonds.value;
	}
}

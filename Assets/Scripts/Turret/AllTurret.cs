using UnityEngine;
using System.Collections;

public class AllTurret : MonoBehaviour {

	public float maxArmor;
	public float currentArmor;
	public bool armorMaxed;
	public bool armorAvailable;
	private int armorLVL = 1;
	private int armorCost = 135;

	public float rateOfFire;
	public bool rateMaxed;
	public bool rateAvailable;
	private int rateLVL = 1;
	private int rateCost = 200;

	private float range;
	public bool rangeMaxed;
	public bool rangeAvailable;
	private int rangeLVL = 1;
	private int rangeCost = 160;

	public int lvl;
	public int maxLVL = 2;

	private GameManager gm;
	private GameObject gameManager;

	//Upgrade Menu
	public bool showUpgrades = false;
	private GameObject upgradeMenu;



	public int cost;
	public int lossOfGold;

	void Start()
	{
		armorAvailable = true;
		rangeAvailable = true;
		rateAvailable = true;

		currentArmor = maxArmor;
		lvl = 1;

		gameManager = GameObject.FindGameObjectWithTag("GameController");
		gm = gameManager.GetComponent<GameManager>();

		upgradeMenu = GameObject.FindWithTag("UpgradeMenu");
		upgradeMenu.SetActive(false);

		lossOfGold = 75;
	}

	void Update()
	{
		//Armor
		if(gm.totalGold <= armorCost)
		{
			armorAvailable = false;
		}
		else
		{
			armorAvailable = true;
		}

		//Range
		if(gm.totalGold <= rangeCost)
		{
			rangeAvailable = false;
		}
		else
		{
			rangeAvailable = true;
		}

		//Rate
		if(gm.totalGold <= rateCost)
		{
			rateAvailable = false;
		}
		else
		{
			rateAvailable = true;
		}

		if(currentArmor >= maxArmor)
		{
			currentArmor = maxArmor;
		}

		if(showUpgrades == true)
		{
			upgradeMenu.SetActive(true);
		}
		else if(showUpgrades == false)
		{
			upgradeMenu.SetActive(false);
		}

		if(armorLVL == 5)
		{
			armorMaxed = true;
			armorAvailable = false;
		}
		if(rangeLVL == 3)
		{
			rangeMaxed = true;
			rangeAvailable = true;
		}
		if(rateLVL == 3)
		{
			rateMaxed = true;
			rateAvailable = false;
		}

		if(armorMaxed && rangeMaxed && rateMaxed)
		{
			lvl += 1;

			if(lvl >= maxLVL)
			{
				lvl = maxLVL;
				//different model
			}
		}

	}

	void OnMouseDown()
	{
		showUpgrades = !showUpgrades;
	}

	public void UpgradeArmor()
	{
		if(armorAvailable)
		{
			maxArmor *= 1.15f;
			armorLVL += 1;
			currentArmor = maxArmor;

			gm.LoseGold(armorCost);
		}
	}

	public void UpgradeRateOfFire()
	{
		if(rateAvailable)
		{
			rateOfFire *= 1.12f;
			rateLVL += 1;

			gm.LoseGold(rateCost);
		}
	}

	public void UpgradeRange()
	{
		if(rangeAvailable)
		{
			range *= 1.12f;
			rangeLVL += 1;

			gm.LoseGold(rangeCost);
		}
	}

	public void RepairTurret()
	{
		if(currentArmor <= maxArmor)
		{
			currentArmor = maxArmor;
		}
	}

	public void TakeDamage(float dmg)
	{
		//Health decreases with damage done
		currentArmor -= dmg;
		
		//If the health of the Turret reaches zero. Destroy the Turret and lose Gold
		if(currentArmor <= 0)
		{	
			if(gm)
			{
				//Lose Gold
				gm.LoseGold(lossOfGold);
			}

			Death();
		}
	}
	
	void Death( )
	{
		Destroy(this.gameObject);
	}
}

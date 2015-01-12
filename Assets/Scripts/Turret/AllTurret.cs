using UnityEngine;
using System.Collections;

public class AllTurret : MonoBehaviour {

	public float maxArmor;
	public float currentArmor;
	public bool armorMaxed;
	public bool armorAvailable;
	private int armorLVL = 1;

	public float rateOfFire;
	public bool rateMaxed;
	public bool rateAvailable;
	private int rateLVL = 1;

	private float range;
	public bool rangeMaxed;
	public bool rangeAvailable;
	private int rangeLVL = 1;

	public int lvl;
	public string description;

	private GameManager gm;
	private GameObject gameManager;

	public bool showUpgrades = false;
	private GameObject upgradeMenu;

	public int lossOfGold;

	void Start()
	{
		currentArmor = maxArmor;
		lvl = 1;

		gameManager = GameObject.FindGameObjectWithTag("GameController");
		gm = gameManager.GetComponent<GameManager>();

		upgradeMenu = GameObject.FindWithTag("UpgradeMenu");

		lossOfGold = Random.Range(200, 250);
	}

	void Update()
	{
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
	}

	void OnMouseDown()
	{
		showUpgrades = !showUpgrades;
	}

	public void UpgradeArmor()
	{
		maxArmor *= 1.12f;
		armorLVL += 1;
	}

	public void UpgradeRateOfFire()
	{
		rateOfFire *= 1.12f;
		rateLVL += 1;
	}

	public void UpgradeRange()
	{
		range *= 1.12f;
		rangeLVL += 1;
	}

	public void TakeDamage(float dmg)
	{
		//Health decreases with damage done
		currentArmor -= dmg;
		
		//If the health of the Turret reaches zero. Destroy the Turret and lose Gold
		if(currentArmor <= 0)
		{	
			Death();

			if(gm)
			{
				//Lose Gold
				gm.LoseGold(lossOfGold);
			}
		}
	}
	
	void Death( )
	{
		Destroy(this.gameObject);
	}
}

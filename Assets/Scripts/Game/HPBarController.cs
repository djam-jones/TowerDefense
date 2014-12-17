using UnityEngine;
using System.Collections;

public class HPBarController : MonoBehaviour {

	private Vector3 target;
	private Camera maincamera;

	public Texture LifeBarBack;
	public Texture LifeBarFront;

	private float lifeRatio;
	private float barWidth;
	private float barHeight;
	private float lifeWidth;

	private EnemyStats enemy;

	void Start()
	{
		enemy = GetComponentInParent<EnemyStats>();

		maincamera = GameObject.Find("Main Camera").camera;

		barWidth = 45f;
		barHeight = 4.5f;
	}

	void Update()
	{
		if(enemy != null)
		{
			lifeRatio = enemy.currentHealth / enemy.maxHealth;
		}

		lifeWidth = lifeRatio * barWidth;
	}

	void OnGUI()
	{
		if(lifeRatio > 0 && lifeRatio < 150)
		{
			target = maincamera.WorldToScreenPoint(transform.position);

			GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 30), barWidth, barHeight), LifeBarBack);
			GUI.DrawTexture(new Rect(target.x - (barWidth / 2), Screen.height - (target.y + 30), lifeWidth, barHeight), LifeBarFront);
		}
	}

}

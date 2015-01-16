using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {

	public float duration = 3f;
	private Text text;

	void Start()
	{
		text = gameObject.GetComponent<Text>();
	}

	void Update()
	{
		if(Time.time > duration)
		{
			text.text = "";
		}

		Color color = text.color;
		float ratio = Time.time/duration;
		color.a = Mathf.Lerp(1, 0, ratio);
		text.color = color;

		if(text.text != "")
		{
			color.a = Mathf.Lerp(0, 1, 3);
		}
	}

}
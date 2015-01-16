using UnityEngine;
using System.Collections;

public class RandomizeSong : MonoBehaviour {

	public AudioClip[] menuSongs;

	void Update()
	{
		if(!audio.isPlaying)
		{
			PlayRandomSong();
		}
	}
	
	void PlayRandomSong()
	{
		audio.clip = menuSongs[Random.Range(0, menuSongs.Length)];
		audio.Play();
	}
}

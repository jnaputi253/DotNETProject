using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public static MusicManager instance = null;
	public AudioSource musicSource;

	private void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip) {
		musicSource.clip = clip;
		musicSource.Play ();
	}

	public void RandomizeSfx(AudioClip[] clips) {
		int random = Random.Range (0, clips.Length);
		musicSource.clip = clips [random];
		musicSource.Play ();
	}
}

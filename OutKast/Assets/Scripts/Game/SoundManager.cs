using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
	public AudioClip[] backgroundTracks;
	private AudioSource source;
	private string sceneName;
	static private SoundManager instance;

	void Start()
	{
		sceneName = SceneManager.GetActiveScene().name;
		source = GetComponent<AudioSource>();

		switch (sceneName)
		{
			case "PrototypeScene":
				ChooseTrack(0);
				break;
			case "MainMenu":
				ChooseTrack(0);
				break;
			case "LevelOne":
				ChooseTrack(1);
				break;
			case "LevelTwo":
				ChooseTrack(2);
				break;
			case "LevelThree":
				ChooseTrack(3);
				break;
		}

		source.Play();
	}

	public void ChooseTrack(int choice)
	{
		source.Stop();

		switch (choice)
		{
			case 0:
				source.clip = backgroundTracks[choice];
				break;
			case 1:
				source.clip = backgroundTracks[choice];
				break;
			case 2:
				source.clip = backgroundTracks[choice];
				break;
			case 3:
				source.clip = backgroundTracks[choice];
				break;
			case 4:
				source.clip = backgroundTracks[choice];
				break;
		}

		source.Play();
	}
}

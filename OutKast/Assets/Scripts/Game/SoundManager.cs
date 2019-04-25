using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{    
	public AudioClip[] backgroundTracks;
	public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource orbSfxSource;
	private string sceneName;
    static public SoundManager instance = null;

    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

	void Start()
	{
		sceneName = SceneManager.GetActiveScene().name;

		switch (sceneName)
		{			
			case "MainMenu":
				ChooseTrack(0);
				break;
			case "LevelOne":
				ChooseTrack(1);
				break;
			case "LevelTwo":
				ChooseTrack(2);
				break;
			// TODO: Get rid of these and change for production release
			case "LevelThree":
				ChooseTrack(3);
				break;
			case "LevelOneDraft":
				ChooseTrack(1);
				break;
			case "LevelTwoDraft":
				ChooseTrack(2);
				break;
			case "LevelThreeDraft":
				ChooseTrack(3);
				break;
		}

		musicSource.Play();
	}

	public void ChooseTrack(int choice)
	{
		musicSource.Stop();

		switch (choice)
		{
			case 0:
				musicSource.clip = backgroundTracks[choice];
				break;
			case 1:
				musicSource.clip = backgroundTracks[choice];
				break;
			case 2:
				musicSource.clip = backgroundTracks[choice];
				break;
			case 3:
				musicSource.clip = backgroundTracks[choice];
				break;
			case 4:
				musicSource.clip = backgroundTracks[choice];
				break;
		}

		musicSource.Play();
	}

    public void PlaySFX(AudioClip sfx)
    {
        sfxSource.clip = sfx;
        sfxSource.Play();
    }
    public void PlayOrbSFX(AudioClip sfx)
    {
        orbSfxSource.clip = sfx;
        orbSfxSource.Play();
    }
}

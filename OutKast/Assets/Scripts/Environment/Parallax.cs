using UnityEngine;

public class Parallax : MonoBehaviour
{
	public Transform[] backgrounds; // Array of all backgrounds amnd foregrounds to be parallaxed
	private float[] parallaxScales; // The proportion of the camera's movement to move the backgrounds by
	public float smoothing = 1f; // how smooth the parallax is going to be (make sure to set above 0)

	private Transform cam;
	private Vector3 previousCamPos;

	void Awake()
	{
		// setup the camera reference
		cam = Camera.main.transform;
	}

	void Start()
	{
		// the previous frame had the current frame's camera position
		previousCamPos = cam.position;

		// assigning corresponding parallaxScales
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++)
		{
			parallaxScales[i] = backgrounds[i].position.z * -1;
		}
	}

	void Update()
	{
		// for each background
		for (int i = 0; i < backgrounds.Length; i++)
		{
			// the parallax is the opposite of the camera movement because of the previous frame multiplied by the scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			// set a target x position which is the current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			// create a target position which is the backgrounds current position with its target x position
			Vector3 backgroundTargetPos =
				new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			// fade between current position and the target position using lerp
			backgrounds[i].position =
				Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// set the previousCamPos to the cameras position at the end of the frame
		previousCamPos = cam.position;
	}
}

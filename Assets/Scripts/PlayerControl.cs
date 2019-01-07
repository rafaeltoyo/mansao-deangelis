using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerBehaviour))]
public class PlayerControl : MonoBehaviour {
	public static PlayerControl intance;

	private PlayerBehaviour character;
	private bool jump;

	public static bool liberado;
	void Start()
	{
		intance = this;
		liberado = true;
	}
	void Awake()
	{
		character = GetComponent<PlayerBehaviour>();
	}
	
	void Update ()
	{
		//if (liberado) 
		//{
			// Read the jump input in Update so button presses aren't missed.
			#if CROSS_PLATFORM_INPUT
			if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
			#else
			if (Input.GetButtonDown("Jump")) jump = true;
			#endif
		//}
		
	}
	
	void FixedUpdate()
	{
		if (liberado) 
		{
			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl);
			#if CROSS_PLATFORM_INPUT
			float h = CrossPlatformInput.GetAxis("Horizontal");
			#else
			float h = Input.GetAxis("Horizontal");
			#endif
			
			// Pass all parameters to the character control script.
			character.Move( h, crouch , jump );
			
			// Reset the jump input once it has been used.
			jump = false;
		}
		else if (!liberado)
			character.Move( 0, false , false );
	}

	public static void ChangePlayerStats (bool stats) {
		PlayerControl.liberado = stats;
	}
}


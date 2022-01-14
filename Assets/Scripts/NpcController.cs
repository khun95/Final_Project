using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
	private float reachRange = 2f;

	private Animator anim;
	private Camera fpsCam;
	private GameObject player;
	private const string animBoolName = "isOpen";
	public GameObject panel;
	private bool playerEntered;
	private bool showInteractMsg;
	private GUIStyle guiStyle;
	private string msg;

	private int rayLayerMask;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		setupGui();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)     //player has collided with trigger
		{
			Debug.Log("trigger enter");
			playerEntered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)     //player has exited trigger
		{
			Debug.Log("trigger exit");
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;
		}
	}

	void Update()
	{
		if (playerEntered)
		{
			showInteractMsg = true;
			msg = getGuiMsg(true);
			if (!panel.activeSelf)
			{
				if (Input.GetKeyUp(KeyCode.Space))
				{
					panel.SetActive(true);
				}
			}
            else
            {
				showInteractMsg = false;
			}
        }
    }

	


	#region GUI Config

	//configure the style of the GUI
	private void setupGui()
	{
		guiStyle = new GUIStyle();
		guiStyle.fontSize = 20;
		guiStyle.fontStyle = FontStyle.Bold;
		guiStyle.normal.textColor = Color.white;
		msg = "Press Space to Open";
	}

	private string getGuiMsg(bool isOpen)
	{
		string rtnVal;
		if (!isOpen)
		{
			rtnVal = "Press Space to Close";
		}
		else
		{
			rtnVal = "Press Space to Open Weapon Shop";
		}

		return rtnVal;
	}

	void OnGUI()
	{
		if (showInteractMsg)  //show on-screen prompts to user for guide.
		{
			GUI.Label(new Rect(300, Screen.height - 50, 200, 50), msg, guiStyle);
		}
	}
	//End of GUI Config --------------
	#endregion
}

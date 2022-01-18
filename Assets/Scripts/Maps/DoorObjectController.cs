using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorObjectController : MonoBehaviour
{
	private float reachRange = 2f;

	private Animator anim;
	private Camera fpsCam;
	private GameObject player;
	private const string animBoolName = "isOpen";

	private bool playerEntered;
	private bool showInteractMsg;
	private GUIStyle guiStyle;
	private string msg;

	private int rayLayerMask;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fpsCam = Camera.main;
		anim = GetComponent<Animator>();
		anim.enabled = false;
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;
		setupGui();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			Debug.Log("trigger enter");
			playerEntered = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			Debug.Log("trigger exit");
			playerEntered = false;
			showInteractMsg = false;
		}
	}



	void Update()
	{
		if (playerEntered)
		{
			Vector3 rayOrigin = player.gameObject.transform.position;
			RaycastHit hit;
			Debug.DrawRay(rayOrigin, player.transform.forward * reachRange, Color.green);
			if (Physics.Raycast(rayOrigin, player.transform.forward, out hit, reachRange, rayLayerMask))
			{
				showInteractMsg = true;
				string animBoolNameNum = animBoolName;
				bool isOpen = anim.GetBool(animBoolNameNum);
				msg = getGuiMsg(isOpen);
				if (Input.GetKeyUp(KeyCode.Space))
				{
					anim.enabled = true;
					anim.SetBool(animBoolNameNum, !isOpen);
					msg = getGuiMsg(!isOpen);
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
		if (isOpen)
		{
			rtnVal = "Press Space to Close";
		}
		else
		{
			rtnVal = "Press Space to Open";
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

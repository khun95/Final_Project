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
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Player");
		fpsCam = Camera.main;

		//create AnimatorOverrideController to re-use animationController for sliding draws.
		anim = GetComponent<Animator>();
		//Debug.Log(anim);
		anim.enabled = false;  //disable animation states by default.  

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;

		//setup GUI style settings for user prompts
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

			//center point of viewport in World space.
			Vector3 rayOrigin = player.gameObject.transform.position;
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			Debug.DrawRay(rayOrigin, player.transform.forward * reachRange, Color.green);
			if (Physics.Raycast(rayOrigin, player.transform.forward, out hit, reachRange, rayLayerMask))
			{
				showInteractMsg = true;
				string animBoolNameNum = animBoolName;
				bool isOpen = anim.GetBool(animBoolNameNum);    //need current state for message.
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

	//is current gameObject equal to the gameObject of other.  check its parents
	//private bool isEqualToParent(Collider other, out AnimableObject draw)
	//{
	//	draw = null;
	//	bool rtnVal = false;
	//	try
	//	{
	//		int maxWalk = 6;
	//		draw = other.GetComponent<AnimableObject>();
	//		GameObject currentGO = other.gameObject;
	//		for(int i=0;i<maxWalk;i++)
	//		{
	//			if (currentGO.Equals(this.gameObject))
	//			{
	//				rtnVal = true;	
	//				if (draw== null)
	//					draw = currentGO.GetComponentInParent<AnimableObject>();

	//				break;			//exit loop early.
	//			}

	//			//not equal to if reached this far in loop. move to parent if exists.
	//			if (currentGO.transform.parent != null)		//is there a parent
	//			{
	//				currentGO = currentGO.transform.parent.gameObject;
	//			}
	//		}
	//	} 
	//	catch (System.Exception e)
	//	{
	//		Debug.Log(e.Message);
	//	}

	//	return rtnVal;

	//}


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

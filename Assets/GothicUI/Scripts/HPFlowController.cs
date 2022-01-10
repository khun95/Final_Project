using UnityEngine;
using UnityEngine.UI;

namespace CrusaderUI.Scripts
{
	public class HPFlowController : MonoBehaviour {
	
		private Material _material;
		[SerializeField] int ControllerNum;
		private void Start ()
		{
			_material = GetComponent<Image>().material;
		}

		public void SetValue(float value)
		{
			_material.SetFloat("_FillLevel", value);
		}

		private void Update()
		{
			if (ControllerNum == 1)
			{
				SetValue(PlayerController.hpRate);
			}
			else if(ControllerNum == 2)
            {
				//SetValue(PlayerController.staminaRate);
				_material.SetFloat("_FillLevel1", PlayerController.staminaRate);
				_material.SetFloat("_FillLevel", PlayerController.mpRate);

			}
        }
    }
}

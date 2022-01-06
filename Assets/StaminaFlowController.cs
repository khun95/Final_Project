using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaFlowController : MonoBehaviour
{
	// Start is called before the first frame update
	private Material _material;

	private void Start()
	{
		_material = GetComponent<Image>().material;
	}

	public void SetValue(float value)
	{
		_material.SetFloat("_FillLevel", value);
	}

	private void Update()
	{
		SetValue(PlayerController.staminaRate);
	}
}

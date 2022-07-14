using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeScreenshot : MonoBehaviour
{
	
	[SerializeField]
	GameObject blink;
	[SerializeField]
	GameObject canvas;
	bool notProcessing = true;
	public void TakeAShot()
	{
		if(notProcessing)
			StartCoroutine("CaptureIt");
	}

	IEnumerator CaptureIt()
	{
		notProcessing = false;
		canvas.SetActive(false);
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		ScreenCapture.CaptureScreenshot(fileName);
		yield return new WaitForEndOfFrame();
		Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);
		canvas.SetActive(true);
		notProcessing = true;
	}
}

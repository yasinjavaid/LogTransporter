using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
	public Text objectiveText;
    // Start is called before the first frame update
    void Start()
    {

		if (GameConstantLocal.Level == 0) {
			objectiveText.text = "Take the truck to fuel station and refill the fuel. Park it back to complete the levels. Watch out the land sliding";
		}
		else if (GameConstantLocal.Level == 1) {
			objectiveText.text = "Put the bundle of logs in the truck";
		}
		else if (GameConstantLocal.Level == 2) {
			objectiveText.text = "Drive the truck to the finish point";
		}
		else if(GameConstantLocal.Level == 3){
			objectiveText.text = "Drive the truck to the finish point";
		}
			else if(GameConstantLocal.Level == 4){
			objectiveText.text = "Drive the truck to the finish point";
		}
		else if(GameConstantLocal.Level == 5){
			objectiveText.text = "Drive the truck to the finish point";
		}
			else if(GameConstantLocal.Level == 6){
			objectiveText.text = "Drive the truck to the finish point";
		}
			else if(GameConstantLocal.Level == 7){
			objectiveText.text = "Drive the truck to the finish point";
		}
			else if(GameConstantLocal.Level == 8){
			objectiveText.text = "Drive the truck to the finish point";
		}
			else if(GameConstantLocal.Level == 9){
			objectiveText.text = "Drive the truck to the finish point";
		}
//			else if(GameConstantLocal.Level == 10){
//			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 3500);
//		}else if(GameConstantLocal.Level == 11){
//			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 3800);
//		}else if(GameConstantLocal.Level == 12){
//			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 4200);
//		}else if(GameConstantLocal.Level == 13){
//			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 4500);
//		}else if(GameConstantLocal.Level == 14){
//			PlayerPrefs.SetInt ("Cash", PlayerPrefs.GetInt ("Cash") + 5000);
//		}   
    }

}

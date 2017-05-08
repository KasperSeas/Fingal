using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightModule : MonoBehaviour {
	
	// The spotlightGroups that are connected to this SpotlightModule

	public SpotlightGroup[] spotlightGroups;


	void Start () {
		// Initially find all controls on the SpotlightModule			
		findControls();
	}

	void Update () {
//		AllCtrl ();
//		XAxisCtrl ();
//		YAxisCtrl ();
//		ZAxisCtrl ();
			
	}

	// MARK: Find Controls
	// Looks for controls (if they exist) on the SpotlightModule
	void findControls(){
			
	}

		
		

	// MARK: Update Control Functions
	void AllCtrl(){
		// TODO: Beat Match
		if (Input.GetKey (KeyCode.LeftShift)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.ResetAll ();
			}
		}
	}


	// ----===== X Control =====----
	void XAxisCtrl(){
		// Symmetry Switch
		if (Input.GetKeyUp (KeyCode.Alpha1)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.x, true);
			}
		}
		if (Input.GetKeyUp (KeyCode.Alpha2)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.x, false);
			}
		}


		// Offset
		if (Input.GetKey (KeyCode.W)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.x, Change.increase);
			}
		}
		if (Input.GetKey (KeyCode.Q)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.x, Change.decrease);
			}
		}


		// Alt Flip
		if (Input.GetKeyUp (KeyCode.E)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.AltFlip (Axis.x);
			}	
		}

		// Oscillation Sin()
		if (Input.GetKey (KeyCode.S)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.x, Change.increase);
			}	
		}
		if (Input.GetKey (KeyCode.A)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.x, Change.decrease);
			}	
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Oscillate (Axis.x);
			}
		}
			

		// Manual Axis Change
		if (Input.GetKey (KeyCode.X)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.x, Direction.up);
			}
		}
		if (Input.GetKey (KeyCode.Z)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.x, Direction.down);
			}
		}
		if (Input.GetKey (KeyCode.C)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.ResetAxis (Axis.x);
			}
		}

	}



	// ----===== Y Control =====----
	void YAxisCtrl(){
		// Symmetry Switch
		if (Input.GetKeyUp (KeyCode.Alpha4)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.y, true);
			}
		}
		if (Input.GetKeyUp (KeyCode.Alpha5)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.y, false);
			}
		}


		// Offset
		if (Input.GetKey (KeyCode.T)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.y, Change.increase);
			}
		}
		if (Input.GetKey (KeyCode.R)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.y, Change.decrease);
			}
		}


		// Alt Flip
		if (Input.GetKeyUp (KeyCode.Y)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.AltFlip (Axis.y);
			}	
		}

		// Oscillation Sin()
		if (Input.GetKey (KeyCode.G)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.y, Change.increase);
			}	
		}
		if (Input.GetKey (KeyCode.F)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.y, Change.decrease);
			}	
		}
		if (Input.GetKeyUp (KeyCode.H)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Oscillate (Axis.y);
			}
		}


		// Manual Axis Change
		if (Input.GetKey (KeyCode.B)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.y, Direction.right);
			}
		}
		if (Input.GetKey (KeyCode.V)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.y, Direction.left);
			}
		}
		if (Input.GetKey (KeyCode.N)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.ResetAxis (Axis.y);
			}
		}

	}

	// ----===== Z Control =====----
	void ZAxisCtrl(){
		// Symmetry Switch
		if (Input.GetKeyUp (KeyCode.Alpha7)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.z, true);
			}
		}
		if (Input.GetKeyUp (KeyCode.Alpha8)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.SwitchSymmetry (Axis.z, false);
			}
		}


		// Offset
		if (Input.GetKey (KeyCode.I)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.z, Change.increase);
			}
		}
		if (Input.GetKey (KeyCode.U)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Offset (Axis.z, Change.decrease);
			}
		}


		// Alt Flip
		if (Input.GetKeyUp (KeyCode.O)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.AltFlip (Axis.z);
			}	
		}

		// Oscillation Sin()
		if (Input.GetKey (KeyCode.K)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.z, Change.increase);
			}	
		}
		if (Input.GetKey (KeyCode.J)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.OscillateSpeed (Axis.z, Change.decrease);
			}	
		}
		if (Input.GetKeyUp (KeyCode.L)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Oscillate (Axis.z);
			}
		}


		// Manual Axis Change
		if (Input.GetKey (KeyCode.Comma)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.z, Direction.right);
			}
		}
		if (Input.GetKey (KeyCode.M)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.Move (Axis.z, Direction.left);
			}
		}
		if (Input.GetKey (KeyCode.Period)) {
			foreach (SpotlightGroup sg in spotlightGroups) {
				sg.ResetAxis (Axis.z);
			}
		}

	}






		

}



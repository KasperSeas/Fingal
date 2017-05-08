using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 	The StrobeModule is responsible for setting the active mode for each StrobeLight
	for each LightGroup 
	The default StrobeModule has 4 mode controls:
		*Strobe Control
		*Brightness Control
		*Alternative Control
		*Cycle Control
*/
public class StrobeModule : MonoBehaviour {
	// The LightGroups that are connected to this StrobeModule
	public LightGroup[] lightGroups;

	// StrobeCtrl
	private ActionButton strobe_on_button; 		// Button: activates Strobe Mode
	private SpeedSlider strobe_speed_slider; 	// Slider: controls speed of strobe

	// BrightnessCtrl
	private ActionButton brightness_on_button; 	// Button: turns all lights on
	private ActionButton brightness_off_button; // Button: turns all lights off
	private SpeedSlider brightness_intensity_slider; // Slide: controls brightness of all lights

	// AltCtrl
	private ActionButton alt_on_button; 		// Button: activates Alternative Mode
	private SpeedSlider alt_speed_slider; 		// Slider: controls speed of alternating lights

	// CycleCtrl
	private ActionButton cycle_on_button; 		// Button: activates Cycle Mode
	private SpeedSlider cycle_speed_slider; 	// Slider: controls speed of movings lights
	private Switch cycle_dir_switch;			// Switch: switches directions of moving lights
	private Knob cycle_light_num_knob;			// Knob: controls number of moving lights evenly disbursed on LightGroup
	private Knob cycle_width_knob;				// Knob: controls the width of moving lights

	void Start () {
		// Initially find all controls on the StrobeModule
		findControls ();	
	}
	 
	void Update () {
		StrobeCtrl ();
		BrightnessCtrl ();
		AltCtrl ();
		CycleCtrl ();
	}

	// MARK: Find Controls
	// Looks for controls (if they exist) on the StrobeModule
	void findControls(){
		findStrobeControl ();
		findBrightnessControl ();
		findAltControl ();
		findCycleControl ();
	}
		
	void findStrobeControl(){ 
		// StrobeCtrl
		if(transform.FindChild ("StrobeCtrl") != null){
			Transform strobeCtrl = transform.FindChild ("StrobeCtrl");
			if(strobeCtrl.FindChild ("Active-Button") != null && strobeCtrl.FindChild ("Speed-Slider") != null){
				Transform button = strobeCtrl.FindChild ("Active-Button");
				Transform slider = strobeCtrl.FindChild ("Speed-Slider");
				// Assign widgets to components if found
				if(button.GetComponent<ActionButton>()) strobe_on_button = button.GetComponent<ActionButton>(); 
				if(slider.GetComponent<SpeedSlider>())strobe_speed_slider = slider.GetComponent<SpeedSlider>();	
			}
		}	
	}

	void findBrightnessControl(){ 
		// BrightnessCtrl
		if(transform.FindChild ("BrightnessCtrl") != null){
			Transform brightnessCtrl = transform.FindChild ("BrightnessCtrl");
			if(brightnessCtrl.FindChild ("All-On-Button") != null &&
			   brightnessCtrl.FindChild ("All-Off-Button") != null &&
			   brightnessCtrl.FindChild ("Slider") != null){
				Transform button1 = brightnessCtrl.FindChild ("All-On-Button");
				Transform button2 = brightnessCtrl.FindChild ("All-Off-Button");
				Transform slider = brightnessCtrl.FindChild ("Slider");
				// Assign widgets to components if found
				if(button1.GetComponent<ActionButton>()) brightness_on_button = button1.GetComponent<ActionButton>(); 
				if(button2.GetComponent<ActionButton>()) brightness_off_button = button2.GetComponent<ActionButton>();
				if(slider.GetComponent<SpeedSlider>()) brightness_intensity_slider = slider.GetComponent<SpeedSlider>();//TODO:FIX NAMING CONVENTION	
			}
		}	
	}

	void findAltControl(){ 
		// AltCtrl
		if(transform.FindChild ("AltCtrl") != null){
			Transform altCtrl = transform.FindChild ("AltCtrl");
			if(altCtrl.FindChild ("Active-Button") != null && altCtrl.FindChild ("Slider") != null){
				Transform button = altCtrl.FindChild ("Active-Button");
				Transform slider = altCtrl.FindChild ("Slider");
				// Assign widgets to components if found
				if(button.GetComponent<ActionButton>()) alt_on_button = button.GetComponent<ActionButton>(); 
				if(slider.GetComponent<SpeedSlider>()) alt_speed_slider = slider.GetComponent<SpeedSlider>();	
			}
		}	
	}

	void findCycleControl(){ 
		// CycleCtrl
		if(transform.FindChild ("CycleCtrl") != null){
			Transform cycleCtrl = transform.FindChild ("CycleCtrl");
			if(cycleCtrl.FindChild ("Active-Button") != null && cycleCtrl.FindChild ("Slider") != null &&
				cycleCtrl.FindChild ("Direction-Switch") != null && cycleCtrl.FindChild ("LightNum-Knob") &&
				cycleCtrl.FindChild ("Width-Knob") != null){
				Transform button1 = cycleCtrl.FindChild ("Active-Button");
				Transform slider = cycleCtrl.FindChild ("Slider");
				Transform switch1 = cycleCtrl.FindChild ("Direction-Switch");
				Transform knob1 = cycleCtrl.FindChild ("LightNum-Knob");
				Transform knob2 = cycleCtrl.FindChild ("Width-Knob");
				// Assign widgets to components if found
				if(button1.GetComponent<ActionButton>()) cycle_on_button = button1.GetComponent<ActionButton>(); 
				if(slider.GetComponent<SpeedSlider>()) cycle_speed_slider = slider.GetComponent<SpeedSlider>();//TODO:FIX NAMING CONVENTION	
				if(switch1.GetComponent<Switch>()) cycle_dir_switch = switch1.GetComponent<Switch>();
				if(knob1.GetComponent<Knob>()) cycle_light_num_knob = knob1.GetComponent<Knob>();
				if(knob2.GetComponent<Knob>()) cycle_width_knob = knob2.GetComponent<Knob>();
			}
		}	
	}


	// MARK: Update Control Functions
	void StrobeCtrl (){
		if (strobe_speed_slider == null || strobe_on_button == null) return;
		if(Input.GetKey(KeyCode.Alpha2)){
			if (strobe_speed_slider != null) {
				strobe_speed_slider.slideUp ();
				float speed = (1 - (strobe_speed_slider.getCurrentVal ())) / 10; // get current slider value (inverse)
				foreach (LightGroup lg in lightGroups) {
					lg.setStrobeSpeed (speed);
				}
			}
		}	
		if(Input.GetKey(KeyCode.W)){
			strobe_speed_slider.slideDown ();
			float speed = ( 1-(strobe_speed_slider.getCurrentVal ()) )/10; 
			foreach (LightGroup lg in lightGroups){
				lg.setStrobeSpeed (speed);
			}
		}

		if(Input.GetKey(KeyCode.S)){
			foreach (LightGroup lg in lightGroups){
				lg.startStrober ();
			}
			strobe_on_button.turnON ();
			strobe_speed_slider.getCurrentVal ();
		} else {
			foreach (LightGroup lg in lightGroups){
				lg.stopStrober ();
			}
			strobe_on_button.turnOFF();
		}
	}

	void BrightnessCtrl (){
		if (brightness_intensity_slider == null || brightness_on_button == null || brightness_off_button == null) return;
		if(Input.GetKey(KeyCode.Q)){
			brightness_intensity_slider.slideUp ();
			float brightness = brightness_intensity_slider.getCurrentVal ();
			foreach (LightGroup lg in lightGroups){
				lg.setBrightness (brightness);
			}
		}	
		if(Input.GetKey(KeyCode.A)){
			brightness_intensity_slider.slideDown ();
			float brightness = brightness_intensity_slider.getCurrentVal ();
			foreach (LightGroup lg in lightGroups){
				lg.setBrightness (brightness);
			}
		}
		if (Input.GetKey (KeyCode.Z)) {
			foreach (LightGroup lg in lightGroups){
				lg.allOn();
			}
			brightness_on_button.turnON ();
		} else {
			brightness_on_button.turnOFF ();
		}
		if (Input.GetKey (KeyCode.X)) {
			foreach (LightGroup lg in lightGroups){
				lg.allOff();
			}
			brightness_off_button.turnON ();
		} else {
			brightness_off_button.turnOFF ();
		}
	}

	void AltCtrl (){
		if (alt_speed_slider == null || alt_on_button == null) return;
		if (Input.GetKey (KeyCode.Alpha3)) {
			alt_speed_slider.slideUp ();
			float speed = 1 - (alt_speed_slider.getCurrentVal()); 
			foreach (LightGroup lg in lightGroups) {
				lg.setAltSpeed (speed);
			}
		}
		if(Input.GetKey(KeyCode.E)){
			alt_speed_slider.slideDown ();
			float speed = 1 - (alt_speed_slider.getCurrentVal()); 
			foreach (LightGroup lg in lightGroups){
				lg.setAltSpeed (speed);
			}
		}
		if(Input.GetKeyUp(KeyCode.D)){
			foreach (LightGroup lg in lightGroups){
				if (!lg.alt_on) {
					lg.startAlt ();	
					alt_on_button.turnON ();
				} else {
					lg.stopAlt ();
					alt_on_button.turnOFF ();
				}
			}
		} 

	}

	void CycleCtrl(){
		if (cycle_speed_slider == null || cycle_dir_switch == null || cycle_light_num_knob == null
		   || cycle_width_knob == null || cycle_on_button == null) return;
		if (Input.GetKey (KeyCode.Alpha4)) { // Cycle Speed
			cycle_speed_slider.slideUp ();
			float speed = 1 - (cycle_speed_slider.getCurrentVal()); 
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleSpeed (speed);
			}
		}
		if(Input.GetKey(KeyCode.R)){
			cycle_speed_slider.slideDown ();
			float speed = 1 - (cycle_speed_slider.getCurrentVal()); 
			foreach (LightGroup lg in lightGroups){
				lg.setCycleSpeed (speed);
			}
		}
		if (Input.GetKey (KeyCode.Alpha5)) { // Cycle Direction
			cycle_dir_switch.switchNeg ();
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleDirection (false);
			}
		}
		if(Input.GetKey(KeyCode.T)){
			cycle_dir_switch.switchPos ();
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleDirection (true);
			}
		}

		if (Input.GetKey (KeyCode.F)) { // Cycle Num of Lights
			cycle_light_num_knob.turnCounterClockwise (10);
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleLightNum(cycle_light_num_knob.getDividedVal(10));
			}
		}
		if(Input.GetKey(KeyCode.G)){
			cycle_light_num_knob.turnClockwise (10);	
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleLightNum(cycle_light_num_knob.getDividedVal(10));
			}
		}

		if (Input.GetKey (KeyCode.V)) { // Cycle Width
			cycle_width_knob.turnCounterClockwise (10);
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleWidth (cycle_width_knob.getDividedVal (10));
			}
		}
		if(Input.GetKey(KeyCode.B)){
			cycle_width_knob.turnClockwise (10);	
			foreach (LightGroup lg in lightGroups) {
				lg.setCycleWidth (cycle_width_knob.getDividedVal (10));
			}
		}
		if(Input.GetKeyUp(KeyCode.Space)){ // Cycle Activate
			foreach (LightGroup lg in lightGroups){
				if (!lg.cycle_on) {
					lg.startCycle ();	
					cycle_on_button.turnON ();
				} else {
					lg.stopCycle ();
					cycle_on_button.turnOFF ();
				}
			}
		} 	
	}

}

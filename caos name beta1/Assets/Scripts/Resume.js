var mainMenuSceneName : String;
 private var pauseEnabled = false;
 
 
 function Start(){
     pauseEnabled = false;
     Time.timeScale = 1;
     AudioListener.volume = 1;
 }
 
 function stop(){

     Time.timeScale = 0;
}
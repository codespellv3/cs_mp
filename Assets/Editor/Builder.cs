using System.IO;
using UnityEditor;
using System.Diagnostics;

class Builder {
    [MenuItem("CustomScripts/Build Linux")]
    static void buildLinux() {

        UnityEditor.BuildPlayerOptions buildPlayerOptions = new UnityEditor.BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"
                          };
        string dir = "builds/linuxClient";
        
        Directory.CreateDirectory(dir);
        
        buildPlayerOptions.locationPathName = dir + "/clientLinux.x86_64";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);        
     
    }
    [MenuItem("CustomScripts/Build Server")]    
    static void buildHeadless() {

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"
                          };
        string dir = "builds/linuxServer";
        
        Directory.CreateDirectory(dir);
                                  
        buildPlayerOptions.locationPathName = dir + "/headless.x86_64";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.options = BuildOptions.EnableHeadlessMode;

        BuildPipeline.BuildPlayer(buildPlayerOptions);        
     
    }
    [MenuItem("CustomScripts/Build Mac")]    
    static void buildMac() {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"
                          };
                          
        string dir = "builds/macClient";
        
        Directory.CreateDirectory(dir);
                                  
        buildPlayerOptions.locationPathName = dir + "/clientMac";
        buildPlayerOptions.target = BuildTarget.StandaloneOSX;
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);        
     
    }    

    [MenuItem("CustomScripts/Build Win64")]    
    static void buildWin64() {

        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/SampleScene.unity"
                          };
        string dir = "builds/win64Client";
        
        Directory.CreateDirectory(dir);
                                  
        buildPlayerOptions.locationPathName = dir + "/clientWin64.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildPipeline.BuildPlayer(buildPlayerOptions);        
     
    }
}



    

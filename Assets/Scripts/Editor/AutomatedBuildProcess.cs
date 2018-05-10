using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AutomatedBuildProcess {

    private static string windowsBuildFolderPath = "D:/C_Drive_Stuff/Users/gebha/GameDev/Photosynthesis_Build";

    public static void StartBuild()
    {
        List<string> enabledScenePathNames = new List<string>();
        foreach(var buildSettingsScene in EditorBuildSettings.scenes)
        {
            if(buildSettingsScene.enabled)
                enabledScenePathNames.Add(buildSettingsScene.path);
        }

        if(!Directory.Exists(windowsBuildFolderPath))
        {
            Directory.CreateDirectory(windowsBuildFolderPath);
        }

        string ExecutableDirectoryPath = windowsBuildFolderPath + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "/";

        if(!Directory.Exists(ExecutableDirectoryPath))
        {
            Directory.CreateDirectory(ExecutableDirectoryPath);
        }

        string windowsExecutableName = "Photosynthesis_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".exe";

        Debug.Log("Starting to make Windows Build");
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = enabledScenePathNames.ToArray();
        buildPlayerOptions.locationPathName = ExecutableDirectoryPath + windowsExecutableName;
        buildPlayerOptions.target = BuildTarget.StandaloneWindows;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}

using UnityEditor;
using System.Diagnostics;

public class GameBuildPipeline
{
    [MenuItem("MyTools/Windows Build With Postprocess")]
    public static void BuildGame_Win ()
    {

        // Get filename.
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "", "");
        string[] levels = new string[] { "Assets/Scenes/Scene01.unity", "Assets/Scenes/Scene02.unity" };

        // Build player.
        BuildPipeline.BuildPlayer(levels, path + "/BuiltGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // Copy a file from the project folder to the build folder, alongside the built game.
        //FileUtil.CopyFileOrDirectory("Assets/Version.txt", path + "Version.txt");

        // Run the game (Process class from System.Diagnostics).
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/BuiltGame.exe";
        proc.Start();


    }
}

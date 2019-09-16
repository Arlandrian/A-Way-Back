using UnityEngine;
using System.IO;

public class HandleTextFile {
    //[MenuItem("Tools/Write file")]
    public static void WriteString(string point) {
        string path = Application.dataPath+"/Resources/point.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path);
        writer.WriteLine(point);
        writer.Close();

    }

    
    public static string ReadString() {
        string path = Application.dataPath + "/Resources/point.txt";
        if (!File.Exists(path)) {
            File.Create(path);
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine("0 0");
            tw.Close();
        }
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        
        string  text = reader.ReadLine();
        Debug.Log(text);
        reader.Close();
        return text;
    }

}
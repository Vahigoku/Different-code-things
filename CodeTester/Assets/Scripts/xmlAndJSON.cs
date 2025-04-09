using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class xmlAndJSONth : MonoBehaviour
{
    private string aDirectoryPath;
    private string aTextFile;
    private string aXmlFile;
    private string aJsonFile;
    public List<Persons> folks = new List<Persons>()
    {
        new Persons("Lego Johnson", "5th of April 2002", 5, 4, 2002, "Yellow"),
        new Persons("Christian", "20/01/2004", 20, 1, 2004, "Blue"),
        new Persons("Vahid", "11/05/2004",11,05,2004, "Black"),
        new Persons("Asser", "12/01/1985",12,1,1985, "Red"),
        new Persons("Meron", "23/10/2003",23,10,2003, "Blue/Purple"),
        new Persons("God God", "1st of January 01 UT", 1, 1, 1,"Shulux")


    };
     Teams lego = new Teams();
    public void Awake()
    {
        aDirectoryPath = Application.persistentDataPath + "/Game_Data";
        aTextFile = aDirectoryPath + "dataOnPeople.txt";
        aXmlFile = aDirectoryPath + "dataOnPeople.xml";
        aJsonFile = aDirectoryPath + "dataOnPeople.json";

    }
    public void CreateDirectory()
    {
        if (Directory.Exists(aDirectoryPath))
        {
            Debug.Log("We already got a Directory at home!");
            Console.WriteLine("And for you smartypants out there, it even includes you! Why am I calling you smartypants? Because only a SmartyPants would be seeing this in their console!");
            return;
        }
        Directory.CreateDirectory(aDirectoryPath);
        Debug.Log("Directory constructed and built for usage!");
    }
    public void CreateTextfile()
    {
        if (File.Exists(aTextFile))
        {
            Debug.Log("Textfile exist mate...");
            return;

        }
        File.WriteAllText(aTextFile, "<TEXTFILE>n");
        Debug.Log("Man...");
    }

    public void ReadTextfile(string filename)
    {
        if (!File.Exists(aTextFile))
        {
            Debug.Log("not exist");
            return;
        }
        Debug.Log(File.ReadAllText(aTextFile));
        Debug.Log("Textfile is true, for sure");
    }

    void SerializeXml()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persons>));

        using (FileStream fStream = File.Create(aTextFile))
        {
            xmlSerializer.Serialize(fStream, folks);
            Debug.Log("doing ser, i guess, for xml");
        }
        Debug.Log("xml is ser");
    }
    void DeserializeXml()
    {
        if (File.Exists(aTextFile))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Persons>));
            using (FileStream fStream = File.OpenRead(aTextFile))
            {
                lego.SpecialOps = (List<Persons>)xmlSerializer.Deserialize(fStream);
                Debug.Log("doing de on xml");
            }
            Debug.Log("done doing de");
        }
    }
    void SerializeJson()
    {
        string jsonString = JsonUtility.ToJson(lego, true);
        using (StreamWriter sWriter = File.CreateText(aTextFile))
        {
            sWriter.WriteLine(jsonString);
            Debug.Log("ser json");
        }
        Debug.Log("Json is Ser");
    }

public void Start()
    {
        CreateDirectory();
        CreateTextfile();
        SerializeXml();
        DeserializeXml();
        SerializeJson();
        //Person("Jack", "11th of may, 2000", 11, 05, 2000, "Black");
        
    }
    /*public void Initialised()
    {
        CreateDirectory();
        CreateTextfile();
        ReadTextfile(aTextFile);
    }*/
    
}
[Serializable]
public class Persons
{
    private string personName;
    private string personBirthday;
    private int personBirthdayDate;
    private int personBirthdayMonth;
    private int personBirthdayYear;
    private string personFavColour;
    //maybe a randomly generated name and such some other time
    //public List<string> firstNames = new List<string>() { "Lenny", "Jerry", "Mary", "Shiru", "Ben", "Terresa", "Lara" };
    //public List<string> lastNames = new List<string>() { "Couper", "Sairyu", "Bøffensen", "Tjansen", "Fiddusen", "Tennyson", "Croft" };
    public int numbers;
    public Persons(string name, string birthday, int birthDate, int birthMonth, int birthYear, string favColour)
    {

        this.personName = name;
        this.personBirthday = birthday;
        this.personFavColour = favColour;
        this.personBirthdayDate = birthDate;
        this.personBirthdayMonth = birthMonth;
        this.personBirthdayYear = birthYear;
        Debug.LogFormat("Name: {0}| Birthday: {1} -> {2}/{3}/{4}| Favorite Colour: {5}|", name, birthday, birthDate, birthMonth, birthYear, favColour);
        
    }
    public Persons() { }
    
}
public class Teams
{
    public List<Persons> SpecialOps;
}
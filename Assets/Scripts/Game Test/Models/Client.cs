
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Client", menuName = "Clients/New Client")]
public class Client : ScriptableObject
{
    public Drink WantedDrink;
    public List<string> DialogueLines;
    public Sprite Sprite;
}

public class ClientsInLevel
{
    public List<Client> Clients;
    public static ClientsInLevel LoadClientsFromFile(string filename)
    {
        using (StreamReader r = new StreamReader(filename))
        {
            string json = r.ReadToEnd();
            ClientsInLevel cil = JsonConvert.DeserializeObject<ClientsInLevel>(json);
            return cil;
        }
    }
}

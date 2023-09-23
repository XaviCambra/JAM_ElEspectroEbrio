
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Client
{
    public string Name;
    public string Description;
    //TODO: todas estas listas pueden tener cosas que NO se quieran, así que hay que crear strcuts con propiedad objeto y un bool que dice si se quiere o no
    public List<IngredientOrder> WantedIngredients;
    public List<IngredientPropertyOrder> WantedIngredientProperties;
    public List<DrinkOrder> WantedDrinks;
    public List<string> DialogueLines;
    public string Sprite;
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

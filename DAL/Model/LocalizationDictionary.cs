namespace DAL.Model;

public class LocalizationDictionary
{
    
    public string Key { get; set; } 
    public string RU {  get; set; }
    public string EN { get; set; }
    public string IT { get; set; }

    public LocalizationDictionary()
    {
        
    }

    public LocalizationDictionary(string key, string ru, string en, string it)
    {
        Key = key;
        RU = ru;
        EN = en;
        IT = it;
    }

}

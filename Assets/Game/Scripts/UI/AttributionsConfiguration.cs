using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Configuration/Attributions Configuration",
    fileName = "New Attribution Configuration", order = 2)]
public class AttributionsConfiguration : ScriptableObject
{
    [field: SerializeField]
    public List<Attribution> Attributions { get; private set; }

    public string GetAttributionsString()
    {
        var builder = new StringBuilder();
        foreach (var attribution in Attributions)
        {
            builder.AppendLine(attribution.ToString());
        }
        
        return builder.ToString();
    }
}

[Serializable]
public struct Attribution
{
    public string AssetName;
    public string AssetLink;
    public string Author;
    public string AuthorLink;
    public string Licence;
    public string LicenceLink;
    public string Platform;
    public string Modifications;

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.Append(AssetName);
        builder.AppendLine($"[{AssetLink}]");
        builder.Append(Author);
        if(string.IsNullOrEmpty(AuthorLink) is false)
            builder.AppendLine($"[{AuthorLink}]");
        if(string.IsNullOrEmpty(Licence) is false)
            builder.AppendLine($"[{Licence}]");
        if(string.IsNullOrEmpty(LicenceLink) is false)
            builder.AppendLine($"[{LicenceLink}]");
        builder.AppendLine(Platform);
        
        if(string.IsNullOrEmpty(Modifications))
            return builder.ToString();
        
        builder.AppendLine(Modifications);
        return builder.ToString();
    }
}

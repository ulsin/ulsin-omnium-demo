using System.Text.Json.Serialization;

namespace OmniumApi.Models;

[JsonDerivedType(typeof(PosOrder), "posOrder")]
public class PosOrder : OrderBase
{
    public string PosId { get; set; } = string.Empty;
}
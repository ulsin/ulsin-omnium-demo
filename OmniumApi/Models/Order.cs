using System.Text.Json.Serialization;

namespace OmniumApi.Models;

[JsonDerivedType(typeof(Order), "order")]
public class Order : OrderBase;
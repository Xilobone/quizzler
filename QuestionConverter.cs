using System.Text.Json;
using System.Text.Json.Serialization;
using Quizzler.Models;

public class QuestionConverter : JsonConverter<Question>
{
    public override Question? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDoc.RootElement;

        if (!jsonObject.TryGetProperty("questionType", out var typeProperty))
            throw new JsonException("Missing 'questionType' discriminator property");

        var typeDiscriminator = typeProperty.GetString();

        return typeDiscriminator switch
        {
            "Open" => JsonSerializer.Deserialize<OpenQuestion>(jsonObject.GetRawText(), options),
            "MultipleChoice" => JsonSerializer.Deserialize<MultipleChoiceQuestion>(jsonObject.GetRawText(), options),
            "Binary" => JsonSerializer.Deserialize<BinaryQuestion>(jsonObject.GetRawText(), options),
            "Numeric" => JsonSerializer.Deserialize<NumericQuestion>(jsonObject.GetRawText(), options),
            _ => throw new JsonException($"Unknown questionType '{typeDiscriminator}'")
        };
    }

    public override void Write(Utf8JsonWriter writer, Question value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}

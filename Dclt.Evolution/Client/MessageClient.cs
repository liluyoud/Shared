using Dclt.Evolution.Contracts;
using Dclt.Evolution.Enums;
using Dclt.Evolution.Extensions;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Dclt.Evolution.Client;

public partial class EvolutionClient
{

    public async Task<SendTextResult?> SendText(string instance, string number, string text, bool linkPreview = false, bool mentionsEveryOne = false, string[]? mentioned = null)
    {
        var sendTextContract = new SendTextCreate()
        {
            Number = number.ToRemoteJid(),
            Text = text,
            LinkPreview = linkPreview,
            MentionsEveryOne = mentionsEveryOne,
            Mentioned = mentioned
        };

        var url = $"/message/sendText/{instance}";
        var json = JsonSerializer.Serialize(sendTextContract, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SendTextResult>(responseContent);
            return result;
        }
        return default;
    }

    public async Task<SendTextResult?> SendText(string number, string text)
    {
        if (Instance != null)
        {
            return await SendText(Instance, number, text);
        }
        return default;
    }

    public async Task<SendMediaResult?> SendMedia(string instance, string number, MediaType mediaType, MimeType mimeType, string caption, 
        string media, string filename, int? delay = null, bool? mentionsEveryOne = null,  string[]? mentioned = null)
    {
        var sendMediaContract = new SendMediaCreate()
        {
            Number = number.ToRemoteJid(),
            MediaType = mediaType.GetDescription(),
            MimeType = mimeType.GetDescription(),
            Caption = caption,
            Media = media,
            FileName = filename,
            Delay = delay,
            MentionsEveryOne = mentionsEveryOne,
            Mentioned = mentioned
        };

        var url = $"/message/sendMedia/{instance}";
        var json = JsonSerializer.Serialize(sendMediaContract, _jsonOptions);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(url, content);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SendMediaResult>(responseContent);
            return result;
        }
        return default;
    }

    public async Task<SendMediaResult?> SendMedia(string number, MimeType mimeType, string caption, string media, string filename)
    {
        if (Instance != null)
        {
            return await SendMedia(Instance, number, mimeType.GetMediaType(), mimeType, caption, media, filename);
        }
        return default;
    }

}

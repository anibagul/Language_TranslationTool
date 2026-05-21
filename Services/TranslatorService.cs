using System.Text;
using System.Text.Json;

namespace CodeAlpha_LanguageTranslationTool.Services
{
    public class TranslatorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TranslatorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> TranslateTextAsync(string text, string sourceLanguage, string targetLanguage)
        {
            string? endpoint = _configuration["TranslatorSettings:Endpoint"];

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                return "Translation API endpoint is missing in appsettings.json.";
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                return "Please enter text to translate.";
            }

            if (string.IsNullOrWhiteSpace(sourceLanguage))
            {
                sourceLanguage = "auto";
            }

            if (string.IsNullOrWhiteSpace(targetLanguage))
            {
                return "Please select target language.";
            }

            endpoint = endpoint.TrimEnd('/');

            string encodedText = Uri.EscapeDataString(text);

            string requestUrl =
                $"{endpoint}/translate_a/single?client=gtx&sl={sourceLanguage}&tl={targetLanguage}&dt=t&q={encodedText}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return $"Translation failed. Status: {(int)response.StatusCode}. Response: {result}";
                }

                using JsonDocument jsonDocument = JsonDocument.Parse(result);

                JsonElement translationsArray = jsonDocument.RootElement[0];

                StringBuilder translatedText = new StringBuilder();

                foreach (JsonElement sentence in translationsArray.EnumerateArray())
                {
                    if (sentence.ValueKind == JsonValueKind.Array && sentence.GetArrayLength() > 0)
                    {
                        string? translatedPart = sentence[0].GetString();
                        translatedText.Append(translatedPart);
                    }
                }

                if (translatedText.Length == 0)
                {
                    return "No translation result found.";
                }

                return translatedText.ToString();
            }
            catch (HttpRequestException ex)
            {
                return $"Translation service connection error: {ex.Message}";
            }
            catch (TaskCanceledException)
            {
                return "Translation service timeout. Please try again.";
            }
            catch (Exception ex)
            {
                return $"Unexpected translation error: {ex.Message}";
            }
        }
    }
}
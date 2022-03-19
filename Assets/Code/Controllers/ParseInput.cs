using System.Globalization;
using TMPro;

public class ParseInput
{
    private readonly TMP_InputField _spawnIntervalInput;
    private readonly TMP_InputField _accelerationInput;

    public ParseInput(TMP_InputField accelerationInput, TMP_InputField spawnIntervalInput)
    {
        _accelerationInput = accelerationInput;
        _spawnIntervalInput = spawnIntervalInput;
    }
    public int ParsedAcceleration()
    {
        var cubeSpeed = 0;
        
        var inputText = _accelerationInput.text;

        int.TryParse(inputText, out var parsedValue);

        if (parsedValue >= 0 && parsedValue <= 350)
        {
            cubeSpeed = parsedValue;
        }

        return cubeSpeed;
    }

    public float ParsedSpawnInterval()
    {
        float spawnInterval = 0;
        
        var inputText = _spawnIntervalInput.text;

        float.TryParse(inputText, out var parsedValue);

        if (parsedValue >= 0 && parsedValue <= 60)
        {
            spawnInterval = parsedValue;
        }

        return spawnInterval;
    }
}
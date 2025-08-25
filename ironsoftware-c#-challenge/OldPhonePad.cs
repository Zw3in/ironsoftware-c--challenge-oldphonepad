namespace ironsoftware_c__challenge
{
    public class OldPhonePadFunctions
    {
        public static String OldPhonePad(string input)
        {
            if (input == null) return ""; // could throw exception instead
            string output = "";
            Dictionary<char, string> phonePadMap = new()
             {
                { '1', "&'(" },
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" },
                { '0', " " }
            };
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                // send key
                if (currentChar == '#') return output;
                // backspace key
                if (currentChar == '*') output = output.Length > 0 ? output[..^1] : "";
                else if (phonePadMap.TryGetValue(currentChar, out string? characters))
                {
                    int charIndex = 0;
                    while (i + 1 < input.Length && input[i + 1] == currentChar)
                    {
                        charIndex++;
                        i++;
                    }
                    output += characters[charIndex % characters.Length]; // to account for more than 3/4 numbers; wrap-around
                }
            }
            return ""; // return empty string if # is not present; could throw exception instead
        }
    }
}

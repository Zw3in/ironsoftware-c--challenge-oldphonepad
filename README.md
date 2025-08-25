# ironsoftware-c#-challenge

log of AI usage : 

OldPhonePad.cs - 2 instances of accepting code refinements from GitHub CoPilot
line 28 - changed output.Substring(0, output.length-1) to output[..^1]
line 29 - changed phonePadMap.ContainsKey() to phonePadMap.TryGetValue()

OldPhonePad.Test/UnitTest1.cs - used AI to write boilerplate InlineData because I was too lazy to write it myself.
lines 14-32

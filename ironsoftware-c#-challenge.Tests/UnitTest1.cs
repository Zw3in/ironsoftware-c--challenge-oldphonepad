namespace ironsoftware_c__challenge.Tests
{
    public class UnitTest1
    {
        // A single parameterized test that covers common paths:
        // - letter selection by repeated presses
        // - wrap-around on long runs
        // - backspace handling
        // - space on 0
        // - early submit at '#'
        // - special characters on '1'
        // - multi-digit sequences
        [Theory]
        [InlineData("2#", "A")]          // first press of 2 -> 'A'
        [InlineData("22#", "B")]         // second press of 2 -> 'B'
        [InlineData("222#", "C")]        // third press of 2 -> 'C'
        [InlineData("7777#", "S")]       // 7 maps to "PQRS", 4 presses -> 'S'
        [InlineData("77777#", "P")]      // wrap-around: 5 presses -> back to 'P'
        [InlineData("0#", " ")]          // 0 maps to space
        [InlineData("20#", "A ")]        // '2' then '0' -> "A "
        [InlineData("11#", "'")]         // '1' maps to "&'(", two presses -> "'"
        [InlineData("227*#", "B")]       // "22" -> 'B', "7" -> 'P', '*' removes 'P'
        [InlineData("*#", "")]           // backspace on empty is a no-op
        [InlineData("22233555#", "CEL")] // 222 -> 'C', 33 -> 'E', 555 -> 'L'
        [InlineData("2#22", "A")]        // stops at first '#', ignores the rest
        [InlineData("222*33#", "E")]     // 'C', backspace to '', then 'E'
        [InlineData("9999999#", "Y")]    // 9 -> "WXYZ", 7 presses -> index 6 -> 'Y'
        [InlineData("0*#", "")]          // space then backspace -> empty
        [InlineData("222", "")]
        [InlineData("20", "")]
        [InlineData("*", "")]
        [InlineData("", "")]

        // "wrong" data types
        [InlineData(2, "")]
        [InlineData(true, "")]
        [InlineData('c', "")]
        [InlineData(null, "")]

        [InlineData("33#", "E")]
        [InlineData("4433555 555666#", "HELLO")]
        [InlineData("8 88777444666*664#", "TURING")]
        [InlineData("this part should be ignored 8 88777444666*664#", "TURING")]
        [InlineData("8 88777444666*664", "")]
        [InlineData("8 88 888 8888 88888 888888#123", "TUVTUV")]
        public void OldPhonePadUnitTest(string input, string expected)
        {
            var result = OldPhonePadFunctions.OldPhonePad(input);
            Assert.Equal(expected, result);
        }
    }
}
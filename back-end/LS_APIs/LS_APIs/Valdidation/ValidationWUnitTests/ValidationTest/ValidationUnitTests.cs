using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validation;

namespace ValidationTest
{
    [TestClass]
    public class ValidationUnitTests
    {
        //checkForInput_______________________________________________________________________
        /**
        * \brief: This unit test will check if checkForInput accepts valid input
        * 
        * \ <b> Name of Method</b>
        * checkForInput_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "valid data"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void checkForInput_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "valid data";
            int errorCode = val.checkForInput(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if checkForInput accepts valid limit input
        * 
        * \ <b> Name of Method</b>
        * checkForInput_ValidPropertiesAllSpaces_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is boundary/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "          "
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void checkForInput_ValidPropertiesAllSpaces_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "          ";
            int errorCode = val.checkForInput(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if checkForInput accepts valid limit input including special characters
        * 
        * \ <b> Name of Method</b>
        * checkForInput_ValidPropertiesSpecialCharacters_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is boundary/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "૱ ꠸ ┯ ┰ ┱ ┲ ❗ ► ◄ Ă ă  0 1 2 3 4 5 6 7 8 9 Ǖ ǖ Ꞁ ¤  Ð ¢ ℥ Ω ℧ K ℶ ℷ ℸ ⅇ ⅊ ⚌ ⚍ ⚎ ⚏ ⚭ ⚮ ⌀ ⏑ ⏒ ⏓ ⏔ ⏕ ⏖ ⏗ ⏘ ⏙ ⏠ ⏡ ⏦ ᶀ ᶁ ᶂ ᶃ ᶄ ᶆ ᶇ ᶈ ᶉ ᶊ ᶋ ᶌ ᶍ ᶎ ᶏ ᶐ ᶑ ᶒ ᶓ ᶔ ᶕ ᶖ ᶗ ᶘ ᶙ ᶚ ᶸ ᵯ ᵰ ᵴ ᵶ ᵹ ᵼ ᵽ ᵾ ᵿ     ‌ ‍ ‎ ‏   ⁁ ⁊   ⁪ ⁫ ⁬ ⁭ ⁮ ⁯ ⸜ ⸝ ¶  ¥ £ ⅕ ⅙ ⅛ ⅔ ⅖ ⅗ ⅘ ⅜ ⅚ ⅐ ⅝ ↉ ⅓ ⅑ ⅒ ⅞ ← ↑ → ↓ ↔ ↕ ↖ ↗ ↘ ↙ ↚ ↛ ↜ ↝ ↞ ↟ ↠ ↡ ↢ ↣ ↤ ↥ ↦ ↧ ↨ ↩ ↪ ↫ ↬ ↭ ↮ ↯ ↰ ↱ ↲ ↳ ↴ ↵ ↶ ↷ ↸ ↹ ↺ ↻ ↼ ↽ ↾ ↿ ⇀ ⇁ ⇂ ⇃ ⇄ ⇅ ⇆ ⇇ ⇈ ⇉ ⇊ ⇋ ⇌ ⇍ ⇎ ⇏ ⇐ ⇑ ⇒ ⇓ ⇔ ⇕ ⇖ ⇗ ⇘ ⇙ ⇚ ⇛ ⇜ ⇝ ⇞ ⇟ ⇠ ⇡ ⇢ ⇣ ⇤ ⇥ ⇦ ⇨ ⇩ ⇪ ⇧ ⇫ ⇬ ⇭ ⇮ ⇯ ⇰ ⇱ ⇲ ⇳ ⇴ ⇵ ⇶ ⇷ ⇸ ⇹ ⇺ ⇻ ⇼ ⇽ ⇾ ⇿ ⟰ ⟱ ⟲ ⟳ ⟴ ⟵ ⟶ ⟷ ⟸ ⟹ ⟺ ⟻ ⟼ ⟽ ⟾ ⟿ ⤀ ⤁ ⤂ ⤃ ⤄ ⤅ ⤆ ⤇ ⤈ ⤉ ⤊ ⤋ ⤌ ⤍ ⤎ ⤏ ⤐ ⤑ ⤒ ⤓ ⤔ ⤕ ⤖ ⤗ ⤘ ⤙ ⤚ ⤛ ⤜ ⤝ ⤞ ⤟ ⤠ ⤡ ⤢ ⤣ ⤤ ⤥ ⤦ ⤧ ⤨ ⤩ ⤪ ⤫ ⤬ ⤭ ⤮ ⤯ ⤰ ⤱ ⤲ ⤳ ⤴ ⤵ ⤶ ⤷ ⤸ ⤹ ⤺ ⤻ ⤼ ⤽ ⤾ ⤿ ⥀ ⥁ ⥂ ⥃ ⥄ ⥅ ⥆ ⥇ ⥈ ⥉ ⥊ ⥋ ⥌ ⥍ ⥎ ⥏ ⥐ ⥑ ⥒ ⥓ ⥔ ⥕ ⥖ ⥗ ⥘ ⥙ ⥚ ⥛ ⥜ ⥝ ⥞ ⥟ ⥠ ⥡ ⥢ ⥣ ⥤ ⥥ ⥦ ⥧ ⥨ ⥩ ⥪ ⥫ ⥬ ⥭ ⥮ ⥯ ⥰ ⥱ ⥲ ⥳ ⥴ ⥵ ⥶ ⥷ ⥸ ⥹ ⥺ ⥻ ⥼ ⥽ ⥾ ⥿ ➔ ➘ ➙ ➚ ➛ ➜ ➝ ➞ ➝ ➞ ➟ ➠ ➡ ➢ ➣ ➤ ➥ ➦ ➧ ➨ ➩ ➩ ➪ ➫ ➬ ➭ ➮ ➯ ➱ ➲ ➳ ➴ ➵ ➶ ➷ ➸ ➹ ➺ ➻ ➼ ➽ ➾ ⬀ ⬁ ⬂ ⬃ ⬄ ⬅ ⬈ ⬉ ⬊ ⬋ ⬌ ⬍ ⬎ ⬏ ⬐ ⬑ ☇ ☈ ⏎ ⍃ ⍄ ⍅ ⍆ ⍇ ⍈ ⍐ ⍗ ⍌ ⍓ ⍍ ⍔ ⍏ ⍖ ♾ ⎌ ☊ ☋ ☌ ☍ ⌃ ⌄ ⌤ ⌅ ⌆ ⌇ ⚋ ⚊ ⌌ ⌍ ⌎ ⌏ ⌐ ⌑ ⌔ ⌕ ⌗ ⌙ ⌢ ⌣ ⌯ ⌬ ⌭ ⌮ ⌖ ⌰ ⌱ ⌳ ⌴ ⌵ ⌶ ⌷ ⌸ ⌹ ⌺ ⌻ ⌼ ⍯ ⍰ ⌽ ⌾ ⌿ ⍀ ⍁ ⍂ ⍉ ⍊ ⍋ ⍎ ⍏ ⍑ ⍒ ⍕ ⍖ ⍘ ⍙ ⍚ ⍛ ⍜ ⍝ ⍞ ⍠ ⍟ ⍡ ⍢ ⍣ ⍤ ⍥ ⍨ ⍩ ⍦ ⍧ ⍬ ⍿ ⍪ ⍮ ⍫ ⍱ ⍲ ⍭ ⍳ ⍴ ⍵ ⍶ ⍷ ⍸ ⍹ ⍺ ⍼ ⍽ ⍾ ⎀ ⎁ ⎂ ⎃ ⎄ ⎅ ⎆ ⎉ ⎊ ⎋ ⎍ ⎎ ⎏ ⎐ ⎑ ⎒ ⎓ ⎔ ⎕ ⏣ ⌓ ⏥ ⏢ ⎖ ⎲ ⎳ ⎴ ⎵ ⎶ ⎸ ⎹ ⎺ ⎻ ⎼ ⎽ ⎾ ⎿ ⏀ ⏁ ⏂ ⏃ ⏄ ⏅ ⏆ ⏇ ⏈ ⏉ ⏉ ⏋ ⏌ ⏍ ⏐ ⏤ ⏚ ⏛ Ⓝ ℰ ⓦ !       ⌘ « » ‹ › ‘ ’ “ ” „ ‚ ❝ ❞ £ ¥ € $ ¢ ¬ ¶ @ § ® © ™ ° × π ± √ ‰ Ω ∞ ≈ ÷ ~ ≠ ¹ ² ³ ½ ¼ ¾ ‐ – — |  [ ] { } † ‡ … · • ● ⌃ ⇧ ↩ ¡ ¿ ‽ ⁂ ∴ ∵ ◊ ※ ← → ↑ ↓ ☜ ☞ ☝ ☟ ✔ ★ ☆ ☼ ☂ ☺ ☹ ☃ ✉ ✿ ✄ ✈ ✌ ✎ ♠ ♦ ♣ ♥ ♪ ♫ ♯ ♀ ♂ α ß Á á À à Å å Ä ä Æ æ Ç ç É é È è Ê ê Í í Ì ì Î î Ñ ñ Ó ó Ò ò Ô ô Ö ö Ø ø Ú ú Ù ù Ü ü Ž ž ₳ ฿ ￠ € ₡ ¢ ₢ ₵ ₫ ￡ £ ₤ ₣ ƒ ₲ ₭ ₥ ₦ ₱ ＄ $ ₮ ₩ ￦ ¥ ￥ ₴ ₰ ¤ ៛ ₪ ₯ ₠ ₧ ₨ ௹ ﷼ ㍐ ৲ ৳ ~ ƻ Ƽ ƽ ¹ ¸ ¬ ¨ ɂ ǁ ¯ Ɂ ǂ ¡ ´ ° ꟾ ¦ } { | . , · ] ) [  _  ¿ º § * - + ( ! & % $ ¼ ¾ ½ ¶ © ® @ ẟ Ɀ ` Ȿ ^ ꜠ ꜡ ỻ ' = : ; < ꞌ Ꞌ ꞊ ꞁ ꞈ ꞉ > ? ÷ ℾ ℿ ℔ ℩ ℉ ⅀ ℈ þ ð Þ µ ª ꝋ ꜿ Ꜿ ⱽ ⱺ ⱹ ⱷ ⱶ Ⱶ ⱴ ⱱ Ɒ ⱦ ȶ ȴ ȣ Ȣ ȡ ȝ Ȝ ț ȋ Ȋ ȉ Ȉ ǯ Ǯ ǃ ǀ ƿ ƾ ƺ ƹ Ƹ Ʒ Ʋ ư ƪ ƣ Ƣ Ɵ ƛ Ɩ ƕ ƍ ſ ỽ ⸀ ⸁ ⸂ ⸃ ⸄ ⸅ ⸆ ⸇ ⸈ ⸉ ⸊ ⸋ ⸌ ⸍ ⸎ ⸏ ⸐ ⸑ ⸒ ⸔ ⸕ ▲ ▼ ◀ ▶ ◢ ◣ ◥ ◤ △ ▽ ◿ ◺ ◹ ◸ ▴ ▾ ◂ ▸ ▵ ▿ ◃ ▹ ◁ ▷ ◅ ▻ ◬ ⟁ ⧋ ⧊ ⊿ ∆ ∇ ◭ ◮ ⧩ ⧨ ⌔ ⟐ ◇ ◆ ◈ ⬖ ⬗ ⬘ ⬙ ⬠ ⬡ ⎔ ⋄ ◊ ⧫ ⬢ ⬣ ▰ ▪ ◼ ▮ ◾ ▗ ▖ ■ ∎ ▃ ▄ ▅ ▆ ▇ █ ▌ ▐ ▍ ▎ ▉ ▊ ▋ ❘ ❙ ❚ ▀ ▘ ▝ ▙ ▚ ▛ ▜ ▟ ▞ ░ ▒ ▓ ▂ ▁ ▬ ▔ ▫ ▯ ▭ ▱ ◽ □ ◻ ▢ ⊞ ⊡ ⊟ ⊠ ▣ ▤ ▥ ▦ ⬚ ▧ ▨ ▩ ⬓ ◧ ⬒ ◨ ◩ ◪ ⬔ ⬕ ❏ ❐ ❑ ❒ ⧈ ◰ ◱ ◳ ◲ ◫ ⧇ ⧅ ⧄ ⍁ ⍂ ⟡ ⧉ ○ ◌ ◍ ◎ ◯ ❍ ◉ ⦾ ⊙ ⦿ ⊜ ⊖ ⊘ ⊚ ⊛ ⊝ ● ⚫ ⦁ ◐ ◑ ◒ ◓ ◔ ◕ ⦶ ⦸ ◵ ◴ ◶ ◷ ⊕ ⊗ ⦇ ⦈ ⦉ ⦊ ❨ ❩ ⸨ ⸩ ◖ ◗ ❪ ❫ ❮ ❯ ❬ ❭ ❰ ❱ ⊏ ⊐ ⊑ ⊒ ◘ ◙ ◚ ◛ ◜ ◝ ◞ ◟ ◠ ◡ ⋒ ⋓ ⋐ ⋑ ╰ ╮ ╭ ╯ ⌒ ╳ ✕ ╱ ╲ ⧸ ⧹ ⌓ ◦ ❖ ✖ ✚ ✜ ⧓ ⧗ ⧑ ⧒ ⧖ _ ⚊ ╴ ╼ ╾ ‐ ⁃ ‑ ‒ - – ⎯ — ― ╶ ╺ ╸ ─ ━ ┄ ┅ ┈ ┉ ╌ ╍ ═ ≣ ≡ ☰ ☱ ☲ ☳ ☴ ☵ ☶ ☷ ╵ ╷ ╹ ╻ │ ▕ ▏ ┃ ┆ ┇ ┊ ╎ ┋ ╿ ╽ ┌ ┍ ┎ ┏ ┐ ┑ ┒ ┓ └ ┕ ┖ ┗ ┘ ┙ ┚ ┛ ├ ┝ ┞ ┟ ┠ ┡ ┢ ┣ ┤ ┥ ┦ ┧ ┨ ┩ ┪ ┫ ┬ ┭ ┮ ┳ ┴ ┵ ┶ ┷ ┸ ┹ ┺ ┻ ┼ ┽ ┾ ┿ ╀ ╁ ╂ ╃ ╄ ╅ ╆ ╇ ╈ ╉ ╊ ╋ ╏ ║ ╔ ╒ ╓ ╕ ╖ ╗ ╚ ╘ ╙ ╛ ╜ ╝ ╞ ╟ ╠ ╡ ╢ ╣ ╤ ╥ ╦ ╧ ╨ ╩ ╪ ╫ ╬ ⌞ ⌟ ⌜ ⌝ ⌊ ⌋ ⌉ ⌈ ⌋ ₯ ἀ ἁ ἂ ἃ ἄ ἅ ἆ ἇ Ἀ Ἁ Ἂ Ἃ Ἄ Ἅ Ἆ Ἇ ἐ ἑ ἒ ἓ ἔ ἕ Ἐ Ἑ Ἒ Ἓ Ἔ Ἕ ἠ ἡ ἢ ἣ ἤ ἥ ἦ ἧ Ἠ Ἡ Ἢ Ἣ Ἤ Ἥ Ἦ Ἧ ἰ ἱ ἲ ἳ ἴ ἵ ἶ ἷ Ἰ Ἱ Ἲ Ἳ Ἴ Ἵ Ἶ Ἷ ὀ ὁ ὂ ὃ ὄ ὅ Ὀ Ὁ Ὂ Ὃ Ὄ Ὅ ὐ ὑ ὒ ὓ ὔ ὕ ὖ ὗ Ὑ Ὓ Ὕ Ὗ ὠ ὡ ὢ ὣ ὤ ὥ ὦ ὧ Ὠ Ὡ Ὢ Ὣ Ὤ Ὥ Ὦ Ὧ ὰ ά ὲ έ ὴ ή ὶ ί ὸ ό ὺ ύ ὼ ώ ᾀ ᾁ ᾂ ᾃ ᾄ ᾅ ᾆ ᾇ ᾈ ᾉ ᾊ ᾋ ᾌ ᾍ ᾎ ᾏ ᾐ ᾑ ᾒ ᾓ ᾔ ᾕ ᾖ ᾗ ᾘ ᾙ ᾚ ᾛ ᾜ ᾝ ᾞ ᾟ ᾠ ᾡ ᾢ ᾣ ᾤ ᾥ ᾦ ᾧ ᾨ ᾩ ᾪ ᾫ ᾬ ᾭ ᾮ ᾯ ᾰ ᾱ ᾲ ᾳ ᾴ ᾶ ᾷ Ᾰ Ᾱ Ὰ Ά ᾼ ᾽ ι ᾿ ῀ ῁ ῂ ῃ ῄ ῆ ῇ Ὲ Έ Ὴ Ή ῌ ῍ ῎ ῏ ῐ ῑ ῒ ΐ ῖ ῗ Ῐ Ῑ Ὶ Ί ῝ ῞ ῟ ῠ ῡ ῢ ΰ ῤ ῥ ῦ ῧ Ῠ Ῡ Ὺ Ύ Ῥ ῭ ΅ ` ῲ ῳ ῴ ῶ ῷ Ὸ Ό Ὼ Ώ ῼ ´ ῾ Ͱ ͱ Ͳ ͳ ʹ ͵ Ͷ ͷ ͺ ͻ ͼ ͽ ; ΄ ΅ Ά · Έ Ή Ί Ό Ύ Ώ ΐ Α Β Γ Δ Ε Ζ Η Θ Ι Κ Λ Μ Ν Ξ Ο Π Ρ Σ Τ Υ Φ Χ Ψ Ω Ϊ Ϋ ά έ ή ί ΰ α β γ δ ε ζ η θ ι κ λ μ ν ξ ο π ρ ς σ τ υ φ χ ψ ω ϊ ϋ ό ύ ώ ϐ ϑ ϒ ϓ ϔ ϕ ϖ ϗ Ϙ ϙ Ϛ ϛ Ϝ ϝ Ϟ ϟ Ϡ ϡ Ϣ ϣ Ϥ ϥ Ϧ ϧ Ϩ ϩ Ϫ ϫ Ϭ ϭ Ϯ ϯ ϰ ϱ ϲ ϳ ϴ ϵ ϶ Ϸ ϸ Ϲ Ϻ ϻ ϼ Ͻ Ͼ Ͽ Ⓐ ⓐ ⒜ A a Ạ ạ Ả ả Ḁ ḁ Â Ã Ǎ ǎ Ấ ấ Ầ ầ Ẩ ẩ Ȃ ȃ Ẫ ẫ Ậ ậ À Á Ắ ắ Ằ ằ Ẳ ẳ Ẵ ẵ Ặ ặ Ā ā Ą ą Ǟ Ȁ ȁ Å Ǻ ǻ Ä ä ǟ Ǡ ǡ â á å ã à ẚ Ȧ ȧ Ⱥ Å ⱥ Æ æ Ǽ Ǣ ǣ Ɐ Ꜳ ꜳ Ꜹ Ꜻ Ɑ ꜹ ꜻ ª ℀ ⅍ ℁ Ⓑ ⓑ ⒝ B b Ḃ ḃ Ḅ ḅ Ḇ ḇ Ɓ Ƀ ƀ ƃ Ƃ Ƅ ƅ ℬ Ⓒ ⓒ ⒞ C c Ḉ ḉ Ć ć Ĉ ĉ Ċ ċ Č č Ç ç Ƈ ƈ Ȼ ȼ ℂ ℃ ℭ Ɔ ℅ ℆ ℄ Ꜿ ꜿ Ⓓ ⓓ ⒟ D d Ḋ ḋ Ḍ ḍ Ḏ ḏ Ḑ ḑ Ḓ ḓ Ď ď Ɗ Ƌ ƌ Ɖ Đ đ ȡ ⅅ ⅆ Ǳ ǲ ǳ Ǆ ǅ ǆ ȸ Ⓔ ⓔ ⒠ E e Ḕ ḕ Ḗ ḗ Ḙ ḙ Ḛ ḛ Ḝ ḝ Ẹ ẹ Ẻ ẻ Ế ế Ẽ ẽ Ề ề Ể ể Ễ ễ Ệ ệ Ē ē Ĕ ĕ Ė ė Ę ę Ě ě È è É é Ê ê Ë ë Ȅ ȅ Ȩ ȩ Ȇ ȇ Ǝ ⱸ Ɇ ℇ ℯ ℮ Ɛ ℰ Ə ǝ ⱻ ɇ Ⓕ ⓕ ⒡ F f Ḟ ḟ Ƒ ƒ ꜰ Ⅎ ⅎ ꟻ ℱ ℻ Ⓖ ⓖ ⒢ G g Ɠ Ḡ ḡ Ĝ ĝ Ğ ğ Ġ ġ Ģ ģ Ǥ ǥ Ǧ ǧ Ǵ ℊ ⅁ ǵ Ⓗ ⓗ ⒣ H h Ḣ ḣ Ḥ ḥ Ḧ ḧ Ḩ ḩ Ḫ ḫ ẖ Ĥ ĥ Ȟ ȟ Ħ ħ Ⱨ ⱨ Ꜧ ℍ Ƕ ℏ ℎ ℋ ℌ ꜧ Ⓘ ⓘ ⒤ I i Ḭ ḭ Ḯ ḯ Ĳ ĳ ì í î ï Ì Í Î Ï Ĩ ĩ Ī ī Ĭ ĭ Į į ı Ɨ ƚ Ỻ Ǐ ǐ ⅈ ⅉ ℹ ℑ ℐ Ⓙ ⓙ ⒥ J j Ĵ ĵ ȷ ⱼ Ɉ ɉ ǰ Ⓚ ⓚ ⒦ K k Ḱ ḱ Ḳ ḳ Ḵ ḵ Ķ ķ Ƙ ƙ Ꝁ ꝁ Ꝃ ꝃ Ꝅ ꝅ Ǩ ǩ Ⱪ ⱪ ĸ Ⓛ ⓛ ⒧ L l Ḷ ḷ Ḹ ḹ Ḻ ḻ Ḽ ḽ Ĺ ĺ Ļ ļ Ľ İ ľ Ŀ ŀ Ł ł Ỉ ỉ Ị ị Ƚ Ⱡ Ꝉ ꝉ ⱡ Ɫ ꞁ ℒ Ǉ ǈ ǉ ⅃ ⅂ ℓ ȉ Ȉ Ȋ ȋ Ⓜ ⓜ ⒨ M m Ḿ ḿ Ṁ ṁ Ṃ ṃ ꟿ ꟽ Ɱ Ʃ Ɯ ℳ Ⓝ ⓝ ⒩ N n Ṅ ṅ Ṇ ṇ Ṉ ṉ Ṋ ṋ Ń ń Ņ ņ Ň ň Ǹ ǹ Ŋ Ɲ ñ ŉ Ñ Ƞ ƞ ŋ Ǌ ǋ ǌ ȵ ℕ №   O o Ṍ ṍ Ṏ ṏ Ṑ ṑ Ṓ ṓ Ȫ ȫ Ȭ ȭ Ȯ ȯ Ȱ ȱ Ǫ ǫ Ǭ ǭ Ọ ọ Ỏ ỏ Ố ố Ồ ồ Ổ ổ Ỗ ỗ Ộ ộ Ớ ớ Ờ ờ Ở ở Ỡ ỡ Ợ ợ Ơ ơ Ō ō Ŏ ŏ Ő ő Ò Ó Ô Õ Ö Ǒ Ȍ ȍ Ȏ ȏ Œ œ Ø Ǿ Ꝋ ǽ ǿ ℴ ⍥ ⍤ Ⓞ ⓞ ⒪ ò ó ô õ ö ǒ ø Ꝏ ꝏ Ⓟ ⓟ ⒫ ℗ P p Ṕ ṕ Ṗ ṗ Ƥ ƥ Ᵽ ℙ Ƿ ꟼ ℘ Ⓠ ⓠ ⒬ Q q Ɋ ɋ ℚ ℺ ȹ Ⓡ ⓡ ⒭ R r Ŕ ŕ Ŗ ŗ Ř ř Ṙ ṙ Ṛ ṛ Ṝ ṝ Ṟ ṟ Ȑ ȑ Ȓ ȓ ɍ Ɍ Ʀ Ɽ ℞ Ꝛ ꝛ ℜ ℛ ℟ ℝ Ⓢ ⓢ ⒮ S s Ṡ ṡ Ṣ ṣ Ṥ ṥ Ṧ ṧ Ṩ ṩ Ś ś Ŝ ŝ Ş ş Š š Ș ș ȿ ꜱ Ƨ ƨ ẞ ß ẛ ẜ ẝ ℠ Ⓣ ⓣ ⒯ T t Ṫ ṫ Ṭ ṭ Ṯ ṯ Ṱ ṱ Ţ ţ Ť ť Ŧ ŧ Ƭ Ʈ ẗ Ț Ⱦ ƫ ƭ ț ⱦ ȶ ℡ ™ Ⓤ ⓤ ⒰ U u Ṳ ṳ Ṵ ṵ Ṷ ṷ Ṹ ṹ Ṻ ṻ Ụ Ủ ủ Ứ Ừ ụ ứ Ử ử ừ ữ Ữ Ự ự Ũ ũ Ū ū Ŭ ŭ Ů ů Ű ű Ǚ ǚ Ǘ ǘ Ǜ ǜ Ų ų Ǔ ǔ Ȕ ȕ Û û Ȗ ȗ Ù ù Ü ü Ư ú Ʉ ư Ʋ Ʊ Ⓥ ⓥ ⒱ V v Ṽ ṽ Ṿ ṿ Ỽ Ʌ ℣ ⱱ ⱴ ⱽ Ⓦ ⓦ ⒲ W w Ẁ ẁ Ẃ ẃ Ẅ ẅ Ẇ ẇ Ẉ ẉ Ŵ ŵ ẘ Ⱳ ⱳ Ⓧ ⓧ ⒳ X x Ẋ ẋ Ẍ ẍ ℵ × Ⓨ ⓨ ⒴ y Y Ẏ ẏ Ỿ ỿ ẙ Ỳ ỳ Ỵ ỵ Ỷ ỷ Ỹ ỹ Ŷ ŷ Ƴ ƴ Ÿ ÿ Ý ý Ɏ ɏ Ȳ Ɣ ⅄ ȳ ℽ Ⓩ ⓩ ⒵ Z z Ẑ ẑ Ẓ ẓ Ẕ ẕ Ź ź Ż ż Ž ž Ȥ ȥ Ⱬ ⱬ Ƶ ƶ ɀ ℨ ℤ ⟀ ⟁ ⟂ ⟃ ⟄ ⟇ ⟈ ⟉ ⟊ ⟐ ⟑ ⟒ ⟓ ⟔ ⟕ ⟖ ⟗ ⟘ ⟙ ⟚ ⟛ ⟜ ⟝ ⟞ ⟟ ⟠ ⟡ ⟢ ⟣ ⟤ ⟥ ⟦ ⟧ ⟨ ⟩ ⟪ ⟫ ⦀ ⦁ ⦂ ⦃ ⦄ ⦅ ⦆ ⦇ ⦈ ⦉ ⦊ ⦋ ⦌ ⦍ ⦎ ⦏ ⦐ ⦑ ⦒ ⦓ ⦔ ⦕ ⦖ ⦗ ⦘ ⦙ ⦚ ⦛ ⦜ ⦝ ⦞ ⦟ ⦠ ⦡ ⦢ ⦣ ⦤ ⦥ ⦦ ⦧ ⦨ ⦩ ⦪ ⦫ ⦬ ⦭ ⦮ ⦯ ⦰ ⦱ ⦲ ⦳ ⦴ ⦵ ⦶ ⦷ ⦸ ⦹ ⦺ ⦻ ⦼ ⦽ ⦾ ⦿ ⧀ ⧁ ⧂ ⧃ ⧄ ⧅ ⧆ ⧇ ⧈ ⧉ ⧊ ⧋ ⧌ ⧍ ⧎ ⧏ ⧐ ⧑ ⧒ ⧓ ⧔ ⧕ ⧖ ⧗ ⧘ ⧙ ⧚ ⧛ ⧜ ⧝ ⧞ ⧟ ⧡ ⧢ ⧣ ⧤ ⧥ ⧦ ⧧ ⧨ ⧩ ⧪ ⧫ ⧬ ⧭ ⧮ ⧯ ⧰ ⧱ ⧲ ⧳ ⧴ ⧵ ⧶ ⧷ ⧸ ⧹ ⧺ ⧻ ⧼ ⧽ ⧾ ⧿ ∀ ∁ ∂ ∃ ∄ ∅ ∆ ∇ ∈ ∉ ∊ ∋ ∌ ∍ ∎ ∏ ∐ ∑ − ∓ ∔ ∕ ∖ ∗ ∘ ∙ √ ∛ ∜ ∝ ∞ ∟ ∠ ∡ ∢ ∣ ∤ ∥ ∦ ∧ ∨ ∩ ∪ ∫ ∬ ∭ ∮ ∯ ∰ ∱ ∲ ∳ ∴ ∵ ∶ ∷ ∸ ∹ ∺ ∻ ∼ ∽ ∾ ∿ ≀ ≁ ≂ ≃ ≄ ≅ ≆ ≇ ≈ ≉ ≊ ≋ ≌ ≍ ≎ ≏ ≐ ≑ ≒ ≓ ≔ ≕ ≖ ≗ ≘ ≙ ≚ ≛ ≜ ≝ ≞ ≟ ≠ ≡ ≢ ≣ ≤ ≥ ≦ ≧ ≨ ≩ ≪ ≫ ≬ ≭ ≮ ≯ ≰ ≱ ≲ ≳ ≴ ≵ ≶ ≷ ≸ ≹ ≺ ≻ ≼ ≽ ≾ ≿ ⊀ ⊁ ⊂ ⊃ ⊄ ⊅ ⊆ ⊇ ⊈ ⊉ ⊊ ⊋ ⊌ ⊍ ⊎ ⊏ ⊐ ⊑ ⊒ ⊓ ⊔ ⊕ ⊖ ⊗ ⊘ ⊙ ⊚ ⊛ ⊜ ⊝ ⊞ ⊟ ⊠ ⊡ ⊢ ⊣ ⊤ ⊥ ⊦ ⊧ ⊨ ⊩ ⊪ ⊫ ⊬ ⊭ ⊮ ⊯ ⊰ ⊱ ⊲ ⊳ ⊴ ⊵ ⊶ ⊷ ⊸ ⊹ ⊺ ⊻ ⊼ ⊽ ⊾ ⊿ ⋀ ⋁ ⋂ ⋃ ⋄ ⋅ ⋆ ⋇ ⋈ ⋉ ⋊ ⋋ ⋌ ⋍ ⋎ ⋏ ⋐ ⋑ ⋒ ⋓ ⋔ ⋕ ⋖ ⋗ ⋘ ⋙ ⋚ ⋛ ⋜ ⋝ ⋞ ⋟ ⋠ ⋡ ⋢ ⋣ ⋤ ⋥ ⋦ ⋧ ⋨ ⋩ ⋪ ⋫ ⋬ ⋭ ⋮ ⋯ ⋰ ⋱ ⋲ ⋳ ⋴ ⋵ ⋶ ⋷ ⋸ ⋹ ⋺ ⋻ ⋼ ⋽ ⋾ ⋿ ✕ ✖ ✚ ◀ ▶ ❝ ❞ ★ ☆ ☼ ☂ ☺ ☹ ✄ ✈ ✌ ✎ ♪ ♫ ☀ ☁ ☔ ⚡ ❆ ☽ ☾ ✆ ✔ ☯ ☮ ☠ ☬ ✄ ✏ ♰ ✡ ✰ ✺ ♕ ♛ ♚ ♬ ⓐ ⓑ ⓒ ⓓ ↺ ↻ ⇖ ⇗ ⇘ ⇙ ⟵ ⟷ ⟶ ⤴ ⤵ ⤶ ⤷ ➫ ➬ € ₤ ＄ ₩ ₪ ⟁ ⟐ ◆ ⎔ ░ ▢ ⊡ ▩ ⟡ ◎ ◵ ⊗ ❖ Ω β Φ Σ Ξ ⟁ ⦻ ⧉ ⧭ ⧴ ∞ ≌ ⊕ ⋍ ⋰ ⋱ ✖ ⓵ ⓶ ⓷ ⓸ ⓹ ⓺ ⓻ ⓼ ⓽ ⓾ ᴕ ⸨ ⸩ ❪ ❫ ⓵ ⓶ ⓷ ⓸ ⓹ ⓺ ⓻ ⓼ ⓽ ⓾ ⒈ ⒉ ⒊ ⒋ ⒌ ⒍ ⒎ ⒏ ⒐ ⒑ ⒒ ⒓ ⒔ ⒕ ⒖ ⒗ ⒘ ⒙ ⒚ ⒛ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ➀ ➁ ➂ ➃ ➄ ➅ ➆ ➇ ➈ ➉ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳ ⓿ ❶ ❷ ❸ ❹ ❺ ❻ ❼ ❽ ❾ ❿ ➊ ➋ ➌ ➍ ➎ ➏ ➐ ➑ ➒ ➓ ⓫ ⓬ ⓭ ⓮ ⓯ ⓰ ⓱ ⓲ ⓳ ⓴ ⑴ ⑵ ⑶ ⑷ ⑸ ⑹ ⑺ ⑻ ⑼ ⑽ ⑾ ⑿ ⒀ ⒁ ⒂ ⒃ ⒄ ⒅ ⒆ ⒇ ᶅ ᶛ ᶜ ᶝ ᶞ ᶟ ᶠ ᶡ ᶢ ᶣ ᶤ ᶥ ᶦ ᶧ ᶨ ᶩ ᶪ ᶫ ᶬ ᶭ ᶮ ᶯ ᶰ ᶱ ᶲ ᶳ ᶴ ᶵ ᶶ ᶷ ᶹ ᶺ ᶻ ᶼ ᶽ ᶾ ᶿ ᴀ ᴁ ᴂ ᴃ ᴄ ᴅ ᴆ ᴇ ᴈ ᴉ ᴊ ᴋ ᴌ ᴍ ᴎ ᴏ ᴐ ᴑ ᴒ ᴓ ᴔ ᴕ ᴖ ᴗ ᴘ ᴙ ᴚ ᴛ ᴜ ᴝ ᴞ ᴟ ᴠ ᴡ ᴢ ᴣ ᴤ ᴥ ᴦ ᴧ ᴨ ᴩ ᴪ ᴫ ᴬ ᴭ ᴮ ᴯ ᴰ ᴱ ᴲ ᴳ ᴴ ᴵ ᴶ ᴷ ᴸ ᴹ ᴺ ᴻ ᴼ ᴽ ᴾ ᴿ ᵀ ᵁ ᵂ ᵃ ᵄ ᵅ ᵆ ᵇ ᵈ ᵉ ᵊ ᵋ ᵌ ᵍ ᵎ ᵏ ᵐ ᵑ ᵒ ᵓ ᵔ ᵕ ᵖ ᵗ ᵘ ᵙ ᵚ ᵛ ᵜ ᵝ ᵞ ᵟ ᵠ ᵡ ᵢ ᵣ ᵤ ᵥ ᵦ ᵧ ᵨ ᵩ ᵪ ᵫ ᵬ ᵭ ᵮ ᵱ ᵲ ᵳ ᵵ ᵷ ᵸ ᵺ ᵻ ᷋ ᷌ ᷍ ᷎ ᷏ ᷓ ᷔ ᷕ ᷖ ᷗ ᷘ ᷙ ᷛ ᷜ ᷝ ᷞ ᷟ ᷠ ᷡ ᷢ ᷣ ᷤ ᷥ ᷦ ‘ ’ ‛ ‚ „  « » ‹ › Ꞌ  ❛ ❜ ❝ ❞ < > @ ‧ ¨ ․ ꞉ : ⁚ ⁝ ⁞ ‥ … ⁖ ⸪ ⸬ ⸫ ⸭ ⁛ ⁘ ⁙ ⁏ ; ⦂ ⁃ ‐ ‑ ‒ - – ⎯ — ― _ ⁓ ⸛ ⸞ ⸟ ⸯ ¬  | ⎜ ¦ ‖ ‗ † ‡ · • ⸰ ° ‣ ⁒ % ‰ ‱ & ⅋ § ÷ + ± = ꞊ ′ ″ ‴ ⁗ ‵ ‶ ‷ ‸ * ⁑ ⁎ ⁕ ※ ⁜ ⁂ ! ‼ ¡ ? ¿ ⸮ ⁇ ⁉ ⁈ ‽ ⸘ ¼ ½ ¾ ² ³ © ® ™ ℠ ℻ ℅ ℁ ⅍ ℄ ¶ ⁋ ❡ ⁌ ⁍ ⸖ ⸗ ⸚ ⸓ ( ) [ ] { } ⸨ ⸩ ❨ ❩ ❪ ❫ ⸦ ⸧ ❬ ❭ ❮ ❯ ❰ ❱ ❴ ❵ ❲ ❳ ⦗ ⦘ ⁅ ⁆ 〈 〉 ⏜ ⏝ ⏞ ⏟ ⸡ ⸠ ⸢ ⸣ ⸤ ⸥ ⎡ ⎤ ⎣ ⎦ ⎨ ⎬ ⌠ ⌡ ⎛ ⎠ ⎝ ⎞ ⁀ ⁔ ‿ ⁐ ‾ ⎟ ⎢ ⎥ ⎪ ꞁ ⎮ ⎧ ⎫ ⎩ ⎭ ⎰ ⎱ ✈ ☀ ☼ ☁ ☂ ☔ ⚡ ❄ ❅ ❆ ☃ ☉ ☄ ★ ☆ ☽ ☾ ⌛ ⌚ ☇ ☈ ⌂ ⌁ ✆ ☎ ☏ ☑ ✓ ✔ ⎷ ⍻ ✖ ✗ ✘ ☒ ✕ ☓ ☕ ♿ ✌ ☚ ☛ ☜ ☝ ☞ ☟ ☹ ☺ ☻ ☯ ⚘ ☮ ✝ ⚰ ⚱ ⚠ ☠ ☢ ⚔ ⚓ ⎈ ⚒ ☡ ❂ ⚕ ⚖ ⚗ ✇ ☣ ⚙ ☤ ⚚ ⚜ ☥ ☦ ☧ ☨ ☩ † ☪ ☫ ☬ ☭ ✁ ✂ ✃ ✄ ✍ ✎ ✏ ✐  ✑ ✒ ✉ ✙ ✚ ✜ ✛ ♰ ♱ ✞ ✟ ✠ ✡ ☸ ✢ ✣ ✤ ✥ ✦ ✧ ✩ ✪ ✫ ✬ ✭ ✮ ✯ ✰ ✲ ✱ ✳ ✴ ✵ ✶ ✷ ✸ ✹ ✺ ✻ ✼ ✽ ✾ ❀ ✿ ❁ ❃ ❇ ❈ ❉ ❊ ❋ ⁕ ☘ ❦ ❧ ☙ ❢ ❣ ♀ ♂ ⚤ ⚦ ⚧ ⚨ ⚩ ☿ ♁ ⚯ ♔ ♕ ♖ ♗ ♘ ♙ ♚ ♛ ♜ ♝ ♞ ♟ ☖ ☗ ♠ ♣ ♦ ♥ ❤ ❥ ♡ ♢ ♤ ♧ ⚀ ⚁ ⚂ ⚃ ⚄ ⚅ ⚇ ⚆ ⚈ ⚉ ♨ ♩ ♪ ♫ ♬ ♭ ♮ ♯ ⏏ ⎗ ⎘ ⎙ ⎚ ⎇ ⌘ ⌦ ⌫ ⌧ ♲ ♳ ♴ ♵ ♶ ♷ ♸ ♹ ♻ ♼ ♽ ⁌ ⁍ ⎌ ⌇ ⍝ ⍟ ⍣ ⍤ ⍥ ⍨ ⍩ ⎋ ♃ ♄ ♅ ♆ ♇ ♈ ♉ ♊ ♋ ♌ ♍ ♎ ♏ ♐ ♑ ♒ ♓ ⏚ ⏛ |   |   |   |   |   |   |   |   |   | ​ |"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void checkForInput_ValidPropertiesSpecialCharacters_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "૱ ꠸ ┯ ┰ ┱ ┲ ❗ ► ◄ Ă ă  0 1 2 3 4 5 6 7 8 9 Ǖ ǖ Ꞁ ¤  Ð ¢ ℥ Ω ℧ K ℶ ℷ ℸ ⅇ ⅊ ⚌ ⚍ ⚎ ⚏ ⚭ ⚮ ⌀ ⏑ ⏒ ⏓ ⏔ ⏕ ⏖ ⏗ ⏘ ⏙ ⏠ ⏡ ⏦ ᶀ ᶁ ᶂ ᶃ ᶄ ᶆ ᶇ ᶈ ᶉ ᶊ ᶋ ᶌ ᶍ ᶎ ᶏ ᶐ ᶑ ᶒ ᶓ ᶔ ᶕ ᶖ ᶗ ᶘ ᶙ ᶚ ᶸ ᵯ ᵰ ᵴ ᵶ ᵹ ᵼ ᵽ ᵾ ᵿ     ‌ ‍ ‎ ‏   ⁁ ⁊   ⁪ ⁫ ⁬ ⁭ ⁮ ⁯ ⸜ ⸝ ¶  ¥ £ ⅕ ⅙ ⅛ ⅔ ⅖ ⅗ ⅘ ⅜ ⅚ ⅐ ⅝ ↉ ⅓ ⅑ ⅒ ⅞ ← ↑ → ↓ ↔ ↕ ↖ ↗ ↘ ↙ ↚ ↛ ↜ ↝ ↞ ↟ ↠ ↡ ↢ ↣ ↤ ↥ ↦ ↧ ↨ ↩ ↪ ↫ ↬ ↭ ↮ ↯ ↰ ↱ ↲ ↳ ↴ ↵ ↶ ↷ ↸ ↹ ↺ ↻ ↼ ↽ ↾ ↿ ⇀ ⇁ ⇂ ⇃ ⇄ ⇅ ⇆ ⇇ ⇈ ⇉ ⇊ ⇋ ⇌ ⇍ ⇎ ⇏ ⇐ ⇑ ⇒ ⇓ ⇔ ⇕ ⇖ ⇗ ⇘ ⇙ ⇚ ⇛ ⇜ ⇝ ⇞ ⇟ ⇠ ⇡ ⇢ ⇣ ⇤ ⇥ ⇦ ⇨ ⇩ ⇪ ⇧ ⇫ ⇬ ⇭ ⇮ ⇯ ⇰ ⇱ ⇲ ⇳ ⇴ ⇵ ⇶ ⇷ ⇸ ⇹ ⇺ ⇻ ⇼ ⇽ ⇾ ⇿ ⟰ ⟱ ⟲ ⟳ ⟴ ⟵ ⟶ ⟷ ⟸ ⟹ ⟺ ⟻ ⟼ ⟽ ⟾ ⟿ ⤀ ⤁ ⤂ ⤃ ⤄ ⤅ ⤆ ⤇ ⤈ ⤉ ⤊ ⤋ ⤌ ⤍ ⤎ ⤏ ⤐ ⤑ ⤒ ⤓ ⤔ ⤕ ⤖ ⤗ ⤘ ⤙ ⤚ ⤛ ⤜ ⤝ ⤞ ⤟ ⤠ ⤡ ⤢ ⤣ ⤤ ⤥ ⤦ ⤧ ⤨ ⤩ ⤪ ⤫ ⤬ ⤭ ⤮ ⤯ ⤰ ⤱ ⤲ ⤳ ⤴ ⤵ ⤶ ⤷ ⤸ ⤹ ⤺ ⤻ ⤼ ⤽ ⤾ ⤿ ⥀ ⥁ ⥂ ⥃ ⥄ ⥅ ⥆ ⥇ ⥈ ⥉ ⥊ ⥋ ⥌ ⥍ ⥎ ⥏ ⥐ ⥑ ⥒ ⥓ ⥔ ⥕ ⥖ ⥗ ⥘ ⥙ ⥚ ⥛ ⥜ ⥝ ⥞ ⥟ ⥠ ⥡ ⥢ ⥣ ⥤ ⥥ ⥦ ⥧ ⥨ ⥩ ⥪ ⥫ ⥬ ⥭ ⥮ ⥯ ⥰ ⥱ ⥲ ⥳ ⥴ ⥵ ⥶ ⥷ ⥸ ⥹ ⥺ ⥻ ⥼ ⥽ ⥾ ⥿ ➔ ➘ ➙ ➚ ➛ ➜ ➝ ➞ ➝ ➞ ➟ ➠ ➡ ➢ ➣ ➤ ➥ ➦ ➧ ➨ ➩ ➩ ➪ ➫ ➬ ➭ ➮ ➯ ➱ ➲ ➳ ➴ ➵ ➶ ➷ ➸ ➹ ➺ ➻ ➼ ➽ ➾ ⬀ ⬁ ⬂ ⬃ ⬄ ⬅ ⬈ ⬉ ⬊ ⬋ ⬌ ⬍ ⬎ ⬏ ⬐ ⬑ ☇ ☈ ⏎ ⍃ ⍄ ⍅ ⍆ ⍇ ⍈ ⍐ ⍗ ⍌ ⍓ ⍍ ⍔ ⍏ ⍖ ♾ ⎌ ☊ ☋ ☌ ☍ ⌃ ⌄ ⌤ ⌅ ⌆ ⌇ ⚋ ⚊ ⌌ ⌍ ⌎ ⌏ ⌐ ⌑ ⌔ ⌕ ⌗ ⌙ ⌢ ⌣ ⌯ ⌬ ⌭ ⌮ ⌖ ⌰ ⌱ ⌳ ⌴ ⌵ ⌶ ⌷ ⌸ ⌹ ⌺ ⌻ ⌼ ⍯ ⍰ ⌽ ⌾ ⌿ ⍀ ⍁ ⍂ ⍉ ⍊ ⍋ ⍎ ⍏ ⍑ ⍒ ⍕ ⍖ ⍘ ⍙ ⍚ ⍛ ⍜ ⍝ ⍞ ⍠ ⍟ ⍡ ⍢ ⍣ ⍤ ⍥ ⍨ ⍩ ⍦ ⍧ ⍬ ⍿ ⍪ ⍮ ⍫ ⍱ ⍲ ⍭ ⍳ ⍴ ⍵ ⍶ ⍷ ⍸ ⍹ ⍺ ⍼ ⍽ ⍾ ⎀ ⎁ ⎂ ⎃ ⎄ ⎅ ⎆ ⎉ ⎊ ⎋ ⎍ ⎎ ⎏ ⎐ ⎑ ⎒ ⎓ ⎔ ⎕ ⏣ ⌓ ⏥ ⏢ ⎖ ⎲ ⎳ ⎴ ⎵ ⎶ ⎸ ⎹ ⎺ ⎻ ⎼ ⎽ ⎾ ⎿ ⏀ ⏁ ⏂ ⏃ ⏄ ⏅ ⏆ ⏇ ⏈ ⏉ ⏉ ⏋ ⏌ ⏍ ⏐ ⏤ ⏚ ⏛ Ⓝ ℰ ⓦ !       ⌘ « » ‹ › ‘ ’ “ ” „ ‚ ❝ ❞ £ ¥ € $ ¢ ¬ ¶ @ § ® © ™ ° × π ± √ ‰ Ω ∞ ≈ ÷ ~ ≠ ¹ ² ³ ½ ¼ ¾ ‐ – — |  [ ] { } † ‡ … · • ● ⌃ ⇧ ↩ ¡ ¿ ‽ ⁂ ∴ ∵ ◊ ※ ← → ↑ ↓ ☜ ☞ ☝ ☟ ✔ ★ ☆ ☼ ☂ ☺ ☹ ☃ ✉ ✿ ✄ ✈ ✌ ✎ ♠ ♦ ♣ ♥ ♪ ♫ ♯ ♀ ♂ α ß Á á À à Å å Ä ä Æ æ Ç ç É é È è Ê ê Í í Ì ì Î î Ñ ñ Ó ó Ò ò Ô ô Ö ö Ø ø Ú ú Ù ù Ü ü Ž ž ₳ ฿ ￠ € ₡ ¢ ₢ ₵ ₫ ￡ £ ₤ ₣ ƒ ₲ ₭ ₥ ₦ ₱ ＄ $ ₮ ₩ ￦ ¥ ￥ ₴ ₰ ¤ ៛ ₪ ₯ ₠ ₧ ₨ ௹ ﷼ ㍐ ৲ ৳ ~ ƻ Ƽ ƽ ¹ ¸ ¬ ¨ ɂ ǁ ¯ Ɂ ǂ ¡ ´ ° ꟾ ¦ } { | . , · ] ) [  _  ¿ º § * - + ( ! & % $ ¼ ¾ ½ ¶ © ® @ ẟ Ɀ ` Ȿ ^ ꜠ ꜡ ỻ ' = : ; < ꞌ Ꞌ ꞊ ꞁ ꞈ ꞉ > ? ÷ ℾ ℿ ℔ ℩ ℉ ⅀ ℈ þ ð Þ µ ª ꝋ ꜿ Ꜿ ⱽ ⱺ ⱹ ⱷ ⱶ Ⱶ ⱴ ⱱ Ɒ ⱦ ȶ ȴ ȣ Ȣ ȡ ȝ Ȝ ț ȋ Ȋ ȉ Ȉ ǯ Ǯ ǃ ǀ ƿ ƾ ƺ ƹ Ƹ Ʒ Ʋ ư ƪ ƣ Ƣ Ɵ ƛ Ɩ ƕ ƍ ſ ỽ ⸀ ⸁ ⸂ ⸃ ⸄ ⸅ ⸆ ⸇ ⸈ ⸉ ⸊ ⸋ ⸌ ⸍ ⸎ ⸏ ⸐ ⸑ ⸒ ⸔ ⸕ ▲ ▼ ◀ ▶ ◢ ◣ ◥ ◤ △ ▽ ◿ ◺ ◹ ◸ ▴ ▾ ◂ ▸ ▵ ▿ ◃ ▹ ◁ ▷ ◅ ▻ ◬ ⟁ ⧋ ⧊ ⊿ ∆ ∇ ◭ ◮ ⧩ ⧨ ⌔ ⟐ ◇ ◆ ◈ ⬖ ⬗ ⬘ ⬙ ⬠ ⬡ ⎔ ⋄ ◊ ⧫ ⬢ ⬣ ▰ ▪ ◼ ▮ ◾ ▗ ▖ ■ ∎ ▃ ▄ ▅ ▆ ▇ █ ▌ ▐ ▍ ▎ ▉ ▊ ▋ ❘ ❙ ❚ ▀ ▘ ▝ ▙ ▚ ▛ ▜ ▟ ▞ ░ ▒ ▓ ▂ ▁ ▬ ▔ ▫ ▯ ▭ ▱ ◽ □ ◻ ▢ ⊞ ⊡ ⊟ ⊠ ▣ ▤ ▥ ▦ ⬚ ▧ ▨ ▩ ⬓ ◧ ⬒ ◨ ◩ ◪ ⬔ ⬕ ❏ ❐ ❑ ❒ ⧈ ◰ ◱ ◳ ◲ ◫ ⧇ ⧅ ⧄ ⍁ ⍂ ⟡ ⧉ ○ ◌ ◍ ◎ ◯ ❍ ◉ ⦾ ⊙ ⦿ ⊜ ⊖ ⊘ ⊚ ⊛ ⊝ ● ⚫ ⦁ ◐ ◑ ◒ ◓ ◔ ◕ ⦶ ⦸ ◵ ◴ ◶ ◷ ⊕ ⊗ ⦇ ⦈ ⦉ ⦊ ❨ ❩ ⸨ ⸩ ◖ ◗ ❪ ❫ ❮ ❯ ❬ ❭ ❰ ❱ ⊏ ⊐ ⊑ ⊒ ◘ ◙ ◚ ◛ ◜ ◝ ◞ ◟ ◠ ◡ ⋒ ⋓ ⋐ ⋑ ╰ ╮ ╭ ╯ ⌒ ╳ ✕ ╱ ╲ ⧸ ⧹ ⌓ ◦ ❖ ✖ ✚ ✜ ⧓ ⧗ ⧑ ⧒ ⧖ _ ⚊ ╴ ╼ ╾ ‐ ⁃ ‑ ‒ - – ⎯ — ― ╶ ╺ ╸ ─ ━ ┄ ┅ ┈ ┉ ╌ ╍ ═ ≣ ≡ ☰ ☱ ☲ ☳ ☴ ☵ ☶ ☷ ╵ ╷ ╹ ╻ │ ▕ ▏ ┃ ┆ ┇ ┊ ╎ ┋ ╿ ╽ ┌ ┍ ┎ ┏ ┐ ┑ ┒ ┓ └ ┕ ┖ ┗ ┘ ┙ ┚ ┛ ├ ┝ ┞ ┟ ┠ ┡ ┢ ┣ ┤ ┥ ┦ ┧ ┨ ┩ ┪ ┫ ┬ ┭ ┮ ┳ ┴ ┵ ┶ ┷ ┸ ┹ ┺ ┻ ┼ ┽ ┾ ┿ ╀ ╁ ╂ ╃ ╄ ╅ ╆ ╇ ╈ ╉ ╊ ╋ ╏ ║ ╔ ╒ ╓ ╕ ╖ ╗ ╚ ╘ ╙ ╛ ╜ ╝ ╞ ╟ ╠ ╡ ╢ ╣ ╤ ╥ ╦ ╧ ╨ ╩ ╪ ╫ ╬ ⌞ ⌟ ⌜ ⌝ ⌊ ⌋ ⌉ ⌈ ⌋ ₯ ἀ ἁ ἂ ἃ ἄ ἅ ἆ ἇ Ἀ Ἁ Ἂ Ἃ Ἄ Ἅ Ἆ Ἇ ἐ ἑ ἒ ἓ ἔ ἕ Ἐ Ἑ Ἒ Ἓ Ἔ Ἕ ἠ ἡ ἢ ἣ ἤ ἥ ἦ ἧ Ἠ Ἡ Ἢ Ἣ Ἤ Ἥ Ἦ Ἧ ἰ ἱ ἲ ἳ ἴ ἵ ἶ ἷ Ἰ Ἱ Ἲ Ἳ Ἴ Ἵ Ἶ Ἷ ὀ ὁ ὂ ὃ ὄ ὅ Ὀ Ὁ Ὂ Ὃ Ὄ Ὅ ὐ ὑ ὒ ὓ ὔ ὕ ὖ ὗ Ὑ Ὓ Ὕ Ὗ ὠ ὡ ὢ ὣ ὤ ὥ ὦ ὧ Ὠ Ὡ Ὢ Ὣ Ὤ Ὥ Ὦ Ὧ ὰ ά ὲ έ ὴ ή ὶ ί ὸ ό ὺ ύ ὼ ώ ᾀ ᾁ ᾂ ᾃ ᾄ ᾅ ᾆ ᾇ ᾈ ᾉ ᾊ ᾋ ᾌ ᾍ ᾎ ᾏ ᾐ ᾑ ᾒ ᾓ ᾔ ᾕ ᾖ ᾗ ᾘ ᾙ ᾚ ᾛ ᾜ ᾝ ᾞ ᾟ ᾠ ᾡ ᾢ ᾣ ᾤ ᾥ ᾦ ᾧ ᾨ ᾩ ᾪ ᾫ ᾬ ᾭ ᾮ ᾯ ᾰ ᾱ ᾲ ᾳ ᾴ ᾶ ᾷ Ᾰ Ᾱ Ὰ Ά ᾼ ᾽ ι ᾿ ῀ ῁ ῂ ῃ ῄ ῆ ῇ Ὲ Έ Ὴ Ή ῌ ῍ ῎ ῏ ῐ ῑ ῒ ΐ ῖ ῗ Ῐ Ῑ Ὶ Ί ῝ ῞ ῟ ῠ ῡ ῢ ΰ ῤ ῥ ῦ ῧ Ῠ Ῡ Ὺ Ύ Ῥ ῭ ΅ ` ῲ ῳ ῴ ῶ ῷ Ὸ Ό Ὼ Ώ ῼ ´ ῾ Ͱ ͱ Ͳ ͳ ʹ ͵ Ͷ ͷ ͺ ͻ ͼ ͽ ; ΄ ΅ Ά · Έ Ή Ί Ό Ύ Ώ ΐ Α Β Γ Δ Ε Ζ Η Θ Ι Κ Λ Μ Ν Ξ Ο Π Ρ Σ Τ Υ Φ Χ Ψ Ω Ϊ Ϋ ά έ ή ί ΰ α β γ δ ε ζ η θ ι κ λ μ ν ξ ο π ρ ς σ τ υ φ χ ψ ω ϊ ϋ ό ύ ώ ϐ ϑ ϒ ϓ ϔ ϕ ϖ ϗ Ϙ ϙ Ϛ ϛ Ϝ ϝ Ϟ ϟ Ϡ ϡ Ϣ ϣ Ϥ ϥ Ϧ ϧ Ϩ ϩ Ϫ ϫ Ϭ ϭ Ϯ ϯ ϰ ϱ ϲ ϳ ϴ ϵ ϶ Ϸ ϸ Ϲ Ϻ ϻ ϼ Ͻ Ͼ Ͽ Ⓐ ⓐ ⒜ A a Ạ ạ Ả ả Ḁ ḁ Â Ã Ǎ ǎ Ấ ấ Ầ ầ Ẩ ẩ Ȃ ȃ Ẫ ẫ Ậ ậ À Á Ắ ắ Ằ ằ Ẳ ẳ Ẵ ẵ Ặ ặ Ā ā Ą ą Ǟ Ȁ ȁ Å Ǻ ǻ Ä ä ǟ Ǡ ǡ â á å ã à ẚ Ȧ ȧ Ⱥ Å ⱥ Æ æ Ǽ Ǣ ǣ Ɐ Ꜳ ꜳ Ꜹ Ꜻ Ɑ ꜹ ꜻ ª ℀ ⅍ ℁ Ⓑ ⓑ ⒝ B b Ḃ ḃ Ḅ ḅ Ḇ ḇ Ɓ Ƀ ƀ ƃ Ƃ Ƅ ƅ ℬ Ⓒ ⓒ ⒞ C c Ḉ ḉ Ć ć Ĉ ĉ Ċ ċ Č č Ç ç Ƈ ƈ Ȼ ȼ ℂ ℃ ℭ Ɔ ℅ ℆ ℄ Ꜿ ꜿ Ⓓ ⓓ ⒟ D d Ḋ ḋ Ḍ ḍ Ḏ ḏ Ḑ ḑ Ḓ ḓ Ď ď Ɗ Ƌ ƌ Ɖ Đ đ ȡ ⅅ ⅆ Ǳ ǲ ǳ Ǆ ǅ ǆ ȸ Ⓔ ⓔ ⒠ E e Ḕ ḕ Ḗ ḗ Ḙ ḙ Ḛ ḛ Ḝ ḝ Ẹ ẹ Ẻ ẻ Ế ế Ẽ ẽ Ề ề Ể ể Ễ ễ Ệ ệ Ē ē Ĕ ĕ Ė ė Ę ę Ě ě È è É é Ê ê Ë ë Ȅ ȅ Ȩ ȩ Ȇ ȇ Ǝ ⱸ Ɇ ℇ ℯ ℮ Ɛ ℰ Ə ǝ ⱻ ɇ Ⓕ ⓕ ⒡ F f Ḟ ḟ Ƒ ƒ ꜰ Ⅎ ⅎ ꟻ ℱ ℻ Ⓖ ⓖ ⒢ G g Ɠ Ḡ ḡ Ĝ ĝ Ğ ğ Ġ ġ Ģ ģ Ǥ ǥ Ǧ ǧ Ǵ ℊ ⅁ ǵ Ⓗ ⓗ ⒣ H h Ḣ ḣ Ḥ ḥ Ḧ ḧ Ḩ ḩ Ḫ ḫ ẖ Ĥ ĥ Ȟ ȟ Ħ ħ Ⱨ ⱨ Ꜧ ℍ Ƕ ℏ ℎ ℋ ℌ ꜧ Ⓘ ⓘ ⒤ I i Ḭ ḭ Ḯ ḯ Ĳ ĳ ì í î ï Ì Í Î Ï Ĩ ĩ Ī ī Ĭ ĭ Į į ı Ɨ ƚ Ỻ Ǐ ǐ ⅈ ⅉ ℹ ℑ ℐ Ⓙ ⓙ ⒥ J j Ĵ ĵ ȷ ⱼ Ɉ ɉ ǰ Ⓚ ⓚ ⒦ K k Ḱ ḱ Ḳ ḳ Ḵ ḵ Ķ ķ Ƙ ƙ Ꝁ ꝁ Ꝃ ꝃ Ꝅ ꝅ Ǩ ǩ Ⱪ ⱪ ĸ Ⓛ ⓛ ⒧ L l Ḷ ḷ Ḹ ḹ Ḻ ḻ Ḽ ḽ Ĺ ĺ Ļ ļ Ľ İ ľ Ŀ ŀ Ł ł Ỉ ỉ Ị ị Ƚ Ⱡ Ꝉ ꝉ ⱡ Ɫ ꞁ ℒ Ǉ ǈ ǉ ⅃ ⅂ ℓ ȉ Ȉ Ȋ ȋ Ⓜ ⓜ ⒨ M m Ḿ ḿ Ṁ ṁ Ṃ ṃ ꟿ ꟽ Ɱ Ʃ Ɯ ℳ Ⓝ ⓝ ⒩ N n Ṅ ṅ Ṇ ṇ Ṉ ṉ Ṋ ṋ Ń ń Ņ ņ Ň ň Ǹ ǹ Ŋ Ɲ ñ ŉ Ñ Ƞ ƞ ŋ Ǌ ǋ ǌ ȵ ℕ №   O o Ṍ ṍ Ṏ ṏ Ṑ ṑ Ṓ ṓ Ȫ ȫ Ȭ ȭ Ȯ ȯ Ȱ ȱ Ǫ ǫ Ǭ ǭ Ọ ọ Ỏ ỏ Ố ố Ồ ồ Ổ ổ Ỗ ỗ Ộ ộ Ớ ớ Ờ ờ Ở ở Ỡ ỡ Ợ ợ Ơ ơ Ō ō Ŏ ŏ Ő ő Ò Ó Ô Õ Ö Ǒ Ȍ ȍ Ȏ ȏ Œ œ Ø Ǿ Ꝋ ǽ ǿ ℴ ⍥ ⍤ Ⓞ ⓞ ⒪ ò ó ô õ ö ǒ ø Ꝏ ꝏ Ⓟ ⓟ ⒫ ℗ P p Ṕ ṕ Ṗ ṗ Ƥ ƥ Ᵽ ℙ Ƿ ꟼ ℘ Ⓠ ⓠ ⒬ Q q Ɋ ɋ ℚ ℺ ȹ Ⓡ ⓡ ⒭ R r Ŕ ŕ Ŗ ŗ Ř ř Ṙ ṙ Ṛ ṛ Ṝ ṝ Ṟ ṟ Ȑ ȑ Ȓ ȓ ɍ Ɍ Ʀ Ɽ ℞ Ꝛ ꝛ ℜ ℛ ℟ ℝ Ⓢ ⓢ ⒮ S s Ṡ ṡ Ṣ ṣ Ṥ ṥ Ṧ ṧ Ṩ ṩ Ś ś Ŝ ŝ Ş ş Š š Ș ș ȿ ꜱ Ƨ ƨ ẞ ß ẛ ẜ ẝ ℠ Ⓣ ⓣ ⒯ T t Ṫ ṫ Ṭ ṭ Ṯ ṯ Ṱ ṱ Ţ ţ Ť ť Ŧ ŧ Ƭ Ʈ ẗ Ț Ⱦ ƫ ƭ ț ⱦ ȶ ℡ ™ Ⓤ ⓤ ⒰ U u Ṳ ṳ Ṵ ṵ Ṷ ṷ Ṹ ṹ Ṻ ṻ Ụ Ủ ủ Ứ Ừ ụ ứ Ử ử ừ ữ Ữ Ự ự Ũ ũ Ū ū Ŭ ŭ Ů ů Ű ű Ǚ ǚ Ǘ ǘ Ǜ ǜ Ų ų Ǔ ǔ Ȕ ȕ Û û Ȗ ȗ Ù ù Ü ü Ư ú Ʉ ư Ʋ Ʊ Ⓥ ⓥ ⒱ V v Ṽ ṽ Ṿ ṿ Ỽ Ʌ ℣ ⱱ ⱴ ⱽ Ⓦ ⓦ ⒲ W w Ẁ ẁ Ẃ ẃ Ẅ ẅ Ẇ ẇ Ẉ ẉ Ŵ ŵ ẘ Ⱳ ⱳ Ⓧ ⓧ ⒳ X x Ẋ ẋ Ẍ ẍ ℵ × Ⓨ ⓨ ⒴ y Y Ẏ ẏ Ỿ ỿ ẙ Ỳ ỳ Ỵ ỵ Ỷ ỷ Ỹ ỹ Ŷ ŷ Ƴ ƴ Ÿ ÿ Ý ý Ɏ ɏ Ȳ Ɣ ⅄ ȳ ℽ Ⓩ ⓩ ⒵ Z z Ẑ ẑ Ẓ ẓ Ẕ ẕ Ź ź Ż ż Ž ž Ȥ ȥ Ⱬ ⱬ Ƶ ƶ ɀ ℨ ℤ ⟀ ⟁ ⟂ ⟃ ⟄ ⟇ ⟈ ⟉ ⟊ ⟐ ⟑ ⟒ ⟓ ⟔ ⟕ ⟖ ⟗ ⟘ ⟙ ⟚ ⟛ ⟜ ⟝ ⟞ ⟟ ⟠ ⟡ ⟢ ⟣ ⟤ ⟥ ⟦ ⟧ ⟨ ⟩ ⟪ ⟫ ⦀ ⦁ ⦂ ⦃ ⦄ ⦅ ⦆ ⦇ ⦈ ⦉ ⦊ ⦋ ⦌ ⦍ ⦎ ⦏ ⦐ ⦑ ⦒ ⦓ ⦔ ⦕ ⦖ ⦗ ⦘ ⦙ ⦚ ⦛ ⦜ ⦝ ⦞ ⦟ ⦠ ⦡ ⦢ ⦣ ⦤ ⦥ ⦦ ⦧ ⦨ ⦩ ⦪ ⦫ ⦬ ⦭ ⦮ ⦯ ⦰ ⦱ ⦲ ⦳ ⦴ ⦵ ⦶ ⦷ ⦸ ⦹ ⦺ ⦻ ⦼ ⦽ ⦾ ⦿ ⧀ ⧁ ⧂ ⧃ ⧄ ⧅ ⧆ ⧇ ⧈ ⧉ ⧊ ⧋ ⧌ ⧍ ⧎ ⧏ ⧐ ⧑ ⧒ ⧓ ⧔ ⧕ ⧖ ⧗ ⧘ ⧙ ⧚ ⧛ ⧜ ⧝ ⧞ ⧟ ⧡ ⧢ ⧣ ⧤ ⧥ ⧦ ⧧ ⧨ ⧩ ⧪ ⧫ ⧬ ⧭ ⧮ ⧯ ⧰ ⧱ ⧲ ⧳ ⧴ ⧵ ⧶ ⧷ ⧸ ⧹ ⧺ ⧻ ⧼ ⧽ ⧾ ⧿ ∀ ∁ ∂ ∃ ∄ ∅ ∆ ∇ ∈ ∉ ∊ ∋ ∌ ∍ ∎ ∏ ∐ ∑ − ∓ ∔ ∕ ∖ ∗ ∘ ∙ √ ∛ ∜ ∝ ∞ ∟ ∠ ∡ ∢ ∣ ∤ ∥ ∦ ∧ ∨ ∩ ∪ ∫ ∬ ∭ ∮ ∯ ∰ ∱ ∲ ∳ ∴ ∵ ∶ ∷ ∸ ∹ ∺ ∻ ∼ ∽ ∾ ∿ ≀ ≁ ≂ ≃ ≄ ≅ ≆ ≇ ≈ ≉ ≊ ≋ ≌ ≍ ≎ ≏ ≐ ≑ ≒ ≓ ≔ ≕ ≖ ≗ ≘ ≙ ≚ ≛ ≜ ≝ ≞ ≟ ≠ ≡ ≢ ≣ ≤ ≥ ≦ ≧ ≨ ≩ ≪ ≫ ≬ ≭ ≮ ≯ ≰ ≱ ≲ ≳ ≴ ≵ ≶ ≷ ≸ ≹ ≺ ≻ ≼ ≽ ≾ ≿ ⊀ ⊁ ⊂ ⊃ ⊄ ⊅ ⊆ ⊇ ⊈ ⊉ ⊊ ⊋ ⊌ ⊍ ⊎ ⊏ ⊐ ⊑ ⊒ ⊓ ⊔ ⊕ ⊖ ⊗ ⊘ ⊙ ⊚ ⊛ ⊜ ⊝ ⊞ ⊟ ⊠ ⊡ ⊢ ⊣ ⊤ ⊥ ⊦ ⊧ ⊨ ⊩ ⊪ ⊫ ⊬ ⊭ ⊮ ⊯ ⊰ ⊱ ⊲ ⊳ ⊴ ⊵ ⊶ ⊷ ⊸ ⊹ ⊺ ⊻ ⊼ ⊽ ⊾ ⊿ ⋀ ⋁ ⋂ ⋃ ⋄ ⋅ ⋆ ⋇ ⋈ ⋉ ⋊ ⋋ ⋌ ⋍ ⋎ ⋏ ⋐ ⋑ ⋒ ⋓ ⋔ ⋕ ⋖ ⋗ ⋘ ⋙ ⋚ ⋛ ⋜ ⋝ ⋞ ⋟ ⋠ ⋡ ⋢ ⋣ ⋤ ⋥ ⋦ ⋧ ⋨ ⋩ ⋪ ⋫ ⋬ ⋭ ⋮ ⋯ ⋰ ⋱ ⋲ ⋳ ⋴ ⋵ ⋶ ⋷ ⋸ ⋹ ⋺ ⋻ ⋼ ⋽ ⋾ ⋿ ✕ ✖ ✚ ◀ ▶ ❝ ❞ ★ ☆ ☼ ☂ ☺ ☹ ✄ ✈ ✌ ✎ ♪ ♫ ☀ ☁ ☔ ⚡ ❆ ☽ ☾ ✆ ✔ ☯ ☮ ☠ ☬ ✄ ✏ ♰ ✡ ✰ ✺ ♕ ♛ ♚ ♬ ⓐ ⓑ ⓒ ⓓ ↺ ↻ ⇖ ⇗ ⇘ ⇙ ⟵ ⟷ ⟶ ⤴ ⤵ ⤶ ⤷ ➫ ➬ € ₤ ＄ ₩ ₪ ⟁ ⟐ ◆ ⎔ ░ ▢ ⊡ ▩ ⟡ ◎ ◵ ⊗ ❖ Ω β Φ Σ Ξ ⟁ ⦻ ⧉ ⧭ ⧴ ∞ ≌ ⊕ ⋍ ⋰ ⋱ ✖ ⓵ ⓶ ⓷ ⓸ ⓹ ⓺ ⓻ ⓼ ⓽ ⓾ ᴕ ⸨ ⸩ ❪ ❫ ⓵ ⓶ ⓷ ⓸ ⓹ ⓺ ⓻ ⓼ ⓽ ⓾ ⒈ ⒉ ⒊ ⒋ ⒌ ⒍ ⒎ ⒏ ⒐ ⒑ ⒒ ⒓ ⒔ ⒕ ⒖ ⒗ ⒘ ⒙ ⒚ ⒛ ⓪ ① ② ③ ④ ⑤ ⑥ ⑦ ⑧ ⑨ ⑩ ➀ ➁ ➂ ➃ ➄ ➅ ➆ ➇ ➈ ➉ ⑪ ⑫ ⑬ ⑭ ⑮ ⑯ ⑰ ⑱ ⑲ ⑳ ⓿ ❶ ❷ ❸ ❹ ❺ ❻ ❼ ❽ ❾ ❿ ➊ ➋ ➌ ➍ ➎ ➏ ➐ ➑ ➒ ➓ ⓫ ⓬ ⓭ ⓮ ⓯ ⓰ ⓱ ⓲ ⓳ ⓴ ⑴ ⑵ ⑶ ⑷ ⑸ ⑹ ⑺ ⑻ ⑼ ⑽ ⑾ ⑿ ⒀ ⒁ ⒂ ⒃ ⒄ ⒅ ⒆ ⒇ ᶅ ᶛ ᶜ ᶝ ᶞ ᶟ ᶠ ᶡ ᶢ ᶣ ᶤ ᶥ ᶦ ᶧ ᶨ ᶩ ᶪ ᶫ ᶬ ᶭ ᶮ ᶯ ᶰ ᶱ ᶲ ᶳ ᶴ ᶵ ᶶ ᶷ ᶹ ᶺ ᶻ ᶼ ᶽ ᶾ ᶿ ᴀ ᴁ ᴂ ᴃ ᴄ ᴅ ᴆ ᴇ ᴈ ᴉ ᴊ ᴋ ᴌ ᴍ ᴎ ᴏ ᴐ ᴑ ᴒ ᴓ ᴔ ᴕ ᴖ ᴗ ᴘ ᴙ ᴚ ᴛ ᴜ ᴝ ᴞ ᴟ ᴠ ᴡ ᴢ ᴣ ᴤ ᴥ ᴦ ᴧ ᴨ ᴩ ᴪ ᴫ ᴬ ᴭ ᴮ ᴯ ᴰ ᴱ ᴲ ᴳ ᴴ ᴵ ᴶ ᴷ ᴸ ᴹ ᴺ ᴻ ᴼ ᴽ ᴾ ᴿ ᵀ ᵁ ᵂ ᵃ ᵄ ᵅ ᵆ ᵇ ᵈ ᵉ ᵊ ᵋ ᵌ ᵍ ᵎ ᵏ ᵐ ᵑ ᵒ ᵓ ᵔ ᵕ ᵖ ᵗ ᵘ ᵙ ᵚ ᵛ ᵜ ᵝ ᵞ ᵟ ᵠ ᵡ ᵢ ᵣ ᵤ ᵥ ᵦ ᵧ ᵨ ᵩ ᵪ ᵫ ᵬ ᵭ ᵮ ᵱ ᵲ ᵳ ᵵ ᵷ ᵸ ᵺ ᵻ ᷋ ᷌ ᷍ ᷎ ᷏ ᷓ ᷔ ᷕ ᷖ ᷗ ᷘ ᷙ ᷛ ᷜ ᷝ ᷞ ᷟ ᷠ ᷡ ᷢ ᷣ ᷤ ᷥ ᷦ ‘ ’ ‛ ‚ „  « » ‹ › Ꞌ  ❛ ❜ ❝ ❞ < > @ ‧ ¨ ․ ꞉ : ⁚ ⁝ ⁞ ‥ … ⁖ ⸪ ⸬ ⸫ ⸭ ⁛ ⁘ ⁙ ⁏ ; ⦂ ⁃ ‐ ‑ ‒ - – ⎯ — ― _ ⁓ ⸛ ⸞ ⸟ ⸯ ¬  | ⎜ ¦ ‖ ‗ † ‡ · • ⸰ ° ‣ ⁒ % ‰ ‱ & ⅋ § ÷ + ± = ꞊ ′ ″ ‴ ⁗ ‵ ‶ ‷ ‸ * ⁑ ⁎ ⁕ ※ ⁜ ⁂ ! ‼ ¡ ? ¿ ⸮ ⁇ ⁉ ⁈ ‽ ⸘ ¼ ½ ¾ ² ³ © ® ™ ℠ ℻ ℅ ℁ ⅍ ℄ ¶ ⁋ ❡ ⁌ ⁍ ⸖ ⸗ ⸚ ⸓ ( ) [ ] { } ⸨ ⸩ ❨ ❩ ❪ ❫ ⸦ ⸧ ❬ ❭ ❮ ❯ ❰ ❱ ❴ ❵ ❲ ❳ ⦗ ⦘ ⁅ ⁆ 〈 〉 ⏜ ⏝ ⏞ ⏟ ⸡ ⸠ ⸢ ⸣ ⸤ ⸥ ⎡ ⎤ ⎣ ⎦ ⎨ ⎬ ⌠ ⌡ ⎛ ⎠ ⎝ ⎞ ⁀ ⁔ ‿ ⁐ ‾ ⎟ ⎢ ⎥ ⎪ ꞁ ⎮ ⎧ ⎫ ⎩ ⎭ ⎰ ⎱ ✈ ☀ ☼ ☁ ☂ ☔ ⚡ ❄ ❅ ❆ ☃ ☉ ☄ ★ ☆ ☽ ☾ ⌛ ⌚ ☇ ☈ ⌂ ⌁ ✆ ☎ ☏ ☑ ✓ ✔ ⎷ ⍻ ✖ ✗ ✘ ☒ ✕ ☓ ☕ ♿ ✌ ☚ ☛ ☜ ☝ ☞ ☟ ☹ ☺ ☻ ☯ ⚘ ☮ ✝ ⚰ ⚱ ⚠ ☠ ☢ ⚔ ⚓ ⎈ ⚒ ☡ ❂ ⚕ ⚖ ⚗ ✇ ☣ ⚙ ☤ ⚚ ⚜ ☥ ☦ ☧ ☨ ☩ † ☪ ☫ ☬ ☭ ✁ ✂ ✃ ✄ ✍ ✎ ✏ ✐  ✑ ✒ ✉ ✙ ✚ ✜ ✛ ♰ ♱ ✞ ✟ ✠ ✡ ☸ ✢ ✣ ✤ ✥ ✦ ✧ ✩ ✪ ✫ ✬ ✭ ✮ ✯ ✰ ✲ ✱ ✳ ✴ ✵ ✶ ✷ ✸ ✹ ✺ ✻ ✼ ✽ ✾ ❀ ✿ ❁ ❃ ❇ ❈ ❉ ❊ ❋ ⁕ ☘ ❦ ❧ ☙ ❢ ❣ ♀ ♂ ⚤ ⚦ ⚧ ⚨ ⚩ ☿ ♁ ⚯ ♔ ♕ ♖ ♗ ♘ ♙ ♚ ♛ ♜ ♝ ♞ ♟ ☖ ☗ ♠ ♣ ♦ ♥ ❤ ❥ ♡ ♢ ♤ ♧ ⚀ ⚁ ⚂ ⚃ ⚄ ⚅ ⚇ ⚆ ⚈ ⚉ ♨ ♩ ♪ ♫ ♬ ♭ ♮ ♯ ⏏ ⎗ ⎘ ⎙ ⎚ ⎇ ⌘ ⌦ ⌫ ⌧ ♲ ♳ ♴ ♵ ♶ ♷ ♸ ♹ ♻ ♼ ♽ ⁌ ⁍ ⎌ ⌇ ⍝ ⍟ ⍣ ⍤ ⍥ ⍨ ⍩ ⎋ ♃ ♄ ♅ ♆ ♇ ♈ ♉ ♊ ♋ ♌ ♍ ♎ ♏ ♐ ♑ ♒ ♓ ⏚ ⏛ |   |   |   |   |   |   |   |   |   | ​ |";
            int errorCode = val.checkForInput(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if checkForInput accepts invalid limit input of no input
        * 
        * \ <b> Name of Method</b>
        * checkForInput_inValidProperties_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is input needed error code
        * 
        * \ <b> Actual Result</b>
        * Recived proper error code "InputNeeded" 
        */
        [TestMethod]
        public void checkForInput_inValidProperties_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "";
            int errorCode = val.checkForInput(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.InputNeeded, errorCode);
        }
        //validateName_______________________________________________________________________
        /**
       * \brief: This unit test will check if validateName accepts valid input
       * 
       * \ <b> Name of Method</b>
       * validateName_ValidProperties_ReturnsNoError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is normal/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "Mr.John-Smith's"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is no error code
       * 
       * \ <b> Actual Result</b>
       * There is no error code. 
       */
        [TestMethod]
        public void validateName_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "Mr.John-Smith's";
            int errorCode = val.validateName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
       * \brief: This unit test will check if validateName accepts invalid length limit input
       * 
       * \ <b> Name of Method</b>
       * validateName_inValidPropertiesInputTooLong_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is boundary/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(for as many times intil it is 1 larger then max string length)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a inputTooLong error code
       * 
       * \ <b> Actual Result</b>
       * There is a inputTooLong error code. 
       */
        [TestMethod]
        public void validateName_inValidPropertiesInputTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxNameLength);
            int errorCode = val.validateName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
       * \brief: This unit test will check if validateName accepts invalid characters input
       * 
       * \ <b> Name of Method</b>
       * validateName_inValidPropertiesInvalidCharacters_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is exception/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "3rd"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a InvalidCharacters error code
       * 
       * \ <b> Actual Result</b>
       * There is a InvalidCharacters error code. 
       */
        [TestMethod]
        public void validateName_inValidPropertiesInvalidCharacters_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "3rd";
            int errorCode = val.validateName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.InvalidCharacters, errorCode);
        }
        //validateUserName_______________________________________________________________________
        /**
       * \brief: This unit test will check if validateUserName accepts valid input
       * 
       * \ <b> Name of Method</b>
       * validateUserName_ValidProperties_ReturnsNoError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is normal/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "xxxJohn-Smithxxx"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is no error code
       * 
       * \ <b> Actual Result</b>
       * There is no error code. 
       */
        [TestMethod]
        public void validateUserName_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "xxxJohn-Smithxxx";
            int errorCode = val.validateUserName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
       * \brief: This unit test will check if validateUserName accepts invalid input of too few characters
       * 
       * \ <b> Name of Method</b>
       * validateUserName_inValidPropertiesTooShort_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is exception/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(min input length minus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a TooShort error code
       * 
       * \ <b> Actual Result</b>
       * There is a TooShort error code. 
       */
        [TestMethod]
        public void validateUserName_inValidPropertiesTooShort_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "";
            while (dataToPassIn.Length < (Validation.consts.MinLength - 1))
            {
                dataToPassIn += "a";
            }
            int errorCode = val.validateUserName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.TooShort, errorCode);
        }
        /**
       * \brief: This unit test will check if validateUserName accepts invalid input of too many characters
       * 
       * \ <b> Name of Method</b>
       * validateUserName_inValidPropertiesInputTooLong_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is boundary/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(for max username lenght plus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a TooLong error code
       * 
       * \ <b> Actual Result</b>
       * There is a TooLong error code. 
       */
        [TestMethod]
        public void validateUserName_inValidPropertiesInputTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxUserNameLength);
            int errorCode = val.validateUserName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        //validatePassword_______________________________________________________________________
        /**
       * \brief: This unit test will check if validatePassword accepts valid input
       * \ <b> Name of Method</b>
       * validatePassword_ValidProperties_ReturnsNoError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is normal/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "7GitGudp@$$wrd"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is no error code
       * 
       * \ <b> Actual Result</b>
       * There is no error code. 
       */
        [TestMethod]
        public void validatePassword_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "7GitGudp@$$wrd";
            int errorCode = val.validatePassword(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
       * \brief: This unit test will check if validatePassword accepts invalid input that is too short
       * \ <b> Name of Method</b>
       * validatePassword_inValidPropertiesTooShort_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is boundary/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(max length minus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a TooShort error code
       * 
       * \ <b> Actual Result</b>
       * There is a TooShort error code. 
       */
        [TestMethod]
        public void validatePassword_inValidPropertiesTooShort_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "";
            while (dataToPassIn.Length < (Validation.consts.MinLength - 1))
            {
                dataToPassIn += "a";
            }
            int errorCode = val.validatePassword(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.TooShort, errorCode);
        }
        /**
       * \brief: This unit test will check if validatePassword accepts invalid input that is too Long
       * \ <b> Name of Method</b>
       * validatePassword_inValidPropertiesInputTooLong_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is boundary/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(max length plus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a inputTooLong error code
       * 
       * \ <b> Actual Result</b>
       * There is a inputTooLong error code. 
       */
        [TestMethod]
        public void validatePassword_inValidPropertiesInputTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxPasswordLength);
            int errorCode = val.validatePassword(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        //validateCompanyName_______________________________________________________________________
        /**
       * \brief: This unit test will check if validateCompanyName accepts valid input
       * \ <b> Name of Method</b>
       * validateCompanyName_ValidProperties_ReturnsNoError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is normal/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "validCompanyName"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is no code
       * 
       * \ <b> Actual Result</b>
       * There is no error code. 
       */
        [TestMethod]
        public void validateCompanyName_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "validCompanyName";
            int errorCode = val.validateCompanyName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        //validateCompanyName_______________________________________________________________________
        /**
       * \brief: This unit test will check if validateCompanyName accepts invalid too long input
       * \ <b> Name of Method</b>
       * validateCompanyName_inValidPropertiesInputTooLong_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is boundary/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(max length plus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a inputTooLong code
       * 
       * \ <b> Actual Result</b>
       * There is inputTooLong error code. 
       */
        [TestMethod]
        public void validateCompanyName_inValidPropertiesInputTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxCompanyLength);
            int errorCode = val.validateCompanyName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        //validateStoreName_______________________________________________________________________
        /**
      * \brief: This unit test will check if validateStoreName accepts valid input
      * \ <b> Name of Method</b>
      * validateStoreName_ValidProperties_ReturnsNoError
      * 
      * \ <b> How test is Conducted</b>
      * This test is run automatically
      * 
      * \ <b> Type of Test</b>
      * The type of test is normal/functional/unit testing.
      * 
      * \ <b> Sample Data Sets</b>
      * "validStoreName"
      * 
      * \ <b> Expected Result</b>
      * The expected result is that there is no error code
      * 
      * \ <b> Actual Result</b>
      * There is no error code. 
      */
        [TestMethod]
        public void validateStoreName_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "validStoreName";
            int errorCode = val.validateStoreName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
      * \brief: This unit test will check if validateStoreName accepts invalid too long input
      * \ <b> Name of Method</b>
      * validateStoreName_inValidPropertiesInputTooLong_ReturnsError
      * 
      * \ <b> How test is Conducted</b>
      * This test is run automatically
      * 
      * \ <b> Type of Test</b>
      * The type of test is boundary/functional/unit testing.
      * 
      * \ <b> Sample Data Sets</b>
      * "a"(max string length plus one)
      * 
      * \ <b> Expected Result</b>
      * The expected result is that there is a inputTooLong error code
      * 
      * \ <b> Actual Result</b>
      * There is inputTooLong error code. 
      */
        [TestMethod]
        public void validateStoreName_inValidPropertiesInputTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxStoreLength);
            int errorCode = val.validateStoreName(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        //validateStoreDivider_______________________________________________________________________
      /**
      * \brief: This unit test will check if validateStoreDivider accepts valid input
      * \ <b> Name of Method</b>
      * validateStoreDivider_ValidPropertiesInt_ReturnsNoError
      * 
      * \ <b> How test is Conducted</b>
      * This test is run automatically
      * 
      * \ <b> Type of Test</b>
      * The type of test is normal/functional/unit testing.
      * 
      * \ <b> Sample Data Sets</b>
      * "12")
      * 
      * \ <b> Expected Result</b>
      * The expected result is that there is no error code
      * 
      * \ <b> Actual Result</b>
      * There is no error code. 
      */
        [TestMethod]
        public void validateStoreDivider_ValidPropertiesInt_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "12";
            int errorCode = val.validateStoreDivider(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
      * \brief: This unit test will check if validateStoreDivider accepts valid float number input
      * \ <b> Name of Method</b>
      * validateStoreDivider_ValidPropertiesFloat_ReturnsNoError
      * 
      * \ <b> How test is Conducted</b>
      * This test is run automatically
      * 
      * \ <b> Type of Test</b>
      * The type of test is normal/functional/unit testing.
      * 
      * \ <b> Sample Data Sets</b>
      * "12.2")
      * 
      * \ <b> Expected Result</b>
      * The expected result is that there is no error code
      * 
      * \ <b> Actual Result</b>
      * There is no error code. 
      */
        [TestMethod]
        public void validateStoreDivider_ValidPropertiesFloat_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "12.2";
            int errorCode = val.validateStoreDivider(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreDivider accepts invalid non number input
        * \ <b> Name of Method</b>
        * validateStorDivider_inValidPropertiesNotNumber_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "not a number")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notNumber error code
        * 
        * \ <b> Actual Result</b>
        * There is a notNumber error code. 
        */
        [TestMethod]
        public void validateStorDivider_inValidPropertiesNotNumber_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "not a number";
            int errorCode = val.validateStoreDivider(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notNumber, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreDivider accepts invalid negative number input
        * \ <b> Name of Method</b>
        * validateStorDivider_inValidPropertiesNegativeNumber_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "-12")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputMustBePositive error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputMustBePositive error code. 
        */
        [TestMethod]
        public void validateStorDivider_inValidPropertiesNegativeNumber_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "-12";
            int errorCode = val.validateStoreDivider(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputMustBePositive, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreDivider accepts invalid zero number input
        * \ <b> Name of Method</b>
        * validateStorDivider_inValidPropertiesZero_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is boundary/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "0")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputMustBePositive error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputMustBePositive error code. 
        */
        [TestMethod]
        public void validateStorDivider_inValidPropertiesZero_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "0";
            int errorCode = val.validateStoreDivider(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputMustBePositive, errorCode);
        }
        //validateStoreAvgHrs_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateStoreAvgHrs accepts valid number input
        * \ <b> Name of Method</b>
        * validateStoreAvgHrs_ValidPropertiesInt_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "12")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void validateStoreAvgHrs_ValidPropertiesInt_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "12";
            int errorCode = val.validateStoreAvgHrs(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreAvgHrs accepts valid float number input
        * \ <b> Name of Method</b>
        * validateStoreAvgHrs_ValidPropertiesFloat_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "12.2")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        public void validateStoreAvgHrs_ValidPropertiesFloat_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "12.2";
            int errorCode = val.validateStoreAvgHrs(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreAvgHrs accepts invalid non number input
        * \ <b> Name of Method</b>
        * validateStoreAvgHrs_inValidPropertiesNotNumber_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "not a number")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notNumber error code
        * 
        * \ <b> Actual Result</b>
        * There is a notNumber error code. 
        */
        [TestMethod]
        public void validateStoreAvgHrs_inValidPropertiesNotNumber_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "Not number";
            int errorCode = val.validateStoreAvgHrs(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notNumber, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreAvgHrs accepts invalid negative number input
        * \ <b> Name of Method</b>
        * validateStoreAvgHrs_inValidPropertiesNegative_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "-12")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputMustBePositive error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputMustBePositive error code. 
        */
        [TestMethod]
        public void validateStoreAvgHrs_inValidPropertiesNegative_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "-12";
            int errorCode = val.validateStoreAvgHrs(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputMustBePositive, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStoreAvgHrs accepts invalid zero number input
        * \ <b> Name of Method</b>
        * validateStoreAvgHrs_inValidPropertiesZero_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is boundary/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "0")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputMustBePositive error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputMustBePositive error code. 
        */
        [TestMethod]
        public void validateStoreAvgHrs_inValidPropertiesZero_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "0";
            int errorCode = val.validateStoreAvgHrs(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputMustBePositive, errorCode);
        }
        //validatePhoneNum_______________________________________________________________________
        /**
        * \brief: This unit test will check if validatePhoneNum accepts valid phone number input
        * \ <b> Name of Method</b>
        * validatePhoneNum_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "5191234567")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void validatePhoneNum_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "5191234567";
            int errorCode = val.validatePhoneNum(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePhoneNum accepts invalid too long phone number input
        * \ <b> Name of Method</b>
        * validatePhoneNum_inValidPropertiesTooLong_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "(519)-123-4567")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a pNumTooLong error code
        * 
        * \ <b> Actual Result</b>
        * There is a pNumTooLong error code. 
        */
        [TestMethod]
        public void validatePhoneNum_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "(519)-123-4567-123";
            int errorCode = val.validatePhoneNum(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.pNumTooLong, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePhoneNum accepts invalid too short phone number input
        * \ <b> Name of Method</b>
        * validatePhoneNum_inValidPropertiesTooShort_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "123-4567")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a pNumTooShort error code
        * 
        * \ <b> Actual Result</b>
        * There is a pNumTooShort error code. 
        */
        [TestMethod]
        public void validatePhoneNum_inValidPropertiesTooShort_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "123-4567";
            int errorCode = val.validatePhoneNum(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.pNumTooShort, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePhoneNum accepts invalid phone number input
        * \ <b> Name of Method</b>
        * validatePhoneNum_inValidPropertiesInvalidCharacters_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "----------")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notNumber error code
        * 
        * \ <b> Actual Result</b>
        * There is a notNumber error code. 
        */
        [TestMethod]
        public void validatePhoneNum_inValidPropertiesInvalidCharacters_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "----------";
            int errorCode = val.validatePhoneNum(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notNumber, errorCode);
        }
        //validateEmail_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateEmail accepts valid email input
        * \ <b> Name of Method</b>
        * validateEmail_ValidPropertiesCOM_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normally/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@email.com")
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void validateEmail_ValidPropertiesCOM_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "sample@email.com";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        //validateEmail_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateEmail accepts valid email input ending in .ca
        * \ <b> Name of Method</b>
        * validateEmail_ValidPropertiesCA_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normally/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@email.ca"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void validateEmail_ValidPropertiesCA_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "sample@email.ca";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid too long email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesTooLong_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "a"(max length plus one)
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputTooLong error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputTooLong error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxEmailLength);
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid too many at symbols email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesTooManyAtSymbols_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@@email.ca"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a tooManyAtSigns error code
        * 
        * \ <b> Actual Result</b>
        * There is a tooManyAtSigns error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesTooManyAtSymbols_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "sample@@email.ca";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.tooManyAtSigns, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid too many dots email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesTo0ManyDots_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@email..ca"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a tooManydots error code
        * 
        * \ <b> Actual Result</b>
        * There is a tooManydots error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesTo0ManyDots_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "sample@email..ca";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.tooManydots, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid missing at symbol email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesMissingAt_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sampleemail.ca"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a emailMissingAtSign error code
        * 
        * \ <b> Actual Result</b>
        * There is a emailMissingAtSign error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesMissingAt_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "sampleemail.ca";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.emailMissingAtSign, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid missing dot email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesMissingDot_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@emailca"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a emailMissingEmailEnding error code
        * 
        * \ <b> Actual Result</b>
        * There is a emailMissingEmailEnding error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesMissingDot_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "sample@emailca";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.emailMissingEmailEnding, errorCode);
        }
        /**
        * \brief: This unit test will check if validateEmail accepts invalid ending email input
        * \ <b> Name of Method</b>
        * validateEmail_inValidPropertiesInvalidEnding_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "sample@email.canado"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a emailMissingEmailEnding error code
        * 
        * \ <b> Actual Result</b>
        * There is a emailMissingEmailEnding error code. 
        */
        [TestMethod]
        public void validateEmail_inValidPropertiesInvalidEnding_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "sample@email.canado";
            int errorCode = val.validateEmail(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.emailMissingEmailEnding, errorCode);
        }
        //validateDateTime_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateDateTime accepts valid input
        * \ <b> Name of Method</b>
        * validateDateTime_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "DateTime.Now"
        * "DateTime.Now.AddHours((double)3)"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is no error code
        * 
        * \ <b> Actual Result</b>
        * There is no error code. 
        */
        [TestMethod]
        public void validateDateTime_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddHours((double)3);
            int errorCode = val.validateDateTime(start.ToString(), end.ToString());
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        //validateDateTime_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateDateTime accepts invalid data type input
        * \ <b> Name of Method</b>
        * validateDateTime_inValidPropertiesNotDateTime_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "not DateTime"
        * "NotDateTime"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notDateTime error code
        * 
        * \ <b> Actual Result</b>
        * There is a notDateTime error code. 
        */
        [TestMethod]
        public void validateDateTime_inValidPropertiesNotDateTime_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            int errorCode = val.validateDateTime("not DateTime", "NotDateTime");
            Assert.AreEqual(Validation.kErrorCodes.notDateTime, errorCode);
        }
        /**
        * \brief: This unit test will check if validateDateTime accepts invalid no data input
        * \ <b> Name of Method</b>
        * validateDateTime_inValidPropertiesNoInputBoth_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a InputNeeded error code
        * 
        * \ <b> Actual Result</b>
        * There is a InputNeeded error code. 
        */
        [TestMethod]
        public void validateDateTime_inValidPropertiesNoInputBoth_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            int errorCode = val.validateDateTime("", "");
            Assert.AreEqual(Validation.kErrorCodes.InputNeeded, errorCode);
        }
        /**
        * \brief: This unit test will check if validateDateTime accepts invalid no data for start input
        * \ <b> Name of Method</b>
        * validateDateTime_inValidPropertiesNoInputBoth_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * "end.ToString()"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a InputNeeded error code
        * 
        * \ <b> Actual Result</b>
        * There is a InputNeeded error code. 
        */
        [TestMethod]
        public void validateDateTime_inValidPropertiesNoInputStart_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddHours((double)3);
            int errorCode = val.validateDateTime("", end.ToString());
            Assert.AreEqual(Validation.kErrorCodes.InputNeeded, errorCode);
        }
        /**
        * \brief: This unit test will check if validateDateTime accepts invalid no data for end input
        * \ <b> Name of Method</b>
        * validateDateTime_inValidPropertiesNoInputEnd_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "start.ToString()"
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a InputNeeded error code
        * 
        * \ <b> Actual Result</b>
        * There is a InputNeeded error code. 
        */
        [TestMethod]
        public void validateDateTime_inValidPropertiesNoInputEnd_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddHours((double)3);
            int errorCode = val.validateDateTime(start.ToString(), "");
            Assert.AreEqual(Validation.kErrorCodes.InputNeeded, errorCode);
        }
        /**
        * \brief: This unit test will check if validateDateTime accepts invalid data input
        * \ <b> Name of Method</b>
        * validateDateTime_inValidPropertiesInvalidDateTimes_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "DateTime.Now.AddHours((double)3)"
        * "DateTime.Now"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a endTimeBeforeStartTime error code
        * 
        * \ <b> Actual Result</b>
        * There is a endTimeBeforeStartTime error code. 
        */
        [TestMethod]
        public void validateDateTime_inValidPropertiesInvalidDateTimes_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            DateTime start = DateTime.Now.AddHours((double)3);
            DateTime end = DateTime.Now;
            int errorCode = val.validateDateTime(start.ToString(), end.ToString());
            Assert.AreEqual(Validation.kErrorCodes.endTimeBeforeStartTime, errorCode);
        }
        //validateActive_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateActive accepts valid true data input
        * \ <b> Name of Method</b>
        * validateActive_ValidPropertiesTrue_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "true.ToString()"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateActive_ValidPropertiesTrue_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = true.ToString();
            int errorCode = val.validateActive(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateActive accepts valid false data input
        * \ <b> Name of Method</b>
        * validateActive_ValidPropertiesFalse_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "false.ToString()"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateActive_ValidPropertiesFalse_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = false.ToString();
            int errorCode = val.validateActive(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateActive accepts invalid no data input
        * \ <b> Name of Method</b>
        * validateActive_inValidPropertiesEmpty_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a InputNeeded error code
        * 
        * \ <b> Actual Result</b>
        * There is a InputNeeded error code. 
        */
        [TestMethod]
        public void validateActive_inValidPropertiesEmpty_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            int errorCode = val.validateActive(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.InputNeeded, errorCode);
        }
        /**
        * \brief: This unit test will check if validateActive accepts not boolean data input
        * \ <b> Name of Method</b>
        * validateActive_inValidPropertiesNotBool_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * ""
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notBoolean error code
        * 
        * \ <b> Actual Result</b>
        * There is a notBoolean error code. 
        */
        [TestMethod]
        public void validateActive_inValidPropertiesNotBool_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "123-4567";
            int errorCode = val.validateActive(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notBoolean, errorCode);
        }
        //validatePostalCode_______________________________________________________________________
        /**
        * \brief: This unit test will check if validatePostalCode valid no space input
        * \ <b> Name of Method</b>
        * validatePostalCode_ValidPropertiesNoSpace_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "A1B2C8"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoErrorerror code. 
        */
        [TestMethod]
        public void validatePostalCode_ValidPropertiesNoSpace_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "a1B2C8";
            int errorCode = val.validatePostalCode(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePostalCode valid spaced input
        * \ <b> Name of Method</b>
        * validatePostalCode_ValidPropertiesSpace_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "A1B 2C8"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoErrorerror code. 
        */
        [TestMethod]
        public void validatePostalCode_ValidPropertiesSpace_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "A1B 2C8";
            int errorCode = val.validatePostalCode(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePostalCode invalid too long input
        * \ <b> Name of Method</b>
        * validatePostalCode_inValidPropertiesTooLong_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "A1B  2C8"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputTooLong error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputTooLong error code. 
        */
        [TestMethod]
        public void validatePostalCode_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "A1B";
            do
            {
                dataToPassIn += " ";
            } while (dataToPassIn.Length <= Validation.consts.MaxPostalCodeLength - 3);
            dataToPassIn += "2C8";
            int errorCode = val.validatePostalCode(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
        * \brief: This unit test will check if validatePostalCode invalid input
        * \ <b> Name of Method</b>
        * validatePostalCode_inValidPropertiesInvalidPostalCode_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "A1B2C89"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a invalidPostalCode error code
        * 
        * \ <b> Actual Result</b>
        * There is a invalidPostalCode error code. 
        */
        [TestMethod]
        public void validatePostalCode_inValidPropertiesInvalidPostalCode_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "A1B2C89";
            int errorCode = val.validatePostalCode(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidPostalCode, errorCode);
        }
        //validateCountry_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateCountry valid input
        * \ <b> Name of Method</b>
        * validateCountry_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "Canada"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateCountry_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "Canada";
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateCountry valid lower case input
        * \ <b> Name of Method</b>
        * validateCountry_ValidPropertiesLowerCase_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "canada"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateCountry_ValidPropertiesLowerCase_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "canada";
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateCountry valid Upper case input
        * \ <b> Name of Method</b>
        * validateCountry_ValidPropertiesUpperCase_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "CANADA"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateCountry_ValidPropertiesUpperCase_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "CANADA";
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
       * \brief: This unit test will check if validateCountry invalid too long input
       * \ <b> Name of Method</b>
       * validateCountry_inValidPropertiesTooLong_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is exception/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "a"(max length plus one)
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a inputTooLong error code
       * 
       * \ <b> Actual Result</b>
       * There is a inputTooLong error code. 
       */
        [TestMethod]
        public void validateCountry_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxCountryLength);
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
       * \brief: This unit test will check if validateCountry invalid country input
       * \ <b> Name of Method</b>
       * validateCountry_inValidPropertiesinValidCountry_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is exception/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "canado"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a invalidCountry error code
       * 
       * \ <b> Actual Result</b>
       * There is a invalidCountry error code. 
       */
        [TestMethod]
        public void validateCountry_inValidPropertiesinValidCountry_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "canado";
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidCountry, errorCode);
        }
        /**
       * \brief: This unit test will check if validateCountry invalid input
       * \ <b> Name of Method</b>
       * validateCountry_inValidPropertiesInvalidCharacters_ReturnsError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is exception/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "----------"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a invalidCountry error code
       * 
       * \ <b> Actual Result</b>
       * There is a invalidCountry error code. 
       */
        [TestMethod]
        public void validateCountry_inValidPropertiesInvalidCharacters_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "----------";
            int errorCode = val.validateCountry(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidCountry, errorCode);
        }
        //validateCity_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateCity valid input
        * \ <b> Name of Method</b>
        * validateCity_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "Kitchener"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateCity_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "Kitchener";
            int errorCode = val.validateCity(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateCity invalid too long input
        * \ <b> Name of Method</b>
        * validateCity_inValidPropertiesTooLong_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "a"(max length plus one)
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputTooLong error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputTooLong error code. 
        */
        [TestMethod]
        public void validateCity_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "a";
            } while (dataToPassIn.Length <= Validation.consts.MaxCityLength);
            int errorCode = val.validateCity(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
        * \brief: This unit test will check if validateCity invalid characters input
        * \ <b> Name of Method</b>
        * validateCity_inValidPropertiesInvalidCharacters_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "-@#$"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a InvalidCharacters error code
        * 
        * \ <b> Actual Result</b>
        * There is a InvalidCharacters error code. 
        */
        [TestMethod]
        public void validateCity_inValidPropertiesInvalidCharacters_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "-@#$";
            int errorCode = val.validateCity(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.InvalidCharacters, errorCode);
        }
        //validateFax_______________________________________________________________________
        /**
       * \brief: This unit test will check if invalidFaxFormat valid input
       * \ <b> Name of Method</b>
       * validateFax_ValidProperties_ReturnsNoError
       * 
       * \ <b> How test is Conducted</b>
       * This test is run automatically
       * 
       * \ <b> Type of Test</b>
       * The type of test is normal/functional/unit testing.
       * 
       * \ <b> Sample Data Sets</b>
       * "+895(194)6165163"
       * 
       * \ <b> Expected Result</b>
       * The expected result is that there is a NoError error code
       * 
       * \ <b> Actual Result</b>
       * There is a NoError error code. 
       */
        [TestMethod]
        public void validateFax_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "+895(194)6165163";
            int errorCode = val.validateFax(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
      * \brief: This unit test will check if invalidFaxFormat invalid tooLong input
      * \ <b> Name of Method</b>
      * validateFax_inValidPropertiesTooLong_ReturnsError
      * 
      * \ <b> How test is Conducted</b>
      * This test is run automatically
      * 
      * \ <b> Type of Test</b>
      * The type of test is exception/functional/unit testing.
      * 
      * \ <b> Sample Data Sets</b>
      * "+895(194)61651631"(add ones to the end until over max length)
      * 
      * \ <b> Expected Result</b>
      * The expected result is that there is a inputTooLong error code
      * 
      * \ <b> Actual Result</b>
      * There is a inputTooLong error code. 
      */
        [TestMethod]
        public void validateFax_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "+895(194)6165163";
            do
            {
                dataToPassIn += "1";
            } while (dataToPassIn.Length <= Validation.consts.MaxFaxLength);
            int errorCode = val.validateFax(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        /**
        * \brief: This unit test will check if invalidFaxFormat invalid format input
        * \ <b> Name of Method</b>
        * validateFax_inValidPropertiesInvalidFaxFormat_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "895(194)6165163"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a invalidFaxFormat error code
        * 
        * \ <b> Actual Result</b>
        * There is a invalidFaxFormat error code. 
        */
        [TestMethod]
        public void validateFax_inValidPropertiesInvalidFaxFormat_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "895(194)6165163";
            int errorCode = val.validateFax(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidFaxFormat, errorCode);
        }
        //validateYearOfIncorperation_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateYearOfIncorperation accepts valid input
        * \ <b> Name of Method</b>
        * validateYearOfIncorperation_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "DateTime.Now.Year.ToString()"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateYearOfIncorperation_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = DateTime.Now.Year.ToString();
            int errorCode = val.validateYearOfIncorperation(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateYearOfIncorperation accepts invalid non number input
        * \ <b> Name of Method</b>
        * validateYearOfIncorperation_inValidPropertiesNotNumber_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "not number"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notNumber error code
        * 
        * \ <b> Actual Result</b>
        * There is a notNumber error code. 
        */
        [TestMethod]
        public void validateYearOfIncorperation_inValidPropertiesNotNumber_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "not number";
            int errorCode = val.validateYearOfIncorperation(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notNumber, errorCode);
        }
        /**
        * \brief: This unit test will check if validateYearOfIncorperation accepts invalid year input
        * \ <b> Name of Method</b>
        * validateYearOfIncorperation_inValidPropertiesInvalidYear_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "int yr = DateTime.Now.Year;
            yr += 1;
            string dataToPassIn = yr.ToString();"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a invalidIncorpirationYear error code
        * 
        * \ <b> Actual Result</b>
        * There is a invalidIncorpirationYear error code. 
        */
        [TestMethod]
        public void validateYearOfIncorperation_inValidPropertiesInvalidYear_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            int yr = DateTime.Now.Year;
            yr += 1;
            string dataToPassIn = yr.ToString();
            int errorCode = val.validateYearOfIncorperation(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidIncorpirationYear, errorCode);
        }
        /**
        * \brief: This unit test will check if validateYearOfIncorperation accepts invalid too small input
        * \ <b> Name of Method</b>
        * validateYearOfIncorperation_inValidPropertiesInvalidYearFormat_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "123"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a invalidYearFormat error code
        * 
        * \ <b> Actual Result</b>
        * There is a invalidYearFormat error code. 
        */
        [TestMethod]
        public void validateYearOfIncorperation_inValidPropertiesInvalidYearFormat_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "123";
            int errorCode = val.validateYearOfIncorperation(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidYearFormat, errorCode);
        }
        //validateStreetAddress_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateStreetAddress accepts valid input
        * \ <b> Name of Method</b>
        * validateStreetAddress_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "299 Doon Valley Dr"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateStreetAddress_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "299 Doon Valley Dr";
            int errorCode = val.validateStreetAddress(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStreetAddress accepts invalid input
        * \ <b> Name of Method</b>
        * validateStreetAddress_inValidProperties_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "badinput@"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a invalidStreetAddress error code
        * 
        * \ <b> Actual Result</b>
        * There is a invalidStreetAddress error code. 
        */
        [TestMethod]
        public void validateStreetAddress_inValidProperties_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "badinput@";
            int errorCode = val.validateStreetAddress(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.invalidStreetAddress, errorCode);
        }
        /**
        * \brief: This unit test will check if validateStreetAddress accepts invalid too long input
        * \ <b> Name of Method</b>
        * validateStreetAddress_inValidPropertiesTooLong_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "1"(max length plus one)
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a inputTooLong error code
        * 
        * \ <b> Actual Result</b>
        * There is a inputTooLong error code. 
        */
        [TestMethod]
        public void validateStreetAddress_inValidPropertiesTooLong_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "";
            do
            {
                dataToPassIn += "1";
            } while (dataToPassIn.Length <= Validation.consts.MaxAddressLength);
            int errorCode = val.validateStreetAddress(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.inputTooLong, errorCode);
        }
        //validateID_______________________________________________________________________
        /**
        * \brief: This unit test will check if validateID accepts valid input
        * \ <b> Name of Method</b>
        * validateID_ValidProperties_ReturnsNoError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is normal/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "1"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a NoError error code
        * 
        * \ <b> Actual Result</b>
        * There is a NoError error code. 
        */
        [TestMethod]
        public void validateID_ValidProperties_ReturnsNoError()
        {
            Validation.Validation val = new Validation.Validation();
            string dataToPassIn = "1";
            int errorCode = val.validateID(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.NoError, errorCode);
        }
        /**
        * \brief: This unit test will check if validateID accepts invalid non number input
        * \ <b> Name of Method</b>
        * validateID_inValidPropertiesNotNumber_ReturnsError
        * 
        * \ <b> How test is Conducted</b>
        * This test is run automatically
        * 
        * \ <b> Type of Test</b>
        * The type of test is exception/functional/unit testing.
        * 
        * \ <b> Sample Data Sets</b>
        * "a"
        * 
        * \ <b> Expected Result</b>
        * The expected result is that there is a notNumber error code
        * 
        * \ <b> Actual Result</b>
        * There is a notNumber error code. 
        */
        [TestMethod]
        public void validateID_inValidPropertiesNotNumber_ReturnsError()
        {
            Validation.Validation val = new Validation.Validation();

            string dataToPassIn = "a";
            int errorCode = val.validateID(dataToPassIn);
            Assert.AreEqual(Validation.kErrorCodes.notNumber, errorCode);
        }
    }
}

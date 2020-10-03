/* Task:
ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
If the function is passed a valid PIN string, return true, else return false.

Examples
"1234"   -->  true
"12345"  -->  false
"a234"   -->  false
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
    public static bool ValidatePin(string pin) =>
     pin != null &&
    (pin.Length == 4 || pin.Length == 6) &&
     pin.All(c => c >= '0' && c <= '9');

}

//NUnit Tests

namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("ValidatePin should return false for pins with length other than 4 or 6")]
    public void LengthTest()
    {
      Assert.AreEqual(false, Kata.ValidatePin("1"), "Wrong output for \"1\"");
      Assert.AreEqual(false, Kata.ValidatePin("12"), "Wrong output for \"12\"");
      Assert.AreEqual(false, Kata.ValidatePin("123"), "Wrong output for \"123\"");
      Assert.AreEqual(false, Kata.ValidatePin("12345"), "Wrong output for \"12345\"");
      Assert.AreEqual(false, Kata.ValidatePin("1234567"), "Wrong output for \"1234567\"");
      Assert.AreEqual(false, Kata.ValidatePin("-1234"), "Wrong output for \"-1234\"");
      Assert.AreEqual(false, Kata.ValidatePin("1.234"), "Wrong output for \"1.234\"");
      Assert.AreEqual(false, Kata.ValidatePin("-1.234"), "Wrong output for \"-1.234\"");
      Assert.AreEqual(false, Kata.ValidatePin("00000000"), "Wrong output for \"00000000\"");
    }
    
    [Test, Description("ValidatePin should return false for pins which contain characters other than digits")]
    public void NonDigitTest()
    {
      Assert.AreEqual(false, Kata.ValidatePin("a234"), "Wrong output for \"a234\"");
      Assert.AreEqual(false, Kata.ValidatePin(".234"), "Wrong output for \".234\"");
    }
    
    [Test, Description("ValidatePin should return true for valid pins")]
    public void ValidTest()
    {
      Assert.AreEqual(true, Kata.ValidatePin("1234"), "Wrong output for \"1234\"");
      Assert.AreEqual(true, Kata.ValidatePin("0000"), "Wrong output for \"0000\"");
      Assert.AreEqual(true, Kata.ValidatePin("1111"), "Wrong output for \"1111\"");
      Assert.AreEqual(true, Kata.ValidatePin("123456"), "Wrong output for \"123456\"");
      Assert.AreEqual(true, Kata.ValidatePin("098765"), "Wrong output for \"098765\"");
      Assert.AreEqual(true, Kata.ValidatePin("000000"), "Wrong output for \"000000\"");
      Assert.AreEqual(true, Kata.ValidatePin("090909"), "Wrong output for \"090909\"");
    }
  }
}
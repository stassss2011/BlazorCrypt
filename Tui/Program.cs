// See https://aka.ms/new-console-template for more information

using CommonLibrary.Attacks;
using CommonLibrary.Ciphers;
using CommonLibrary.Ciphers.Defaults;

var babbage = new BabbageAttack(15);
Console.WriteLine(babbage.ForceDecrypt("JN QPLZBLQIACFTJD SVCSUJTVUIPO CJQHFSS XIESF TIF SVCSUJTVUIPO AMQHBCEUT ASF CIPSFO BZ UHF VSF PF B LEZXOSE  TIF KBTITLI FYANJNBUIPO AMMOXT A DSYQUAOBLZTT UP DFEUDF TIF LFOGUI OG UHF LEZXOSE "));


// var chip = new CaesarCipher(5, CaesarCipherDefaults.Alphabet);
// Console.WriteLine(chip.Encrypt("PLLTW TY TQATTM MRQMUD Q IT WIVA TW LV A JQA ON TPTBTL EVKVDQVN OV BOIA TPTBTL PQMJE WN AEFB"));

Console.WriteLine("hello");
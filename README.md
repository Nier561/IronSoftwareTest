Old Phone Pad Decoder
=====================

Overview
--------
The Old Phone Pad Decoder is a straightforward, intuitive utility built in C#. It simulates typing text messages using the classic multi-tap method found on older mobile phone keypads. The decoder converts numerical sequences into readable alphabetical messages, correctly handling multiple key presses per character, pauses, and backspace operations.

Features
--------
- Multi-press Input:
  Each numeric button corresponds to multiple letters. Repeatedly pressing a button cycles through these letters:
  - "2"   => "A"
  - "22"  => "B"
  - "222" => "C"

- Pausing between Inputs:
  To input consecutive letters from the same numeric key, insert a pause represented by a space (" "):
  - "22 2" yields "BA"

- Backspace Functionality:
  The asterisk (*) acts as a backspace, removing the most recent character entered.

- End of Input:
  Every input sequence must finish with the hash symbol (#), indicating the message is ready to decode.

Keypad Mapping
--------------
The keypad mappings for digits to letters are as follows:

  Button | Characters
  -------|-----------
   1     | & ' (
   2     | A B C
   3     | D E F
   4     | G H I
   5     | J K L
   6     | M N O
   7     | P Q R S
   8     | T U V
   9     | W X Y Z
   0     | [space]

How to Use
----------
Call the static method `OldPhonePad` with your keypad input sequence:

Example:
  Input:  "4433555 555666#"
  Output: "HELLO"

Ensure the input always ends with "#" to trigger decoding.

Example Inputs and Outputs
--------------------------
  Input Sequence            | Decoded Output
  --------------------------|---------------
  "33#"                     | E
  "227*#"                   | B
  "4433555 555666#"         | HELLO
  "8 88 777 444 666*664#"   | TURING
  "2 22 222#"               | ABC
  "7777 9999 33 33#"        | SZEE

Important: When inputting two letters in a row that share the same numeric key, remember to insert a space.

Technical Details
-----------------
- Programming Language: C#
- Framework: .NET 9.0 (compatible with earlier .NET Core and .NET 6+)
- Class Structure:
  - OldPhonePadDecoder: Contains logic for decoding keypad input.
  - Program: Demonstrates usage through example test cases.

Running the Example Tests
-------------------------
To execute the provided examples, run the application via your IDE or command-line interface:

  dotnet run

Customization
-------------
- Easily adjust keypad mappings in the source code's `Keypad` dictionary.
- Additional error handling can be implemented for input validation or formatting issues.

Author and Contact
------------------
Developed by Ronny Severino. For inquiries or feedback, please contact ronnyseverino7@gmail.com

License
-------
This code is provided as-is for evaluation purposes. Additional licensing may apply for commercial usage.


# ArtLogic

##Overview

The software encodes the text of a .txt file sent by the user and download a .txt file white the coded datas

### **Stacks**:

The implementation is developed in C#
Use of the .Net 6 framework

### **Writing Encoded Text**

In the **Global** class were added:
*sCharacterSize*: which represents the size of the character to be encoded.
*sBinarySize*: bit size;
*sMaxSize*: binary size (*sCharacterSize* x *sBinarySize*) .

The **WriteEncodedText** method of the **DecodeEncode** calls the method Encode of the library **TheWeirdTextFormatLibrary** to encode the character's in the file.
The standard size that the library uses is 4. If the system uses another character size, just change change attribute value sCharacterSize in Global,
and send by parameter.

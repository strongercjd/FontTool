# Instructions for use

[中文](https://github.com/strongercjd/FontTool/blob/master/README.md)

Disclaimer:

> This tool is maintained by individual developers and has nothing to do with any organization or company. The developers do not guarantee the correctness of the fonts. The developers are not professional C # developers. The open source code is for reference only.

## 1. Overview

The tool is used to generate fonts, and the generated fonts are suitable for onbon font library card series controller and 6Q3 series controller. The tool can view the font, edit the font, and make fonts.

| series | Applicable controller model |
| ---------- | -------------------------------- |
| Font controller | 5K1 5K2 5MK 5KX<br>6K1 6K2 6K3<br>6K1-YY 6K2-YY 6K3-YY |
| 6Q3 | 6Q3 6Q3L 6QX-YD 6QX-M |

## 2. Check the font

- Select viewing mode
- Open the font file, if you open the font library series font, you need to manually select the width, height and encoding format; if you open the 6Q3 series font, the program will automatically recognize the width, height and encoding format

There are 3 ways to view the font

- Enter the viewed text in the preview character box
- Select the internal code corresponding to the text
- Use the previous and next buttons to select

## 3. Edit the font

 Select the edit mode, the font has been opened correctly first, refer to step 2. Enter the question to be modified in the preview box.

There are 3 editing methods  

- In the preview area, click the pixel with the left mouse button, the color of this pixel will be reversed
- In the preview area, hold down the left mouse button and do not relax. Move the mouse, and the passed pixels will turn black
- In the preview area, hold down the right mouse button and do not relax

After editing the font, click the save font button, the program prompts "Successfully saved this font", indicating that the font was saved successfully

> important hint:

Only one character can be modified at a time. After the modification of one character is completed, the button to save the font must be clicked, and the next character can only be modified after the prompt is saved successfully.

## 4. Make a font

 Choose Make font mode

Modify the width and height of the font, select the font and size, and also modify the horizontal and vertical offsets appropriately according to the preview.

After the modification is completed, click the button to make the font and wait for the completion of the production  



About 6Q3 font
> In the 6Q3 font, the first letter of the font name is O, and the English is E. The following 3 numbers are random. For example, the system generates 8 * 16 English font name randomly to generate E025. After the font is generated, you can also rename it to E000 under windows. Download it into the 6Q3 controller and call \\ FE000, which means that the English 8 * 16 font is called. If you don't change the name, download E025 into the controller, then call \\ FE025, which means that the font of English 8 * 16 is called
> 
>There is no need to tangle the name of the font, but the English font should start with E, and the Chinese font should start with O (not the number 0, but the capital English letter O)  






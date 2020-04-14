# 使用说明

[English](https://github.com/strongercjd/FontTool/blob/master/README_EN.md)

免责声明：

> 此工具是个人开发者维护，和任何组织和公司没有关系，开发者也不对做出的字库的正确性做保证，开发者并非专业C#开发人员，开源代码仅供参考。

## 1、概述

工具用于生成字库，生成的字库适用于仰邦字库卡系列控制器和6Q3系列控制器。工具可以查看字库，编辑字库，制作字库的功能。

| 系列     | 适用的控制卡型号 |
| ---------- | -------------------------------- |
| 字库卡系列 | 5K1 5K2 5MK 5KX<br>6K1 6K2 6K3<br>6K1-YY 6K2-YY 6K3-YY |
| 6Q3系列 | 6Q3 6Q3L 6QX-YD 6QX-M |

## 2、查看字库

- 选择查看模式
- 打开字库文件，如果打开的是字库卡系列字库，需要手动选择选择宽度，高度和编码格式；如果打开的是6Q3系列字库，程序会自动识别宽度，高度和编码格式

查看字库方式分3种

- 在预览字符框中输入查看的文字
- 选择文字对应的机内码
- 使用上一个和下一个按钮进行选择

## 3、编辑字库

选中编辑模式，首先已经正确的打开了字库，参考第2步。在预览框中输入需要修改的问题。

编辑方式分3钟

- 在预览区域，使用鼠标左键点击像素点，这个像素点颜色会反转
- 在预览区域，按住鼠标左键不放松，移动鼠标，经过的像素单会变成黑色
- 在预览区域，按住鼠标右键不放松，移动鼠标，经过的像素单会变成白色

编辑完字库，点击保存字模按钮，程序提示”成功保存这个字模“，表示保存字模成功

> 重要提示：

每次只能修改一个字符，修改一个字符完成之后，要点击保存字模按钮，提示保存成功之后，才能修改下一个字符。

## 4、制作字库

选择制作字库模式

修改字库宽度和高度，选择字体和大小，也可以根据预览适当修改水平和垂直偏移。

修改完毕后，点击制作字库按钮，等待制作完成



> 关于6Q3字库
>
> 6Q3字库中文字库名字首字母是O，英文是E。后面3个数字随意。比如系统生成8*16英文字库名字随机生成E025，生成字库完毕你也在windows下重命名为E000，下载进入6Q3控制器中，调用\\FE000，代表调用的是英文8*16的字库。如果你不修改名字，就把E025下载进入控制器，那么调用\\FE025，代表调用的是英文8*16的字库
>
> 不用纠结字库的名字，但是英文字库要以E开头，中文字库以O(不是数字0，是大写英文字母O)开头






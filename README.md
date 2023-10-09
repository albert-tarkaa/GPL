# GPL - Graphical Programming Language Application README

## Introduction

This README document provides an overview of the Graphical Programming Language Application, outlining its key features, design principles, and requirements.

## Table of Contents

1. [Design Principles](#design-principles)
2. [Version Control](#version-control)
3. [Graphical User Interface](#graphical-user-interface)
4. [Command Parser Class](#command-parser-class)
5. [Basic Drawing Commands](#basic-drawing-commands)
6. [Colors and Fills](#colors-and-fills)
7. [Artificial Intelligence and Libraries](#artificial-intelligence-and-libraries)

## Design Principles<a name="design-principles"></a>

1. The program is designed using inheritance and design patterns to allow easy addition of commands without affecting existing code.

## Version Control<a name="version-control"></a>

2. A preferred Version Control System (e.g., Git) is set up, and the assignment specification and relevant documents are committed to it within the first two weeks of the term, before Monday morning 9 am in week 3.

## Graphical User Interface<a name="graphical-user-interface"></a>

3. The graphical user interface features:
   - A command input area for receiving individual program commands.
   - An area for receiving a complete program.
   - An area for graphical program output.
   - Buttons for running a program and performing a syntax check.

## Command Parser Class<a name="command-parser-class"></a>

4. Command Parser Class functionalities include:
   - Reading and executing commands on the command line one at a time.
   - Reading a program (from the program window) and executing it with a "run" command.
   - Saving and loading a program to/from a text file.
   - Syntax checking for valid commands and parameters, reporting errors using exceptions.

## Basic Drawing Commands<a name="basic-drawing-commands"></a>

5. Basic drawing commands are case insensitive and include:
   - Positioning the pen (moveTo).
   - Drawing with the pen (drawTo).
   - Clearing the drawing area (clear command).
   - Resetting the pen to the initial position at the top left of the screen (reset command).
   - Drawing basic shapes:
     - Rectangle `<width>, <height>`.
     - Circle `<radius>`.
     - Triangle (implementation may vary).
   - Color and fill commands:
     - Pen `<color>` (e.g., pen red, pen green, supports multiple colors).
     - Fill `<on/off>` (e.g., fill on, enabling subsequent shape operations).

## Colors and Fills<a name="colors-and-fills"></a>

6. Colors and fills are supported in the application. Drawing commands can be customized with different colors and fill options.

## Artificial Intelligence and Libraries<a name="artificial-intelligence-and-libraries"></a>

7. In the video demo, the usage of any artificial intelligence components and external libraries must be explained. It's acceptable to use libraries and tools to enhance productivity, but a clear understanding of their use is required. The overview should cover:
   - Non-standard libraries utilized.
   - AI tools employed.
   - Third-party code integrated.

## Conclusion

This README provides an overview of the Graphical Programming Language Application, highlighting its design principles, features, and the importance of version control. The application allows for the creation and execution of graphical programs using a variety of drawing commands, colors, and fills, while also emphasizing the need for clear documentation and understanding of any external libraries or tools employed.

## Acknowledgment of ChatGPT Use

I would like to acknowledge the use of ChatGPT- a language model developed by OpenAI, in structuring this README on October 9, 2023.

**Note:** While ChatGPT is a valuable tool for generating content, it's important to review and customize the generated content to ensure it aligns with the specific needs and goals of your project.

---

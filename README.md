[logo]: https://raw.githubusercontent.com/Geeksltd/Zebble.CheckBox/master/Shared/NuGet/Icon.png "Zebble.CheckBox"


## Zebble.CheckBox

![logo]

Very simple checkbox object for Zebble applications. It uses an image for the checked effect.


[![NuGet](https://img.shields.io/nuget/v/Zebble.CheckBox.svg?label=NuGet)](https://www.nuget.org/packages/Zebble.CheckBox/)

> A CheckBox is a Zebble plugin that you can set the image to be different from a tick, or define the appearance of it however you need in the Styles.

<br>


### Setup
* Available on NuGet: [https://www.nuget.org/packages/Zebble.CheckBox/](https://www.nuget.org/packages/Zebble.CheckBox/)
* Install in your platform client projects.
* Available for iOS, Android and UWP.
<br>


### Api Usage

#### Basic usage:
```xml
<CheckBox Id="MyCheckBox1"  Checked="false" ></CheckBox>
<CheckBox Id="MyCheckBox2"  Checked="true" ></CheckBox>
```
```csharp
new CheckBox { Id = "MyCheckBox1", Checked = true };
new CheckBox { Id = "MyCheckBox2", Checked = false};
```
#### Checked
You can set the value of CheckBox by changing Checked property. The default value is false.
#### Checked image:
You can use CheckedImage field to set an image for the checked state, like the following:
```csharp
MyCheckBox.CheckedImage = new ImageView { Path = "Images/Something.png" };
```
#### Checked changed:
The main event for a CheckBox is CheckedChanged. In this method you should define what you want to do when user checks/unchecks the CheckBox control.
```csharp
MyCheckBox.CheckedChanged += CheckedChange;
void CheckedChange() { /* Do something here */ }
```
### Properties
| Property     | Type         | Android | iOS | Windows |
| :----------- | :----------- | :------ | :-- | :------ |
| CheckedImage            | View           | x       | x   | x       |
| Path            | string           | x       | x   | x       |
| Checked            | bool           | x       | x   | x       |

### Events
| Event             | Type                                          | Android | iOS | Windows |
| :-----------      | :-----------                                  | :------ | :-- | :------ |
| CheckedChanged               | AsyncEvent    | x       | x   | x       |

### Methods
| Method       | Return Type  | Parameters                          | Android | iOS | Windows |
| :----------- | :----------- | :-----------                        | :------ | :-- | :------ |
| ToggleChanged         | Task| -| x       | x   | x       |

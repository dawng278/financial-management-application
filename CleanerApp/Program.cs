using System;
using System.IO;
using System.Text.RegularExpressions;

class Program {
    static void Main() {
        string[] badProps = { 
            "BorderRadius", "FillColor", "CustomBorderColor", "CustomBorderThickness", 
            "ShadowDecoration", "BorderColor", "BorderThickness", "PlaceholderText", 
            "ProgressColor", "ProgressColor2", "HoverState", "FocusedState", 
            "CheckedState", "DefaultText", "ReadOnly", "ThemeStyle",
            "ImageOffset", "ImageRotate", "CustomizableEdges", "ImageAlign", "TextAlign"
        };
        
        string directory = @"d:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\Forms";
        string themeDir  = @"d:\XML\PersonalFinanceManager\PersonalFinanceManager.UI\Theme";
        
        foreach(var dir in new[] { directory, themeDir }) {
            foreach(var file in Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories)) {
                if(file.Contains("AssemblyInfo")) continue;
                
                string content = File.ReadAllText(file);
                string original = content;
                
                // 1. Direct assignments (with dots): e.g. this.hopeButton1.FillColor = ...;
                foreach(var prop in badProps) {
                    string pattern = @"[a-zA-Z0-9_.]+\." + prop + @"\s*=[^;]+;";
                    content = Regex.Replace(content, pattern, "");
                }
                
                // 2. Sub-property assignments
                string patternHover = @"[a-zA-Z0-9_.]+\.(HoverState|FocusedState|ShadowDecoration)\.[a-zA-Z0-9_]+\s*=[^;]+;";
                content = Regex.Replace(content, patternHover, "");
                // some assignments are `HoverState = ...;` which is caught by rule 1.
                
                // 3. Object initializers: e.g. BorderRadius = 5,
                foreach(var prop in badProps) {
                    string pattern = @"(?<!\.)\b" + prop + @"\s*=";
                    while (true) {
                        var match = Regex.Match(content, pattern);
                        if (!match.Success) break;
                        
                        int idx = match.Index;
                        int endIdx = idx + match.Length;
                        int parenLevel = 0;
                        while(endIdx < content.Length) {
                            char c = content[endIdx];
                            if(c == '(' || c == '{') parenLevel++;
                            else if(parenLevel == 0 && (c == ',' || c == '}')) {
                                if(c == ',') endIdx++; // consume the comma
                                break;
                            }
                            else if(c == ')' || c == '}') parenLevel--;
                            endIdx++;
                        }
                        content = content.Remove(idx, endIdx - idx);
                    }
                }
                
                // 4. Value -> ValueNumber for Progress bars
                content = content.Replace("progressBar.Value =", "progressBar.ValueNumber =");
                content = content.Replace("pb.Value =", "pb.ValueNumber =");
                
                // 5. HopeButton Image (we don't include Image in badProps because PictureBox uses it)
                // But Guna2Button translates to HopeButton and had an Image property
                string patternBtnImage = @"[a-zA-Z0-9_.]*hopeButton[a-zA-Z0-9_]*\.Image\s*=[^;]+;";
                content = Regex.Replace(content, patternBtnImage, "", RegexOptions.IgnoreCase);
                
                if(original != content) {
                    File.WriteAllText(file, content);
                    Console.WriteLine("Cleaned " + Path.GetFileName(file));
                }
            }
        }
    }
}
